
using System;

namespace CafeRestaurantOtomasyonu.Classes
{
    public class MevcutKullanici
    {
        public MevcutKullanici()
        {
        }

        public static int KullaniciId { get; set; }

        public static string KullaniciAdi { get; set; }

        public static string KullaniciSifre { get; set; }

        public static string AdSoyad { get; set; }

        public static bool AdminKullanici { get; set; }

        public static byte Durum { get; set; }

    }
}
