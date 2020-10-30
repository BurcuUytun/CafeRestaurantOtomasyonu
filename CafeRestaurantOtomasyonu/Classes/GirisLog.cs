using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CafeRestaurantOtomasyonu.Classes;

namespace CafeRestaurantOtomasyonu.DataLayer
{
    public class GirisLog
    {
        public long LogId { get; set; }

        public int Kullanici { get; set; }

        public byte ProgramNo { get; set; }

        public DateTime GirisTarihi { get; set; }

        public static long InsertGirisLog(GirisLog girisLog)
        {
            try
            {
                string query = @"INSERT INTO [dbo].[GIRIS_LOG]([Fk_Kullanici],[ProgramNo],[GirisTarihi])
                                VALUES(@Kullanici,@ProgramNo,@GirisTarihi);
                                SELECT @@IDENTITY";

                List<DinamikSqlParameter> parameters = new List<DinamikSqlParameter>();

                parameters.Add(new DinamikSqlParameter("@Kullanici", girisLog.Kullanici));
                parameters.Add(new DinamikSqlParameter("@ProgramNo", girisLog.ProgramNo));
                parameters.Add(new DinamikSqlParameter("@GirisTarihi", girisLog.GirisTarihi));

                object objId = SqlHelper.GetScalarValue(query, parameters.ToArray());
                return objId == null || objId == DBNull.Value ? (long)0 : Convert.ToInt32(objId);
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("InsertGirisLog()", string.Format("HATA: {0}", ex.Message));
                throw ex;
            }
        }

        internal static void UpdateGirisLog(GirisLog girisLog)
        {
            try
            {
                string query = @"UPDATE [dbo].[GIRIS_LOG]
             SET [Fk_Kullanici]=@Kullanici,[ProgramNo]=@ProgramNo,[GirisTarihi]=@GirisTarihi
             WHERE [LogId]=@LogId";

                List<DinamikSqlParameter> parameters = new List<DinamikSqlParameter>();

                parameters.Add(new DinamikSqlParameter("@LogId", girisLog.LogId));
                parameters.Add(new DinamikSqlParameter("@Kullanici", girisLog.Kullanici));
                parameters.Add(new DinamikSqlParameter("@ProgramNo", girisLog.ProgramNo));
                parameters.Add(new DinamikSqlParameter("@GirisTarihi", girisLog.GirisTarihi));

                SqlHelper.ExecuteNonQuery(query, parameters.ToArray());
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("UpdateGirisLog()", string.Format("HATA: {0}", ex.Message));
                throw ex;
            }
        }

        internal static void DeleteGirisLog(long logId)
        {
            try
            {
                string query = @"DELETE FROM [dbo].[GIRIS_LOG] WHERE [LogId]=@LogId";

                SqlHelper.ExecuteNonQuery(query, new DinamikSqlParameter("@LogId", logId));
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("DeleteGirisLog()", string.Format("HATA: {0}", ex.Message));
                throw ex;
            }
        }

        internal static GirisLog GetGirisLogById(long logId)
        {
            SqlDataReader sqlDataReader = null;
            try
            {
                string query = @"SELECT [Fk_Kullanici],[ProgramNo],[GirisTarihi],[LogId] FROM [dbo].[GIRIS_LOG] WHERE [LogId]=@LogId";

                sqlDataReader = SqlHelper.GetDataReader(query, new DinamikSqlParameter("@LogId", logId));
                if (sqlDataReader.Read())
                {
                    GirisLog obj = new GirisLog();
                    obj.LogId = Convert.ToInt64(sqlDataReader["LogId"]);
                    obj.Kullanici = Convert.ToInt32(sqlDataReader["Fk_Kullanici"]);
                    obj.ProgramNo = Convert.ToByte(sqlDataReader["ProgramNo"]);
                    obj.GirisTarihi = Convert.ToDateTime(sqlDataReader["GirisTarihi"]);
                    return obj;
                }
                return null;
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("GetGirisLogById()", string.Format("HATA: {0}", ex.Message));
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

        internal static DataTable GetGirisLog()
        {
            DataTable dataTable = new DataTable();
            try
            {
                string query = @"SELECT [Fk_Kullanici],[ProgramNo],[GirisTarihi],[LogId] FROM [dbo].[GIRIS_LOG] ";

                dataTable = SqlHelper.GetDataTable(query);
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("GetGirisLog()", string.Format("HATA: {0}", ex.Message));
                throw ex;
            }
            return dataTable;
        }

        internal static DataTable GetGirisLog(string kolonAdi)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string query = @"SELECT [Fk_Kullanici],[ProgramNo],[GirisTarihi],[LogId] FROM [dbo].[GIRIS_LOG] ORDER BY " + kolonAdi;

                dataTable = SqlHelper.GetDataTable(query);
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("GetGirisLog()", string.Format("HATA: {0}", ex.Message));
                throw ex;
            }
            return dataTable;
        }

        public static long InsertGirisLogByTransaction(GirisLog girisLog)
        {
            try
            {
                string query = @"INSERT INTO [dbo].[GIRIS_LOG]([Fk_Kullanici],[ProgramNo],[GirisTarihi])
           VALUES(@Kullanici,@ProgramNo,@GirisTarihi);
           SELECT @@IDENTITY";

                List<DinamikSqlParameter> parameters = new List<DinamikSqlParameter>();

                parameters.Add(new DinamikSqlParameter("@Kullanici", girisLog.Kullanici));
                parameters.Add(new DinamikSqlParameter("@ProgramNo", girisLog.ProgramNo));
                parameters.Add(new DinamikSqlParameter("@GirisTarihi", girisLog.GirisTarihi));

                object objId = SqlHelper.GetScalarValueByTransaction(query, parameters.ToArray());
                return objId == null || objId == DBNull.Value ? (long)0 : Convert.ToInt32(objId);
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("InsertGirisLogByTransaction()", string.Format("HATA: {0}", ex.Message));
                throw ex;
            }
        }

