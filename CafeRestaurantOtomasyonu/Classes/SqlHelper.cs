using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeRestaurantOtomasyonu.Classes
{
    class SqlHelper
    {
        public static SqlConnection DinamikConn = null;
        public static SqlConnection MasterConn = null;
        public static SqlTransaction DinamikConnTransaction = null;
        public static string DinamikConnStr { get; set; }

        internal static string AyarGetir(int ayarID)
        {

            try
            {
                string sorgu = @"SELECT [Deger] 
                                 FROM [AYARLAR] 
                                 WHERE [AyarID]=@AyarID";
                object objDeger = GetScalarValue(sorgu,
                    new DinamikSqlParameter("AyarID", ayarID));

                if (objDeger != null && objDeger != DBNull.Value)
                    return objDeger.ToString();
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("AyarGetir()", string.Format("HATA: {0}", ex.Message));
                throw ex;
            }
            return string.Empty;
        }
        internal static int ExecuteNonQuery(string query, params DinamikSqlParameter[] parameters)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, DinamikConn))
                {
                    foreach (DinamikSqlParameter parameter in parameters)
                    {
                        cmd.Parameters.AddWithValue(parameter.ParameterName, parameter.Value);
                    }

                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int ExecuteNonQueryByTransaction(string query, params DinamikSqlParameter[] parameters)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, DinamikConn))
                {
                    cmd.Transaction = DinamikConnTransaction;
                    foreach (DinamikSqlParameter parameter in parameters)
                    {
                        cmd.Parameters.AddWithValue(parameter.ParameterName, parameter.Value);
                    }

                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetDataTable(string query, params DinamikSqlParameter[] parameters)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, DinamikConn))
                {
                    foreach (DinamikSqlParameter parameter in parameters)
                    {
                        cmd.Parameters.AddWithValue(parameter.ParameterName, parameter.Value);
                    }

                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static SqlDataReader GetDataReader(string query, params DinamikSqlParameter[] parameters)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, DinamikConn))
                {
                    foreach (DinamikSqlParameter parameter in parameters)
                    {
                        cmd.Parameters.AddWithValue(parameter.ParameterName, parameter.Value);
                    }

                    return cmd.ExecuteReader();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        internal static SqlDataReader GetDataReaderByTransaction(string query, params DinamikSqlParameter[] parameters)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, DinamikConn))
                {
                    cmd.Transaction = DinamikConnTransaction;
                    foreach (DinamikSqlParameter parameter in parameters)
                    {
                        cmd.Parameters.AddWithValue(parameter.ParameterName, parameter.Value);
                    }

                    return cmd.ExecuteReader();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Object GetScalarValue(string query, params DinamikSqlParameter[] parameters)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, DinamikConn))
                {
                    foreach (DinamikSqlParameter parameter in parameters)
                    {
                        cmd.Parameters.AddWithValue(parameter.ParameterName, parameter.Value);
                    }

                    return cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static Object GetScalarValueByTransaction(string query, params DinamikSqlParameter[] parameters)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, DinamikConn))
                {
                    cmd.Transaction = DinamikConnTransaction;
                    foreach (DinamikSqlParameter parameter in parameters)
                    {
                        cmd.Parameters.AddWithValue(parameter.ParameterName, parameter.Value);
                    }

                    return cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        internal static void BaglantiCumleleriAta()
        {
            string baglantiCumlesiDosyaYolu = Path.Combine(Application.StartupPath, "System.dat");

            string sifreliCumle = string.Empty;
            if (File.Exists(baglantiCumlesiDosyaYolu))
            {
                sifreliCumle = File.ReadAllText(baglantiCumlesiDosyaYolu);
            }

            string baglantiCumleleri = string.Empty;

            if (!string.IsNullOrEmpty(sifreliCumle))
            {
                UniqueValue sifreleme = new UniqueValue();
                baglantiCumleleri = sifreleme.EnDeCrypt(sifreliCumle);
            }
            string[] baglantiCumleleriArray = baglantiCumleleri.Split(new string[] { "^#^" }, StringSplitOptions.None);

            if (baglantiCumleleriArray.Length > 0 && !string.IsNullOrWhiteSpace(baglantiCumleleriArray[0]))
                SqlHelper.DinamikConnStr = baglantiCumleleriArray[0];

        }
        internal static void BaglantiCumleleriKaydet()
        {
            string veri =SqlHelper.DinamikConnStr;

            string baglantiCumlesiDosyaYolu = Path.Combine(Application.StartupPath, "System.dat");

            UniqueValue sifreleme = new UniqueValue();
            string sifreliCumle = sifreleme.EnDeCrypt(veri);

            File.WriteAllText(baglantiCumlesiDosyaYolu, sifreliCumle);
        }
        public static bool OpenDinamikConn(bool showMessage = true)
        {
            try
            {
                string message;
                return OpenDinamikConn(showMessage, out message);
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("OpenDinamikConn:", ex.Message);
                return false;
            }
        }
        public static bool OpenDinamikConn(bool showMessage, out string errorMessage)
        {
            try
            {
                DinamikConn = new SqlConnection(DinamikConnStr);
                DinamikConn.Open();
                errorMessage = string.Empty;

                CommonHelper.DataUpgradeDinamik();

                return true;
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("Database İşlemleri", ex.Message);
                XtraMessageBox.Show("CAFE_RESTAURANT_OTOMASYONU veritabanı bağlantısı başarısız. " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorMessage = ex.Message; return false;
            }
        }
        public static bool OpenMasterConn(string masterConnectionString)
        {
            try
            {
                MasterConn = new SqlConnection(masterConnectionString);
                MasterConn.Open();
                return true;
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("Master Database İşlemleri", ex.Message);
                return false;
            }
        }
    }
}
