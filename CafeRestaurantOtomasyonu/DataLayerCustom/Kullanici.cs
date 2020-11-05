
using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CafeRestaurantOtomasyonu.Classes;
using CafeRestaurantOtomasyonu.DataLayer;
namespace CafeRestaurantOtomasyonu.DataLayerCustom
{
    public class Kullanici : DataLayer.Kullanici
    {
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
        internal static DataTable KullanicilariAl(bool pasifleriGoster)
        {
            DataTable kullanicilar = null;
            try
            {
                string sorgu = @"SELECT K.[KullaniciID],
                                        K.[KullaniciAdi],
                                        K.[Sifre],
                                        K.[AdSoyad],
                                        K.[AdminKullanici],
                                        K.[Durum],
                                        (SELECT MAX(GL.[GirisTarihi]) 
                                         FROM [GIRIS_LOG] GL
                                         WHERE GL.[Fk_Kullanici]=K.[KullaniciID]) SonGirisTarihi
                                 FROM [KULLANICI] K 
                                 WHERE K.[Durum]<>9 AND 
                                       ((@PasifleriGoster=0 AND K.[Durum]=1) OR (@PasifleriGoster=1))";

                kullanicilar = SqlHelper.GetDataTable(sorgu, new DinamikSqlParameter("@PasifleriGoster", pasifleriGoster));
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Kullanıcılar getirilirken hata meydana geldi.\nHata: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                CommonHelper.WriteLog("KullanicilariAl()", string.Format("HATA: {0}", ex.Message));
            }
            return kullanicilar;
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
    }
}