        internal static void UpdateGirisLogByTransaction(GirisLog girisLog)
        {
            try
            {
                string query = @"UPDATE [dbo].[GIRIS_LOG]
           SET [Fk_Kullanici]=@Kullanici,[ProgramNo]=@ProgramNo,[GirisTarihi]=@GirisTarihi
           WHERE [LogId]=@LogId";

                List<DinamikSqlParameter> parameters = new List<DinamikSqlParameter>();

                parameters.Add(new DinamikSqlParameter("@LogId", girisLog.LogId));
                parameters.Add(new DinamikSqlParameter("@Kullanici", girisLog.Kullanici));
                parameters.Add(new DinamikSqlParameter("@ProgramNo", girisLog.ProgramNo));
                parameters.Add(new DinamikSqlParameter("@GirisTarihi", girisLog.GirisTarihi));

                SqlHelper.ExecuteNonQueryByTransaction(query, parameters.ToArray());
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("UpdateGirisLogByTransaction()", string.Format("HATA: {0}", ex.Message));
                throw ex;
            }
        }

        internal static void DeleteGirisLogByTransaction(long logId)
        {
            try
            {
                string query = @"DELETE FROM [dbo].[GIRIS_LOG] WHERE [LogId]=@LogId";

                SqlHelper.ExecuteNonQueryByTransaction(query, new DinamikSqlParameter("@LogId", logId));
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("DeleteGirisLogByTransaction()", string.Format("HATA: {0}", ex.Message));
                throw ex;
            }
        }

        internal static GirisLog GetGirisLogByIdByTransaction(long logId)
        {
            SqlDataReader sqlDataReader = null;
            try
            {
                string query = @"SELECT [Fk_Kullanici],[ProgramNo],[GirisTarihi],[LogId] FROM [dbo].[GIRIS_LOG] WHERE [LogId]=@LogId";

                sqlDataReader = SqlHelper.GetDataReaderByTransaction(query, new DinamikSqlParameter("@LogId", logId));
                if (sqlDataReader.Read())
                {
                    GirisLog obj = new GirisLog();
                    obj.LogId = Convert.ToInt64(sqlDataReader["LogId"]);
                    obj.Kullanici = Convert.ToInt32(sqlDataReader["Fk_Kullanici"]);
                    obj.ProgramNo = Convert.ToByte(sqlDataReader["ProgramNo"]);
                    obj.GirisTarihi = Convert.ToDateTime(sqlDataReader["GirisTarihi"]);
                    return obj;
                }
                return null;
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("GetGirisLogByIdByTransaction()", string.Format("HATA: {0}", ex.Message));
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

        internal static List<GirisLog> GetGirisLogByKullanici(int kullanici)
        {
            List<GirisLog> returnValue = new List<GirisLog>();
            SqlDataReader sqlDataReader = null;
            try
            {
                string query = @"SELECT [Fk_Kullanici],[ProgramNo],[GirisTarihi],[LogId] FROM [dbo].[GIRIS_LOG] WHERE [Fk_Kullanici]=@Kullanici";

                sqlDataReader = SqlHelper.GetDataReader(query, new DinamikSqlParameter("@Kullanici", kullanici));
                while (sqlDataReader.Read())
                {
                    GirisLog obj = new GirisLog();
                    obj.LogId = Convert.ToInt64(sqlDataReader["LogId"]);
                    obj.Kullanici = Convert.ToInt32(sqlDataReader["Fk_Kullanici"]);
                    obj.ProgramNo = Convert.ToByte(sqlDataReader["ProgramNo"]);
                    obj.GirisTarihi = Convert.ToDateTime(sqlDataReader["GirisTarihi"]);
                    returnValue.Add(obj);
                }
                return returnValue;
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("GetGirisLogByKullanici()", string.Format("HATA: {0}", ex.Message));
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

        internal static List<GirisLog> GetGirisLogByKullaniciByTransaction(int kullanici)
        {
            List<GirisLog> returnValue = new List<GirisLog>();
            SqlDataReader sqlDataReader = null;
            try
            {
                string query = @"SELECT [Fk_Kullanici],[ProgramNo],[GirisTarihi],[LogId] FROM [dbo].[GIRIS_LOG] WHERE [Fk_Kullanici]=@Kullanici";

                sqlDataReader = SqlHelper.GetDataReaderByTransaction(query, new DinamikSqlParameter("@Kullanici", kullanici));
                while (sqlDataReader.Read())
                {
                    GirisLog obj = new GirisLog();
                    obj.LogId = Convert.ToInt64(sqlDataReader["LogId"]);
                    obj.Kullanici = Convert.ToInt32(sqlDataReader["Fk_Kullanici"]);
                    obj.ProgramNo = Convert.ToByte(sqlDataReader["ProgramNo"]);
                    obj.GirisTarihi = Convert.ToDateTime(sqlDataReader["GirisTarihi"]);
                    returnValue.Add(obj);
                }
                return returnValue;
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("GetGirisLogByKullaniciByTransaction()", string.Format("HATA: {0}", ex.Message));
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