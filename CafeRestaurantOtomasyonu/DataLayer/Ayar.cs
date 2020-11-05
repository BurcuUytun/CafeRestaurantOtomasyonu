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
    public class Ayar
    {
        public int AyarId { get; set; }

        public int AyarGrup { get; set; }

        public string Aciklama { get; set; }

        public string Deger { get; set; }

        public byte AlanTipi { get; set; }

        public int Ekleyen { get; set; }

        public DateTime EklemeTarihi { get; set; }

        public int Guncelleyen { get; set; }

        public DateTime GuncellemeTarihi { get; set; }

        internal static int InsertAyar(Ayar ayar)
        {
            try
            {
                string query = @"INSERT INTO [dbo].[AYARLAR]([Fk_AyarGrup],[Aciklama],[Deger],[AlanTipi],[Fk_Ekleyen],[Fk_Guncelleyen])
                                 VALUES(@AyarGrup,@Aciklama,@Deger,@AlanTipi,@Ekleyen,@Guncelleyen);
                                 SELECT @@IDENTITY";

                List<DinamikSqlParameter> parameters = new List<DinamikSqlParameter>();

                parameters.Add(new DinamikSqlParameter("@AyarGrup", ayar.AyarGrup));
                parameters.Add(new DinamikSqlParameter("@Aciklama", ayar.Aciklama));
                parameters.Add(new DinamikSqlParameter("@Deger", ayar.Deger));
                parameters.Add(new DinamikSqlParameter("@AlanTipi", ayar.AlanTipi));
                parameters.Add(new DinamikSqlParameter("@Ekleyen", ayar.Ekleyen));
                parameters.Add(new DinamikSqlParameter("@Guncelleyen", ayar.Guncelleyen));

                object objId = SqlHelper.GetScalarValue(query, parameters.ToArray());
                return objId == null || objId == DBNull.Value ? (int)0 : Convert.ToInt32(objId);
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("InsertAyar()", string.Format("HATA: {0}", ex.Message));
                throw ex;
            }
        }

        internal static void UpdateAyar(Ayar ayar)
        {
            try
            {
                string query = @"UPDATE [dbo].[AYARLAR]
                                 SET [Fk_AyarGrup]=@AyarGrup,[Aciklama]=@Aciklama,[Deger]=@Deger,[AlanTipi]=@AlanTipi,[Fk_Guncelleyen]=@Guncelleyen,[GuncellemeTarihi]=GETDATE()
                                 WHERE [AyarId]=@AyarId";

                List<DinamikSqlParameter> parameters = new List<DinamikSqlParameter>();

                parameters.Add(new DinamikSqlParameter("@AyarId", ayar.AyarId));
                parameters.Add(new DinamikSqlParameter("@AyarGrup", ayar.AyarGrup));
                parameters.Add(new DinamikSqlParameter("@Aciklama", ayar.Aciklama));
                parameters.Add(new DinamikSqlParameter("@Deger", ayar.Deger));
                parameters.Add(new DinamikSqlParameter("@AlanTipi", ayar.AlanTipi));
                parameters.Add(new DinamikSqlParameter("@Guncelleyen", ayar.Guncelleyen));

                SqlHelper.ExecuteNonQuery(query, parameters.ToArray());
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("UpdateAyar()", string.Format("HATA: {0}", ex.Message));
                throw ex;
            }
        }

        internal static void DeleteAyar(int ayarId)
        {
            try
            {
                string query = @"DELETE FROM [dbo].[AYARLAR] WHERE [AyarId]=@AyarId";

                SqlHelper.ExecuteNonQuery(query, new DinamikSqlParameter("@AyarId", ayarId));
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("DeleteAyar()", string.Format("HATA: {0}", ex.Message));
                throw ex;
            }
        }

        internal static Ayar GetAyarById(int ayarId)
        {
            SqlDataReader sqlDataReader = null;
            try
            {
                string query = @"SELECT [Fk_AyarGrup],[Aciklama],[Deger],[AlanTipi],[Fk_Ekleyen],[Fk_Guncelleyen],[EklemeTarihi],[GuncellemeTarihi],[AyarId] 
                                 FROM [dbo].[AYARLAR] 
                                 WHERE [AyarId]=@AyarId";

                sqlDataReader = SqlHelper.GetDataReader(query, new DinamikSqlParameter("@AyarId", ayarId));
                if (sqlDataReader.Read())
                {
                    Ayar obj = new Ayar();
                    obj.AyarId = Convert.ToInt32(sqlDataReader["AyarId"]);
                    obj.AyarGrup = Convert.ToInt32(sqlDataReader["Fk_AyarGrup"]);
                    obj.Aciklama = Convert.ToString(sqlDataReader["Aciklama"]);
                    obj.Deger = Convert.ToString(sqlDataReader["Deger"]);
                    obj.AlanTipi = Convert.ToByte(sqlDataReader["AlanTipi"]);
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
                CommonHelper.WriteLog("GetAyarById()", string.Format("HATA: {0}", ex.Message));
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

        internal static DataTable GetAyar()
        {
            DataTable dataTable = new DataTable();
            try
            {
                string query = @"SELECT [Fk_AyarGrup],[Aciklama],[Deger],[AlanTipi],[Fk_Ekleyen],[Fk_Guncelleyen],[EklemeTarihi],[GuncellemeTarihi],[AyarId] 
                                 FROM [dbo].[AYARLAR] ";

                dataTable = SqlHelper.GetDataTable(query);
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("GetAyar()", string.Format("HATA: {0}", ex.Message));
                throw ex;
            }
            return dataTable;
        }

        internal static DataTable GetAyar(string kolonAdi)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string query = @"SELECT [Fk_AyarGrup],[Aciklama],[Deger],[AlanTipi],[Fk_Ekleyen],[Fk_Guncelleyen],[EklemeTarihi],[GuncellemeTarihi],[AyarId] 
                                 FROM [dbo].[AYARLAR] ORDER BY " + kolonAdi;

                dataTable = SqlHelper.GetDataTable(query);
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("GetAyar()", string.Format("HATA: {0}", ex.Message));
                throw ex;
            }
            return dataTable;
        }

        internal static int InsertAyarByTransaction(Ayar ayar)
        {
            try
            {
                string query = @"INSERT INTO [dbo].[AYARLAR]([Fk_AyarGrup],[Aciklama],[Deger],[AlanTipi],[Fk_Ekleyen],[Fk_Guncelleyen])
                                 VALUES(@AyarGrup,@Aciklama,@Deger,@AlanTipi,@Ekleyen,@Guncelleyen);
                                 SELECT @@IDENTITY";

                List<DinamikSqlParameter> parameters = new List<DinamikSqlParameter>();

                parameters.Add(new DinamikSqlParameter("@AyarGrup", ayar.AyarGrup));
                parameters.Add(new DinamikSqlParameter("@Aciklama", ayar.Aciklama));
                parameters.Add(new DinamikSqlParameter("@Deger", ayar.Deger));
                parameters.Add(new DinamikSqlParameter("@AlanTipi", ayar.AlanTipi));
                parameters.Add(new DinamikSqlParameter("@Ekleyen", ayar.Ekleyen));
                parameters.Add(new DinamikSqlParameter("@Guncelleyen", ayar.Guncelleyen));

                object objId = SqlHelper.GetScalarValueByTransaction(query, parameters.ToArray());
                return objId == null || objId == DBNull.Value ? (int)0 : Convert.ToInt32(objId);
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("InsertAyarByTransaction()", string.Format("HATA: {0}", ex.Message));
                throw ex;
            }
        }

        internal static void UpdateAyarByTransaction(Ayar ayar)
        {
            try
            {
                string query = @"UPDATE [dbo].[AYARLAR]
                                 SET [Fk_AyarGrup]=@AyarGrup,[Aciklama]=@Aciklama,[Deger]=@Deger,[AlanTipi]=@AlanTipi,[Fk_Guncelleyen]=@Guncelleyen,[GuncellemeTarihi]=GETDATE()
                                 WHERE [AyarId]=@AyarId";

                List<DinamikSqlParameter> parameters = new List<DinamikSqlParameter>();

                parameters.Add(new DinamikSqlParameter("@AyarId", ayar.AyarId));
                parameters.Add(new DinamikSqlParameter("@AyarGrup", ayar.AyarGrup));
                parameters.Add(new DinamikSqlParameter("@Aciklama", ayar.Aciklama));
                parameters.Add(new DinamikSqlParameter("@Deger", ayar.Deger));
                parameters.Add(new DinamikSqlParameter("@AlanTipi", ayar.AlanTipi));
                parameters.Add(new DinamikSqlParameter("@Guncelleyen", ayar.Guncelleyen));

                SqlHelper.ExecuteNonQueryByTransaction(query, parameters.ToArray());
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("UpdateAyarByTransaction()", string.Format("HATA: {0}", ex.Message));
                throw ex;
            }
        }

        internal static void DeleteAyarByTransaction(int ayarId)
        {
            try
            {
                string query = @"DELETE FROM [dbo].[AYARLAR] WHERE [AyarId]=@AyarId";

                SqlHelper.ExecuteNonQueryByTransaction(query, new DinamikSqlParameter("@AyarId", ayarId));
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("DeleteAyarByTransaction()", string.Format("HATA: {0}", ex.Message));
                throw ex;
            }
        }

        internal static Ayar GetAyarByIdByTransaction(int ayarId)
        {
            SqlDataReader sqlDataReader = null;
            try
            {
                string query = @"SELECT [Fk_AyarGrup],[Aciklama],[Deger],[AlanTipi],[Fk_Ekleyen],[Fk_Guncelleyen],[EklemeTarihi],[GuncellemeTarihi],[AyarId] 
                                 FROM [dbo].[AYARLAR] 
                                 WHERE [AyarId]=@AyarId";

                sqlDataReader = SqlHelper.GetDataReaderByTransaction(query, new DinamikSqlParameter("@AyarId", ayarId));
                if (sqlDataReader.Read())
                {
                    Ayar obj = new Ayar();
                    obj.AyarId = Convert.ToInt32(sqlDataReader["AyarId"]);
                    obj.AyarGrup = Convert.ToInt32(sqlDataReader["Fk_AyarGrup"]);
                    obj.Aciklama = Convert.ToString(sqlDataReader["Aciklama"]);
                    obj.Deger = Convert.ToString(sqlDataReader["Deger"]);
                    obj.AlanTipi = Convert.ToByte(sqlDataReader["AlanTipi"]);
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
                CommonHelper.WriteLog("GetAyarByIdByTransaction()", string.Format("HATA: {0}", ex.Message));
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

        internal static List<Ayar> GetAyarByAyarGrup(int ayarGrup)
        {
            List<Ayar> returnValue = new List<Ayar>();
            SqlDataReader sqlDataReader = null;
            try
            {
                string query = @"SELECT [Fk_AyarGrup],[Aciklama],[Deger],[AlanTipi],[Fk_Ekleyen],[Fk_Guncelleyen],[EklemeTarihi],[GuncellemeTarihi],[AyarId] 
                                 FROM [dbo].[AYARLAR] 
                                 WHERE [Fk_AyarGrup]=@AyarGrup";

                sqlDataReader = SqlHelper.GetDataReader(query, new DinamikSqlParameter("@AyarGrup", ayarGrup));
                while (sqlDataReader.Read())
                {
                    Ayar obj = new Ayar();
                    obj.AyarId = Convert.ToInt32(sqlDataReader["AyarId"]);
                    obj.AyarGrup = Convert.ToInt32(sqlDataReader["Fk_AyarGrup"]);
                    obj.Aciklama = Convert.ToString(sqlDataReader["Aciklama"]);
                    obj.Deger = Convert.ToString(sqlDataReader["Deger"]);
                    obj.AlanTipi = Convert.ToByte(sqlDataReader["AlanTipi"]);
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
                CommonHelper.WriteLog("GetAyarByAyarGrup()", string.Format("HATA: {0}", ex.Message));
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

        internal static List<Ayar> GetAyarByAyarGrupByTransaction(int ayarGrup)
        {
            List<Ayar> returnValue = new List<Ayar>();
            SqlDataReader sqlDataReader = null;
            try
            {
                string query = @"SELECT [Fk_AyarGrup],[Aciklama],[Deger],[AlanTipi],[Fk_Ekleyen],[Fk_Guncelleyen],[EklemeTarihi],[GuncellemeTarihi],[AyarId] 
                                 FROM [dbo].[AYARLAR] 
                                 WHERE [Fk_AyarGrup]=@AyarGrup";

                sqlDataReader = SqlHelper.GetDataReaderByTransaction(query, new DinamikSqlParameter("@AyarGrup", ayarGrup));
                while (sqlDataReader.Read())
                {
                    Ayar obj = new Ayar();
                    obj.AyarId = Convert.ToInt32(sqlDataReader["AyarId"]);
                    obj.AyarGrup = Convert.ToInt32(sqlDataReader["Fk_AyarGrup"]);
                    obj.Aciklama = Convert.ToString(sqlDataReader["Aciklama"]);
                    obj.Deger = Convert.ToString(sqlDataReader["Deger"]);
                    obj.AlanTipi = Convert.ToByte(sqlDataReader["AlanTipi"]);
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
                CommonHelper.WriteLog("GetAyarByAyarGrupByTransaction()", string.Format("HATA: {0}", ex.Message));
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
