using CafeRestaurantOtomasyonu.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeRestaurantOtomasyonu.DataLayer
{
    public class Masa
    {
        public int MasaId { get; set; }

        public string MasaAdi { get; set; }

        public string Aciklama { get; set; }

        public int Ekleyen { get; set; }

        public DateTime EklemeTarihi { get; set; }

        public int Guncelleyen { get; set; }

        public DateTime GuncellemeTarihi { get; set; }

        internal static int InsertMasa(Masa masa)
        {
            try
            {
                string query = @"INSERT INTO [dbo].[MASA]([MasaAdi],[Aciklama],[Fk_Ekleyen],[Fk_Guncelleyen])
                                 VALUES(@MasaAdi,@Aciklama,@Ekleyen,@Guncelleyen);
                                 SELECT @@IDENTITY";

                List<DinamikSqlParameter> parameters = new List<DinamikSqlParameter>();

                parameters.Add(new DinamikSqlParameter("@MasaAdi", masa.MasaAdi));
                parameters.Add(new DinamikSqlParameter("@Aciklama", masa.Aciklama));
                parameters.Add(new DinamikSqlParameter("@Ekleyen", masa.Ekleyen));
                parameters.Add(new DinamikSqlParameter("@Guncelleyen", masa.Guncelleyen));

                object objId = SqlHelper.GetScalarValue(query, parameters.ToArray());
                return objId == null || objId == DBNull.Value ? (int)0 : Convert.ToInt32(objId);
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("InsertMasa()", string.Format("HATA: {0}", ex.Message));
                throw ex;
            }
        }

        internal static void UpdateMasa(Masa masa)
        {
            try
            {
                string query = @"UPDATE [dbo].[MASA]
                                 SET [MasaAdi]=@MasaAdi,[Aciklama]=@Aciklama,[Fk_Guncelleyen]=@Guncelleyen,
                                     [GuncellemeTarihi]=GETDATE()
                                 WHERE [MasaId]=@MasaId";

                List<DinamikSqlParameter> parameters = new List<DinamikSqlParameter>();

                parameters.Add(new DinamikSqlParameter("@MasaId", masa.MasaId));
                parameters.Add(new DinamikSqlParameter("@MasaAdi", masa.MasaAdi));
                parameters.Add(new DinamikSqlParameter("@Aciklama", masa.Aciklama));
                parameters.Add(new DinamikSqlParameter("@Guncelleyen", masa.Guncelleyen));

                SqlHelper.ExecuteNonQuery(query, parameters.ToArray());
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("UpdateMasa()", string.Format("HATA: {0}", ex.Message));
                throw ex;
            }
        }

        internal static void DeleteMasa(int masaId)
        {
            try
            {
                string query = @"DELETE FROM [dbo].[MASA] WHERE [MasaId]=@MasaId";

                SqlHelper.ExecuteNonQuery(query, new DinamikSqlParameter("@MasaId", masaId));
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("DeleteMasa()", string.Format("HATA: {0}", ex.Message));
                throw ex;
            }
        }

        internal static Masa GetMasaById(int masaId)
        {
            SqlDataReader sqlDataReader = null;
            try
            {
                string query = @"SELECT [MasaAdi],[Aciklama],[Fk_Ekleyen],[Fk_Guncelleyen],[EklemeTarihi],[GuncellemeTarihi],[MasaId] 
                                 FROM [dbo].[MASA] 
                                 WHERE [MasaId]=@MasaId";

                sqlDataReader = SqlHelper.GetDataReader(query, new DinamikSqlParameter("@MasaId", masaId));
                if (sqlDataReader.Read())
                {
                    Masa obj = new Masa();
                    obj.MasaId = Convert.ToInt32(sqlDataReader["MasaId"]);
                    obj.MasaAdi = Convert.ToString(sqlDataReader["MasaAdi"]);
                    obj.Aciklama = Convert.ToString(sqlDataReader["Aciklama"]);
                    obj.Ekleyen = Convert.ToInt32(sqlDataReader["Fk_Ekleyen"]);
                    obj.EklemeTarihi = Convert.ToDateTime(sqlDataReader["EklemeTarihi"]);
                    obj.Guncelleyen = Convert.ToInt32(sqlDataReader["Fk_Guncelleyen"]);
                    obj.GuncellemeTarihi = Convert.ToDateTime(sqlDataReader["GuncellemeTarihi"]);
                    return obj;
                }
                return null;
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("GetMasaById()", string.Format("HATA: {0}", ex.Message));
                throw ex;
            }
            finally
            {
                if (sqlDataReader != null)
                {
                    if (!sqlDataReader.IsClosed)
                        sqlDataReader.Close();
                    sqlDataReader.Dispose();
                }
            }
        }

        internal static List<Masa> GetMasaByMasaAdi(string masaAdi)
        {
            List<Masa> returnValue = new List<Masa>();
            SqlDataReader sqlDataReader = null;
            try
            {
                string query = @"SELECT [MasaAdi],[Aciklama],[Fk_Ekleyen],[Fk_Guncelleyen],[EklemeTarihi],[GuncellemeTarihi],[MasaId] 
                                 FROM [dbo].[MASA] 
                                 WHERE [MasaAdi]=@MasaAdi";

                sqlDataReader = SqlHelper.GetDataReader(query, new DinamikSqlParameter("@MasaAdi", masaAdi));
                if (sqlDataReader.Read())
                {
                    Masa obj = new Masa();
                    obj.MasaId = Convert.ToInt32(sqlDataReader["MasaId"]);
                    obj.MasaAdi = Convert.ToString(sqlDataReader["MasaAdi"]);
                    obj.Aciklama = Convert.ToString(sqlDataReader["Aciklama"]);
                    obj.Ekleyen = Convert.ToInt32(sqlDataReader["Fk_Ekleyen"]);
                    obj.EklemeTarihi = Convert.ToDateTime(sqlDataReader["EklemeTarihi"]);
                    obj.Guncelleyen = Convert.ToInt32(sqlDataReader["Fk_Guncelleyen"]);
                    obj.GuncellemeTarihi = Convert.ToDateTime(sqlDataReader["GuncellemeTarihi"]);
                    returnValue.Add(obj);
                }
                return returnValue;
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("GetMasaById()", string.Format("HATA: {0}", ex.Message));
                throw ex;
            }
            finally
            {
                if (sqlDataReader != null)
                {
                    if (!sqlDataReader.IsClosed)
                        sqlDataReader.Close();
                    sqlDataReader.Dispose();
                }
            }
        }

        internal static DataTable GetMasa()
        {
            DataTable dataTable = new DataTable();
            try
            {
                string query = @"SELECT [MasaAdi],[Aciklama],[Fk_Ekleyen],[Fk_Guncelleyen],[EklemeTarihi],[GuncellemeTarihi],[MasaId] FROM [dbo].[MASA] ";

                dataTable = SqlHelper.GetDataTable(query);
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("GetMasa()", string.Format("HATA: {0}", ex.Message));
                throw ex;
            }
            return dataTable;
        }

        internal static DataTable GetMasa(string kolonAdi)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string query = @"SELECT [MasaAdi],[Aciklama],[Fk_Ekleyen],[Fk_Guncelleyen],[EklemeTarihi],[GuncellemeTarihi],[MasaId] FROM [dbo].[MASA] ORDER BY " + kolonAdi;

                dataTable = SqlHelper.GetDataTable(query);
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("GetMasa()", string.Format("HATA: {0}", ex.Message));
                throw ex;
            }
            return dataTable;
        }

        internal static int InsertMasaByTransaction(Masa masa)
        {
            try
            {
                string query = @"INSERT INTO [dbo].[MASA]([MasaAdi],[Aciklama],[Fk_Ekleyen],[Fk_Guncelleyen])
                                 VALUES(@MasaAdi,@Aciklama,@Ekleyen,@Guncelleyen);
                                 SELECT @@IDENTITY";

                List<DinamikSqlParameter> parameters = new List<DinamikSqlParameter>();

                parameters.Add(new DinamikSqlParameter("@MasaAdi", masa.MasaAdi));
                parameters.Add(new DinamikSqlParameter("@Aciklama", masa.Aciklama));
                parameters.Add(new DinamikSqlParameter("@Ekleyen", masa.Ekleyen));
                parameters.Add(new DinamikSqlParameter("@Guncelleyen", masa.Guncelleyen));

                object objId = SqlHelper.GetScalarValueByTransaction(query, parameters.ToArray());
                return objId == null || objId == DBNull.Value ? (int)0 : Convert.ToInt32(objId);
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("InsertMasaByTransaction()", string.Format("HATA: {0}", ex.Message));
                throw ex;
            }
        }

        internal static void UpdateMasaByTransaction(Masa masa)
        {
            try
            {
                string query = @"UPDATE [dbo].[MASA]
                                 SET [MasaAdi]=@MasaAdi,[Aciklama]=@Aciklama,[Fk_Guncelleyen]=@Guncelleyen,[GuncellemeTarihi]=GETDATE()
                                 WHERE [MasaId]=@MasaId";

                List<DinamikSqlParameter> parameters = new List<DinamikSqlParameter>();

                parameters.Add(new DinamikSqlParameter("@MasaId", masa.MasaId));
                parameters.Add(new DinamikSqlParameter("@MasaAdi", masa.MasaAdi));
                parameters.Add(new DinamikSqlParameter("@Aciklama", masa.Aciklama));
                parameters.Add(new DinamikSqlParameter("@Guncelleyen", masa.Guncelleyen));

                SqlHelper.ExecuteNonQueryByTransaction(query, parameters.ToArray());
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("UpdateMasaByTransaction()", string.Format("HATA: {0}", ex.Message));
                throw ex;
            }
        }

        internal static void DeleteMasaByTransaction(int masaId)
        {
            try
            {
                string query = @"DELETE FROM [dbo].[MASA] WHERE [MasaId]=@MasaId";

                SqlHelper.ExecuteNonQueryByTransaction(query, new DinamikSqlParameter("@MasaId", masaId));
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("DeleteMasaByTransaction()", string.Format("HATA: {0}", ex.Message));
                throw ex;
            }
        }

        internal static Masa GetMasaByIdByTransaction(int masaId)
        {
            SqlDataReader sqlDataReader = null;
            try
            {
                string query = @"SELECT [MasaAdi],[Aciklama],[Fk_Ekleyen],[Fk_Guncelleyen],[EklemeTarihi],[GuncellemeTarihi],[MasaId] 
                                 FROM [dbo].[MASA] 
                                 WHERE [MasaId]=@MasaId";

                sqlDataReader = SqlHelper.GetDataReaderByTransaction(query, new DinamikSqlParameter("@MasaId", masaId));
                if (sqlDataReader.Read())
                {
                    Masa obj = new Masa();
                    obj.MasaId = Convert.ToInt32(sqlDataReader["MasaId"]);
                    obj.MasaAdi = Convert.ToString(sqlDataReader["MasaAdi"]);
                    obj.Aciklama = Convert.ToString(sqlDataReader["Aciklama"]);
                    obj.Ekleyen = Convert.ToInt32(sqlDataReader["Fk_Ekleyen"]);
                    obj.EklemeTarihi = Convert.ToDateTime(sqlDataReader["EklemeTarihi"]);
                    obj.Guncelleyen = Convert.ToInt32(sqlDataReader["Fk_Guncelleyen"]);
                    obj.GuncellemeTarihi = Convert.ToDateTime(sqlDataReader["GuncellemeTarihi"]);
                    return obj;
                }
                return null;
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("GetMasaByIdByTransaction()", string.Format("HATA: {0}", ex.Message));
                throw ex;
            }
            finally
            {
                if (sqlDataReader != null)
                {
                    if (!sqlDataReader.IsClosed)
                        sqlDataReader.Close();
                    sqlDataReader.Dispose();
                }
            }
        }

    }

}
