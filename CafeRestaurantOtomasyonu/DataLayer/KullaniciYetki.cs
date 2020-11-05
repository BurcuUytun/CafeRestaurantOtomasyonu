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
    public class KullaniciYetki
    {
        public int KullaniciYetkiID { get; set; }

        public int Kullanici { get; set; }

        public short YetkiTanimi { get; set; }

        public string Yetki { get; set; }

        internal static int InsertKullaniciYetki(KullaniciYetki kullaniciYetki)
        {
            try
            {
                string query = @"INSERT INTO [dbo].[KULLANICI_YETKILERI]([Fk_Kullanici],[Fk_YetkiTanimi],[Yetki])
                                 VALUES(@Kullanici,@YetkiTanimi,@Yetki);
                                 SELECT @@IDENTITY";

                List<DinamikSqlParameter> parameters = new List<DinamikSqlParameter>();

                parameters.Add(new DinamikSqlParameter("@Kullanici", kullaniciYetki.Kullanici));
                parameters.Add(new DinamikSqlParameter("@YetkiTanimi", kullaniciYetki.YetkiTanimi));
                parameters.Add(new DinamikSqlParameter("@Yetki", kullaniciYetki.Yetki));

                object objId = SqlHelper.GetScalarValue(query, parameters.ToArray());
                return objId == null || objId == DBNull.Value ? (int)0 : Convert.ToInt32(objId);
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("InsertKullaniciYetki()", string.Format("HATA: {0}", ex.Message));
                throw ex;
            }
        }

        internal static void UpdateKullaniciYetki(KullaniciYetki kullaniciYetki)
        {
            try
            {
                string query = @"UPDATE [dbo].[KULLANICI_YETKILERI]
                                 SET [Fk_Kullanici]=@Kullanici,[Fk_YetkiTanimi]=@YetkiTanimi,[Yetki]=@Yetki
                                 WHERE [KullaniciYetkiID]=@KullaniciYetkiID";

                List<DinamikSqlParameter> parameters = new List<DinamikSqlParameter>();

                parameters.Add(new DinamikSqlParameter("@KullaniciYetkiID", kullaniciYetki.KullaniciYetkiID));
                parameters.Add(new DinamikSqlParameter("@Kullanici", kullaniciYetki.Kullanici));
                parameters.Add(new DinamikSqlParameter("@YetkiTanimi", kullaniciYetki.YetkiTanimi));
                parameters.Add(new DinamikSqlParameter("@Yetki", kullaniciYetki.Yetki));

                SqlHelper.ExecuteNonQuery(query, parameters.ToArray());
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("UpdateKullaniciYetki()", string.Format("HATA: {0}", ex.Message));
                throw ex;
            }
        }

        internal static void DeleteKullaniciYetki(int kullaniciYetkiID)
        {
            try
            {
                string query = @"DELETE FROM [dbo].[KULLANICI_YETKILERI] WHERE [KullaniciYetkiID]=@KullaniciYetkiID";

                SqlHelper.ExecuteNonQuery(query, new DinamikSqlParameter("@KullaniciYetkiID", kullaniciYetkiID));
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("DeleteKullaniciYetki()", string.Format("HATA: {0}", ex.Message));
                throw ex;
            }
        }

        internal static KullaniciYetki GetKullaniciYetkiById(int kullaniciYetkiID)
        {
            SqlDataReader sqlDataReader = null;
            try
            {
                string query = @"SELECT [Fk_Kullanici],[Fk_YetkiTanimi],[Yetki],[KullaniciYetkiID] FROM [dbo].[KULLANICI_YETKILERI] WHERE [KullaniciYetkiID]=@KullaniciYetkiID";

                sqlDataReader = SqlHelper.GetDataReader(query, new DinamikSqlParameter("@KullaniciYetkiID", kullaniciYetkiID));
                if (sqlDataReader.Read())
                {
                    KullaniciYetki obj = new KullaniciYetki();
                    obj.KullaniciYetkiID = Convert.ToInt32(sqlDataReader["KullaniciYetkiID"]);
                    obj.Kullanici = Convert.ToInt32(sqlDataReader["Fk_Kullanici"]);
                    obj.YetkiTanimi = Convert.ToInt16(sqlDataReader["Fk_YetkiTanimi"]);
                    obj.Yetki = Convert.ToString(sqlDataReader["Yetki"]);
                    return obj;
                }
                return null;
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("GetKullaniciYetkiById()", string.Format("HATA: {0}", ex.Message));
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

        internal static DataTable GetKullaniciYetki()
        {
            DataTable dataTable = new DataTable();
            try
            {
                string query = @"SELECT [Fk_Kullanici],[Fk_YetkiTanimi],[Yetki],[KullaniciYetkiID] FROM [dbo].[KULLANICI_YETKILERI] ";

                dataTable = SqlHelper.GetDataTable(query);
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("GetKullaniciYetki()", string.Format("HATA: {0}", ex.Message));
                throw ex;
            }
            return dataTable;
        }

        internal static DataTable GetKullaniciYetki(string kolonAdi)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string query = @"SELECT [Fk_Kullanici],[Fk_YetkiTanimi],[Yetki],[KullaniciYetkiID] FROM [dbo].[KULLANICI_YETKILERI] ORDER BY " + kolonAdi;

                dataTable = SqlHelper.GetDataTable(query);
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("GetKullaniciYetki()", string.Format("HATA: {0}", ex.Message));
                throw ex;
            }
            return dataTable;
        }

        internal static int InsertKullaniciYetkiByTransaction(KullaniciYetki kullaniciYetki)
        {
            try
            {
                string query = @"INSERT INTO [dbo].[KULLANICI_YETKILERI]([Fk_Kullanici],[Fk_YetkiTanimi],[Yetki])
                                 VALUES(@Kullanici,@YetkiTanimi,@Yetki);
                                 SELECT @@IDENTITY";

                List<DinamikSqlParameter> parameters = new List<DinamikSqlParameter>();

                parameters.Add(new DinamikSqlParameter("@Kullanici", kullaniciYetki.Kullanici));
                parameters.Add(new DinamikSqlParameter("@YetkiTanimi", kullaniciYetki.YetkiTanimi));
                parameters.Add(new DinamikSqlParameter("@Yetki", kullaniciYetki.Yetki));

                object objId = SqlHelper.GetScalarValueByTransaction(query, parameters.ToArray());
                return objId == null || objId == DBNull.Value ? (int)0 : Convert.ToInt32(objId);
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("InsertKullaniciYetkiByTransaction()", string.Format("HATA: {0}", ex.Message));
                throw ex;
            }
        }

        internal static void UpdateKullaniciYetkiByTransaction(KullaniciYetki kullaniciYetki)
        {
            try
            {
                string query = @"UPDATE [dbo].[KULLANICI_YETKILERI]
                                 SET [Fk_Kullanici]=@Kullanici,[Fk_YetkiTanimi]=@YetkiTanimi,[Yetki]=@Yetki
                                 WHERE [KullaniciYetkiID]=@KullaniciYetkiID";

                List<DinamikSqlParameter> parameters = new List<DinamikSqlParameter>();

                parameters.Add(new DinamikSqlParameter("@KullaniciYetkiID", kullaniciYetki.KullaniciYetkiID));
                parameters.Add(new DinamikSqlParameter("@Kullanici", kullaniciYetki.Kullanici));
                parameters.Add(new DinamikSqlParameter("@YetkiTanimi", kullaniciYetki.YetkiTanimi));
                parameters.Add(new DinamikSqlParameter("@Yetki", kullaniciYetki.Yetki));

                SqlHelper.ExecuteNonQueryByTransaction(query, parameters.ToArray());
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("UpdateKullaniciYetkiByTransaction()", string.Format("HATA: {0}", ex.Message));
                throw ex;
            }
        }

        internal static void DeleteKullaniciYetkiByTransaction(int kullaniciYetkiID)
        {
            try
            {
                string query = @"DELETE FROM [dbo].[KULLANICI_YETKILERI] WHERE [KullaniciYetkiID]=@KullaniciYetkiID";

                SqlHelper.ExecuteNonQueryByTransaction(query, new DinamikSqlParameter("@KullaniciYetkiID", kullaniciYetkiID));
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("DeleteKullaniciYetkiByTransaction()", string.Format("HATA: {0}", ex.Message));
                throw ex;
            }
        }

        internal static KullaniciYetki GetKullaniciYetkiByIdByTransaction(int kullaniciYetkiID)
        {
            SqlDataReader sqlDataReader = null;
            try
            {
                string query = @"SELECT [Fk_Kullanici],[Fk_YetkiTanimi],[Yetki],[KullaniciYetkiID] FROM [dbo].[KULLANICI_YETKILERI] WHERE [KullaniciYetkiID]=@KullaniciYetkiID";

                sqlDataReader = SqlHelper.GetDataReaderByTransaction(query, new DinamikSqlParameter("@KullaniciYetkiID", kullaniciYetkiID));
                if (sqlDataReader.Read())
                {
                    KullaniciYetki obj = new KullaniciYetki();
                    obj.KullaniciYetkiID = Convert.ToInt32(sqlDataReader["KullaniciYetkiID"]);
                    obj.Kullanici = Convert.ToInt32(sqlDataReader["Fk_Kullanici"]);
                    obj.YetkiTanimi = Convert.ToInt16(sqlDataReader["Fk_YetkiTanimi"]);
                    obj.Yetki = Convert.ToString(sqlDataReader["Yetki"]);
                    return obj;
                }
                return null;
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("GetKullaniciYetkiByIdByTransaction()", string.Format("HATA: {0}", ex.Message));
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

        internal static List<KullaniciYetki> GetKullaniciYetkiByKullanici(int kullanici)
        {
            List<KullaniciYetki> returnValue = new List<KullaniciYetki>();
            SqlDataReader sqlDataReader = null;
            try
            {
                string query = @"SELECT [Fk_Kullanici],[Fk_YetkiTanimi],[Yetki],[KullaniciYetkiID] FROM [dbo].[KULLANICI_YETKILERI] WHERE [Fk_Kullanici]=@Kullanici";

                sqlDataReader = SqlHelper.GetDataReader(query, new DinamikSqlParameter("@Kullanici", kullanici));
                while (sqlDataReader.Read())
                {
                    KullaniciYetki obj = new KullaniciYetki();
                    obj.KullaniciYetkiID = Convert.ToInt32(sqlDataReader["KullaniciYetkiID"]);
                    obj.Kullanici = Convert.ToInt32(sqlDataReader["Fk_Kullanici"]);
                    obj.YetkiTanimi = Convert.ToInt16(sqlDataReader["Fk_YetkiTanimi"]);
                    obj.Yetki = Convert.ToString(sqlDataReader["Yetki"]);
                    returnValue.Add(obj);
                }
                return returnValue;
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("GetKullaniciYetkiByKullanici()", string.Format("HATA: {0}", ex.Message));
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

        internal static List<KullaniciYetki> GetKullaniciYetkiByKullaniciByTransaction(int kullanici)
        {
            List<KullaniciYetki> returnValue = new List<KullaniciYetki>();
            SqlDataReader sqlDataReader = null;
            try
            {
                string query = @"SELECT [Fk_Kullanici],[Fk_YetkiTanimi],[Yetki],[KullaniciYetkiID] FROM [dbo].[KULLANICI_YETKILERI] WHERE [Fk_Kullanici]=@Kullanici";

                sqlDataReader = SqlHelper.GetDataReaderByTransaction(query, new DinamikSqlParameter("@Kullanici", kullanici));
                while (sqlDataReader.Read())
                {
                    KullaniciYetki obj = new KullaniciYetki();
                    obj.KullaniciYetkiID = Convert.ToInt32(sqlDataReader["KullaniciYetkiID"]);
                    obj.Kullanici = Convert.ToInt32(sqlDataReader["Fk_Kullanici"]);
                    obj.YetkiTanimi = Convert.ToInt16(sqlDataReader["Fk_YetkiTanimi"]);
                    obj.Yetki = Convert.ToString(sqlDataReader["Yetki"]);
                    returnValue.Add(obj);
                }
                return returnValue;
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("GetKullaniciYetkiByKullaniciByTransaction()", string.Format("HATA: {0}", ex.Message));
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

        internal static List<KullaniciYetki> GetKullaniciYetkiByYetkiTanimi(short yetkiTanimi)
        {
            List<KullaniciYetki> returnValue = new List<KullaniciYetki>();
            SqlDataReader sqlDataReader = null;
            try
            {
                string query = @"SELECT [Fk_Kullanici],[Fk_YetkiTanimi],[Yetki],[KullaniciYetkiID] FROM [dbo].[KULLANICI_YETKILERI] WHERE [Fk_YetkiTanimi]=@YetkiTanimi";

                sqlDataReader = SqlHelper.GetDataReader(query, new DinamikSqlParameter("@YetkiTanimi", yetkiTanimi));
                while (sqlDataReader.Read())
                {
                    KullaniciYetki obj = new KullaniciYetki();
                    obj.KullaniciYetkiID = Convert.ToInt32(sqlDataReader["KullaniciYetkiID"]);
                    obj.Kullanici = Convert.ToInt32(sqlDataReader["Fk_Kullanici"]);
                    obj.YetkiTanimi = Convert.ToInt16(sqlDataReader["Fk_YetkiTanimi"]);
                    obj.Yetki = Convert.ToString(sqlDataReader["Yetki"]);
                    returnValue.Add(obj);
                }
                return returnValue;
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("GetKullaniciYetkiByYetkiTanimi()", string.Format("HATA: {0}", ex.Message));
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

        internal static List<KullaniciYetki> GetKullaniciYetkiByYetkiTanimiByTransaction(short yetkiTanimi)
        {
            List<KullaniciYetki> returnValue = new List<KullaniciYetki>();
            SqlDataReader sqlDataReader = null;
            try
            {
                string query = @"SELECT [Fk_Kullanici],[Fk_YetkiTanimi],[Yetki],[KullaniciYetkiID] FROM [dbo].[KULLANICI_YETKILERI] WHERE [Fk_YetkiTanimi]=@YetkiTanimi";

                sqlDataReader = SqlHelper.GetDataReaderByTransaction(query, new DinamikSqlParameter("@YetkiTanimi", yetkiTanimi));
                while (sqlDataReader.Read())
                {
                    KullaniciYetki obj = new KullaniciYetki();
                    obj.KullaniciYetkiID = Convert.ToInt32(sqlDataReader["KullaniciYetkiID"]);
                    obj.Kullanici = Convert.ToInt32(sqlDataReader["Fk_Kullanici"]);
                    obj.YetkiTanimi = Convert.ToInt16(sqlDataReader["Fk_YetkiTanimi"]);
                    obj.Yetki = Convert.ToString(sqlDataReader["Yetki"]);
                    returnValue.Add(obj);
                }
                return returnValue;
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("GetKullaniciYetkiByYetkiTanimiByTransaction()", string.Format("HATA: {0}", ex.Message));
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
