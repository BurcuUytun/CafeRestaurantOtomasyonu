using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CafeRestaurantOtomasyonu.Classes;

namespace CafeRestaurantOtomasyonu.DataLayer
{
    public class Kullanici
    {
        public int KullaniciId { get; set; }

        public string KullaniciAdi { get; set; }

        public string Sifre { get; set; }

        public string AdSoyad { get; set; }

        public bool AdminKullanici { get; set; }
        public int Ekleyen { get; set; }

        public DateTime EklemeTarihi { get; set; }

        public int Guncelleyen { get; set; }

        public DateTime GuncellemeTarihi { get; set; }

        public byte Durum { get; set; }

        public short HataliGirisSayisi { get; set; }

        internal static int InsertKullanici(Kullanici kullanici)
        {
            try
            {
                string query = @"INSERT INTO [dbo].[KULLANICI]([KullaniciAdi],[Sifre],[AdSoyad],[AdminKullanici],[Fk_Ekleyen],[Fk_Guncelleyen],
                                                               [Durum],[HataliGirisSayisi])
                                 VALUES(@KullaniciAdi,@Sifre,@AdSoyad,@AdminKullanici,@Ekleyen,@Guncelleyen,@Durum,@HataliGirisSayisi);
                                 SELECT @@IDENTITY";

                List<DinamikSqlParameter> parameters = new List<DinamikSqlParameter>();

                parameters.Add(new DinamikSqlParameter("@KullaniciAdi", kullanici.KullaniciAdi));
                parameters.Add(new DinamikSqlParameter("@Sifre", kullanici.Sifre));
                parameters.Add(new DinamikSqlParameter("@AdSoyad", kullanici.AdSoyad));
                parameters.Add(new DinamikSqlParameter("@AdminKullanici", kullanici.AdminKullanici));
                parameters.Add(new DinamikSqlParameter("@Ekleyen", kullanici.Ekleyen));
                parameters.Add(new DinamikSqlParameter("@Guncelleyen", kullanici.Guncelleyen));
                parameters.Add(new DinamikSqlParameter("@Durum", kullanici.Durum));
                parameters.Add(new DinamikSqlParameter("@HataliGirisSayisi", kullanici.HataliGirisSayisi));

                object objId = SqlHelper.GetScalarValue(query, parameters.ToArray());
                return objId == null || objId == DBNull.Value ? (int)0 : Convert.ToInt32(objId);
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("InsertKullanici()", string.Format("HATA: {0}", ex.Message));
                throw ex;
            }
        }

        internal static void UpdateKullanici(Kullanici kullanici)
        {
            try
            {
                string query = @"UPDATE [dbo].[KULLANICI]
                                SET [KullaniciAdi]=@KullaniciAdi,[Sifre]=@Sifre,[AdSoyad]=@AdSoyad,[AdminKullanici]=@AdminKullanici,
                                    [Fk_Guncelleyen]=@Guncelleyen,[Durum]=@Durum,[HataliGirisSayisi]=@HataliGirisSayisi,
                                    [GuncellemeTarihi]=GETDATE()
                                WHERE [KullaniciId]=@KullaniciId";

                List<DinamikSqlParameter> parameters = new List<DinamikSqlParameter>();

                parameters.Add(new DinamikSqlParameter("@KullaniciId", kullanici.KullaniciId));
                parameters.Add(new DinamikSqlParameter("@KullaniciAdi", kullanici.KullaniciAdi));
                parameters.Add(new DinamikSqlParameter("@Sifre", kullanici.Sifre));
                parameters.Add(new DinamikSqlParameter("@AdSoyad", kullanici.AdSoyad));
                parameters.Add(new DinamikSqlParameter("@AdminKullanici", kullanici.AdminKullanici));
                parameters.Add(new DinamikSqlParameter("@Guncelleyen", kullanici.Guncelleyen));
                parameters.Add(new DinamikSqlParameter("@Durum", kullanici.Durum));
                parameters.Add(new DinamikSqlParameter("@HataliGirisSayisi", kullanici.HataliGirisSayisi));

                SqlHelper.ExecuteNonQuery(query, parameters.ToArray());
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("UpdateKullanici()", string.Format("HATA: {0}", ex.Message));
                throw ex;
            }
        }

