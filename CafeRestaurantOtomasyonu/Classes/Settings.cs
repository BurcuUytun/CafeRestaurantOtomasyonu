using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeRestaurantOtomasyonu.Classes
{
    public class Settings
    {
        public const string SeriNo = "mqRvukWgA3";
        public const string SeriNo2 = "9V4PGouQRj";
        public static short AppId = 10;
        public static string UpdateDir = Path.Combine(Application.StartupPath, "Updates");
        #region Private Static Variables
        // Uygulama içi ayarlar


        // Veritabanından gelen ayarlar
        private static string sirketIsmi = string.Empty;

        #endregion

        #region public Static Properties


        public static string SirketIsmi
        {
            get { return sirketIsmi; }
        }


        #endregion



        #region public Static Methods

        public static bool InitializeSettings()
        {
            try
            {

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ayarlar okunurken bir hata meydana geldi. Program kapatılacak.\nHata: " + ex.Message,
                                "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                CommonHelper.WriteLog("InitializeSettings()", string.Format("HATA: {0}", ex.Message));
                return false;
            }
        }

        public static bool VeritabaniAyarlariGetir()
        {
            try
            {
                sirketIsmi = SqlHelper.AyarGetir(1);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ayarlar okunurken bir hata meydana geldi. Program kapatılacak.\nHata: " + ex.Message,
                                "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                CommonHelper.WriteLog("VeritabaniAyarlariGetir()", string.Format("HATA: {0}", ex.Message));
                return false;
            }
        }

        #endregion

    }

    public struct SesDosyaYollari
    {
        public static string ButonClick = string.Concat(Application.StartupPath, "\\Sesler\\Buton_Click.wav");

        public static string EklemeYapildi = string.Concat(Application.StartupPath, "\\Sesler\\Ekleme_Yapildi.wav");

        public static string FiyatSifir = string.Concat(Application.StartupPath, "\\Sesler\\Fiyat_Sifir.wav");

        public static string Hata = string.Concat(Application.StartupPath, "\\Sesler\\Hata.wav");

        public static string KayitIptal = string.Concat(Application.StartupPath, "\\Sesler\\Kayit_Iptal.wav");

        public static string SatirSilindi = string.Concat(Application.StartupPath, "\\Sesler\\Satir_Silindi.wav");

        public static string UrunBulunamadi = string.Concat(Application.StartupPath, "\\Sesler\\Urun_Bulunamadi.wav");

        public static string UrunBulundu = string.Concat(Application.StartupPath, "\\Sesler\\Urun_Bulundu.wav");

        public static string UrunSecildi = string.Concat(Application.StartupPath, "\\Sesler\\Urun_Secildi.wav");
    }
    public enum AyarEnum
    {
        SirketIsmi = 1
    }
}