        internal static void DeleteKullanici(int kullaniciId)
        {
            try
            {
                string query = @"DELETE FROM [dbo].[KULLANICI] WHERE [KullaniciId]=@KullaniciId";

                SqlHelper.ExecuteNonQuery(query, new DinamikSqlParameter("@KullaniciId", kullaniciId));
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("DeleteKullanici()", string.Format("HATA: {0}", ex.Message));
                throw ex;
            }
        }

        internal static Kullanici GetKullaniciById(int kullaniciId)
        {
            SqlDataReader sqlDataReader = null;
            try
            {
                string query = @"SELECT [KullaniciAdi],[Sifre],[AdSoyad],[AdminKullanici],[Fk_Ekleyen],[Fk_Guncelleyen],[Durum],
                                        [HataliGirisSayisi],[EklemeTarihi],[GuncellemeTarihi],[KullaniciId] 
                                FROM [dbo].[KULLANICI] WHERE [KullaniciId]=@KullaniciId";

                sqlDataReader = SqlHelper.GetDataReader(query, new DinamikSqlParameter("@KullaniciId", kullaniciId));
                if (sqlDataReader.Read())
                {
                    Kullanici obj = new Kullanici();
                    obj.KullaniciId = Convert.ToInt32(sqlDataReader["KullaniciId"]);
                    obj.KullaniciAdi = Convert.ToString(sqlDataReader["KullaniciAdi"]);
                    obj.Sifre = Convert.ToString(sqlDataReader["Sifre"]);
                    obj.AdSoyad = Convert.ToString(sqlDataReader["AdSoyad"]);
                    obj.AdminKullanici = Convert.ToBoolean(sqlDataReader["AdminKullanici"]);
                    obj.Ekleyen = Convert.ToInt32(sqlDataReader["Fk_Ekleyen"]);
                    obj.EklemeTarihi = Convert.ToDateTime(sqlDataReader["EklemeTarihi"]);
                    obj.Guncelleyen = Convert.ToInt32(sqlDataReader["Fk_Guncelleyen"]);
                    obj.GuncellemeTarihi = Convert.ToDateTime(sqlDataReader["GuncellemeTarihi"]);
                    obj.Durum = Convert.ToByte(sqlDataReader["Durum"]);
                    obj.HataliGirisSayisi = Convert.ToInt16(sqlDataReader["HataliGirisSayisi"]);
                    return obj;
                }
                return null;
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("GetKullaniciById()", string.Format("HATA: {0}", ex.Message));
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

        internal static DataTable GetKullanici()
        {
            DataTable dataTable = new DataTable();
            try
            {
                string query = @"SELECT [KullaniciAdi],[Sifre],[AdSoyad],[AdminKullanici],[Fk_Ekleyen],[Fk_Guncelleyen],[Durum],
                                        [HataliGirisSayisi],[EklemeTarihi],[GuncellemeTarihi],[KullaniciId] 
                                 FROM [dbo].[KULLANICI] ";

                dataTable = SqlHelper.GetDataTable(query);
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("GetKullanici()", string.Format("HATA: {0}", ex.Message));
                throw ex;
            }
            return dataTable;
        }

        internal static DataTable GetKullanici(string kolonAdi)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string query = @"SELECT [KullaniciAdi],[Sifre],[AdSoyad],[AdminKullanici],[Fk_Ekleyen],[Fk_Guncelleyen],[Durum],
                                        [HataliGirisSayisi],[EklemeTarihi],[GuncellemeTarihi],[KullaniciId] 
                                 FROM [dbo].[KULLANICI] ORDER BY " + kolonAdi;

                dataTable = SqlHelper.GetDataTable(query);
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("GetKullanici()", string.Format("HATA: {0}", ex.Message));
                throw ex;
            }
            return dataTable;
        }

        internal static int InsertKullaniciByTransaction(Kullanici kullanici)
        {
            try
            {
                string query = @"INSERT INTO [dbo].[KULLANICI]([KullaniciAdi],[Sifre],[AdSoyad],[AdminKullanici],[Fk_Ekleyen],[Fk_Guncelleyen],
                                                               [Durum],[HataliGirisSayisi])
                                 VALUES(@KullaniciAdi,@Sifre,@AdSoyad,@AdminKullanici,@Ekleyen,@Guncelleyen,@Durum,@HataliGirisSayisi);
                                 SELECT @@IDENTITY";

                List<DinamikSqlParameter> parameters = new List<DinamikSqlParameter>();

                parameters.Add(new DinamikSqlParameter("@KullaniciAdi", kullanici.KullaniciAdi));
                parameters.Add(new DinamikSqlParameter("@Sifre", kullanici.Sifre));
                parameters.Add(new DinamikSqlParameter("@AdSoyad", kullanici.AdSoyad));
                parameters.Add(new DinamikSqlParameter("@AdminKullanici", kullanici.AdminKullanici));
                parameters.Add(new DinamikSqlParameter("@Ekleyen", kullanici.Ekleyen));
                parameters.Add(new DinamikSqlParameter("@Guncelleyen", kullanici.Guncelleyen));
                parameters.Add(new DinamikSqlParameter("@Durum", kullanici.Durum));
                parameters.Add(new DinamikSqlParameter("@HataliGirisSayisi", kullanici.HataliGirisSayisi));

                object objId = SqlHelper.GetScalarValueByTransaction(query, parameters.ToArray());
                return objId == null || objId == DBNull.Value ? (int)0 : Convert.ToInt32(objId);
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("InsertKullaniciByTransaction()", string.Format("HATA: {0}", ex.Message));
                throw ex;
            }
        }

        internal static void UpdateKullaniciByTransaction(Kullanici kullanici)
        {
            try
            {

                string query = @"UPDATE [dbo].[KULLANICI]
                                 SET [KullaniciAdi]=@KullaniciAdi,[Sifre]=@Sifre,[AdSoyad]=@AdSoyad,[AdminKullanici]=@AdminKullanici,
                                     [Fk_Guncelleyen]=@Guncelleyen,[Durum]=@Durum,[HataliGirisSayisi]=@HataliGirisSayisi,
                                     [GuncellemeTarihi]=GETDATE()
                                 WHERE [KullaniciId]=@KullaniciId";

                List<DinamikSqlParameter> parameters = new List<DinamikSqlParameter>();

                parameters.Add(new DinamikSqlParameter("@KullaniciId", kullanici.KullaniciId));
                parameters.Add(new DinamikSqlParameter("@KullaniciAdi", kullanici.KullaniciAdi));
                parameters.Add(new DinamikSqlParameter("@Sifre", kullanici.Sifre));
                parameters.Add(new DinamikSqlParameter("@AdSoyad", kullanici.AdSoyad));
                parameters.Add(new DinamikSqlParameter("@AdminKullanici", kullanici.AdminKullanici));
                parameters.Add(new DinamikSqlParameter("@Guncelleyen", kullanici.Guncelleyen));
                parameters.Add(new DinamikSqlParameter("@Durum", kullanici.Durum));
                parameters.Add(new DinamikSqlParameter("@HataliGirisSayisi", kullanici.HataliGirisSayisi));

                SqlHelper.ExecuteNonQueryByTransaction(query, parameters.ToArray());
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("UpdateKullaniciByTransaction()", string.Format("HATA: {0}", ex.Message));
                throw ex;
            }
        }

        internal static void DeleteKullaniciByTransaction(int kullaniciId)
        {
            try
            {
                string query = @"DELETE FROM [dbo].[KULLANICI] WHERE [KullaniciId]=@KullaniciId";

                SqlHelper.ExecuteNonQueryByTransaction(query, new DinamikSqlParameter("@KullaniciId", kullaniciId));
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("DeleteKullaniciByTransaction()", string.Format("HATA: {0}", ex.Message));
                throw ex;
            }
        }

        internal static Kullanici GetKullaniciByIdByTransaction(int kullaniciId)
        {
            SqlDataReader sqlDataReader = null;
            try
            {
                string query = @"SELECT [KullaniciAdi],[Sifre],[AdSoyad],[AdminKullanici],[Fk_Ekleyen],[Fk_Guncelleyen],[Durum],[HataliGirisSayisi],[EklemeTarihi],[GuncellemeTarihi],[KullaniciId] 
                                 FROM [dbo].[KULLANICI] WHERE [KullaniciId]=@KullaniciId";

                sqlDataReader = SqlHelper.GetDataReaderByTransaction(query, new DinamikSqlParameter("@KullaniciId", kullaniciId));
                if (sqlDataReader.Read())
                {
                    Kullanici obj = new Kullanici();
                    obj.KullaniciId = Convert.ToInt32(sqlDataReader["KullaniciId"]);
                    obj.KullaniciAdi = Convert.ToString(sqlDataReader["KullaniciAdi"]);
                    obj.Sifre = Convert.ToString(sqlDataReader["Sifre"]);
                    obj.AdSoyad = Convert.ToString(sqlDataReader["AdSoyad"]);
                    obj.AdminKullanici = Convert.ToBoolean(sqlDataReader["AdminKullanici"]);
                    obj.Ekleyen = Convert.ToInt32(sqlDataReader["Fk_Ekleyen"]);
                    obj.EklemeTarihi = Convert.ToDateTime(sqlDataReader["EklemeTarihi"]);
                    obj.Guncelleyen = Convert.ToInt32(sqlDataReader["Fk_Guncelleyen"]);
                    obj.GuncellemeTarihi = Convert.ToDateTime(sqlDataReader["GuncellemeTarihi"]);
                    obj.Durum = Convert.ToByte(sqlDataReader["Durum"]);
                    obj.HataliGirisSayisi = Convert.ToInt16(sqlDataReader["HataliGirisSayisi"]);
                    return obj;
                }
                return null;
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("GetKullaniciByIdByTransaction()", string.Format("HATA: {0}", ex.Message));
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

        public static List<Kullanici> GetKullaniciByKullaniciAdiByTransaction(string kullaniciAdi)
        {
            List<Kullanici> returnValue = new List<Kullanici>();
            SqlDataReader sqlDataReader = null;
            try
            {
                string query = @"SELECT [KullaniciAdi],[Sifre],[AdSoyad],[AdminKullanici],[Fk_Ekleyen],[Fk_Guncelleyen],[Durum],[HataliGirisSayisi],
                                        [EklemeTarihi],[GuncellemeTarihi],[KullaniciId] 
                                 FROM [dbo].[KULLANICI] 
                                 WHERE [KullaniciAdi]=@KullaniciAdi";

                sqlDataReader = SqlHelper.GetDataReaderByTransaction(query, new DinamikSqlParameter("@KullaniciAdi", kullaniciAdi));
                while (sqlDataReader.Read())
                {
                    Kullanici obj = new Kullanici();
                    obj.KullaniciId = Convert.ToInt32(sqlDataReader["KullaniciId"]);
                    obj.KullaniciAdi = Convert.ToString(sqlDataReader["KullaniciAdi"]);
                    obj.AdSoyad = Convert.ToString(sqlDataReader["AdSoyad"]);
                    obj.Sifre = Convert.ToString(sqlDataReader["Sifre"]);
                    obj.AdminKullanici = Convert.ToBoolean(sqlDataReader["AdminKullanici"]);
                    obj.Durum = Convert.ToByte(sqlDataReader["Durum"]);
                    obj.Ekleyen = Convert.ToInt32(sqlDataReader["Fk_Ekleyen"]);
                    obj.EklemeTarihi = Convert.ToDateTime(sqlDataReader["EklemeTarihi"]);
                    obj.Guncelleyen = Convert.ToInt32(sqlDataReader["Fk_Guncelleyen"]);
                    obj.HataliGirisSayisi = Convert.ToInt16(sqlDataReader["HataliGirisSayisi"]);
                    returnValue.Add(obj);
                }
                return returnValue;
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("GetCariKartByCariKoduByTransaction()", string.Format("HATA: {0}", ex.Message));
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

        public static List<Kullanici> GetKullaniciByKullaniciAdi(string kullaniciAdi)
        {
            List<Kullanici> returnValue = new List<Kullanici>();
            SqlDataReader sqlDataReader = null;
            try
            {
                string query = @"SELECT [KullaniciAdi],[Sifre],[AdSoyad],[AdminKullanici],[Fk_Ekleyen],[Fk_Guncelleyen],[Durum],[HataliGirisSayisi],
                                        [EklemeTarihi],[GuncellemeTarihi],[KullaniciId] 
                                 FROM [dbo].[KULLANICI] 
                                 WHERE [KullaniciAdi]=@KullaniciAdi";

                sqlDataReader = SqlHelper.GetDataReader(query, new DinamikSqlParameter("@KullaniciAdi", kullaniciAdi));
                while (sqlDataReader.Read())
                {
                    Kullanici obj = new Kullanici();
                    obj.KullaniciId = Convert.ToInt32(sqlDataReader["KullaniciId"]);
                    obj.KullaniciAdi = Convert.ToString(sqlDataReader["KullaniciAdi"]);
                    obj.AdSoyad = Convert.ToString(sqlDataReader["AdSoyad"]);
                    obj.Sifre = Convert.ToString(sqlDataReader["Sifre"]);
                    obj.AdminKullanici = Convert.ToBoolean(sqlDataReader["AdminKullanici"]);
                    obj.Durum = Convert.ToByte(sqlDataReader["Durum"]);
                    obj.Ekleyen = Convert.ToInt32(sqlDataReader["Fk_Ekleyen"]);
                    obj.EklemeTarihi = Convert.ToDateTime(sqlDataReader["EklemeTarihi"]);
                    obj.Guncelleyen = Convert.ToInt32(sqlDataReader["Fk_Guncelleyen"]);
                    obj.HataliGirisSayisi = Convert.ToInt16(sqlDataReader["HataliGirisSayisi"]);
                    returnValue.Add(obj);
                }
                return returnValue;
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("GetKullaniciByKullaniciAdi()", string.Format("HATA: {0}", ex.Message));
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

        public static void UpdateKullaniciSifresiz(Kullanici kullanici)
        {
            try
            {
                string query = @"UPDATE [dbo].[KULLANICI]
                                 SET [KullaniciAdi]=@KullaniciAdi,[AdSoyad]=@AdSoyad,[AdminKullanici]=@AdminKullanici,
                                     [Fk_Guncelleyen]=@Guncelleyen,[Durum]=@Durum,[HataliGirisSayisi]=@HataliGirisSayisi,[GuncellemeTarihi]=GETDATE()
                                 WHERE [KullaniciId]=@KullaniciId";

                List<DinamikSqlParameter> parameters = new List<DinamikSqlParameter>();

                parameters.Add(new DinamikSqlParameter("@KullaniciId", kullanici.KullaniciId));
                parameters.Add(new DinamikSqlParameter("@KullaniciAdi", kullanici.KullaniciAdi));
                parameters.Add(new DinamikSqlParameter("@AdSoyad", kullanici.AdSoyad));
                parameters.Add(new DinamikSqlParameter("@AdminKullanici", kullanici.AdminKullanici));
                parameters.Add(new DinamikSqlParameter("@Guncelleyen", kullanici.Guncelleyen));
                parameters.Add(new DinamikSqlParameter("@Durum", kullanici.Durum));
                parameters.Add(new DinamikSqlParameter("@HataliGirisSayisi", kullanici.HataliGirisSayisi));

                SqlHelper.ExecuteNonQuery(query, parameters.ToArray());
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("UpdateKullanici()", string.Format("HATA: {0}", ex.Message));
                throw ex;
            }
        }

        public static bool KullaniciIdMevcutMu(string kullaniciAdi)
        {
            try
            {

                string sorgu = @"SELECT KullaniciId
                                 FROM KULLANICI
                                 WHERE KullaniciAdi = @KullaniciAdi";

                object objkullaniciId = SqlHelper.GetScalarValue(sorgu,
                    new DinamikSqlParameter("@KullaniciAdi", kullaniciAdi));


                return (objkullaniciId != null && objkullaniciId != DBNull.Value) && Convert.ToInt32(objkullaniciId) > 0;
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("KullaniciIdMevcutMu", ex.Message);
                throw ex;
            }
        }
        public static DataTable KullaniciDetayiGetir(bool kullaniciAdi, string aramaMetni)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string sorgu = @"SELECT KullaniciId, KullaniciAdi [Kullanıcı Adı], AdSoyad [Ad Soyad]
                                 FROM KULLANICI 
                                 WHERE #KRITER# LIKE @AramaMetni";

                if (kullaniciAdi)
                {
                    sorgu = sorgu.Replace("#KRITER#", "KullaniciAdi");
                }
                else
                    sorgu = sorgu.Replace("#KRITER#", "AdSoyad");

                dataTable = SqlHelper.GetDataTable(sorgu, new DinamikSqlParameter("@AramaMetni", aramaMetni.Replace('*', '%') + '%'));
            }
            catch (Exception ex)
            {
                dataTable = null;

                CommonHelper.WriteLog("KullaniciDetayiGetir", ex.Message);
            }
            return dataTable;

        }
    }


}
