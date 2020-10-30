

using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using CafeRestaurantOtomasyonu.Classes;
using CafeRestaurantOtomasyonu.DataLayer;
using DevExpress.XtraEditors;
namespace CafeRestaurantOtomasyonu
{
    public partial class FrmKullaniciGirisi : DevExpress.XtraEditors.XtraForm
    {
        public FrmKullaniciGirisi()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            WaitingPanel.Show("Lütfen Bekleyiniz", "Giriş yapılıyor...");

            if (vpKullaniciDogrulama.Validate())
            {

                string sorgu = @"SELECT Sifre
                           FROM KULLANICI 
                           WHERE KullaniciAdi=@KullaniciAdi";

                object sifre = SqlHelper.GetScalarValue(sorgu,
                    new DinamikSqlParameter("@KullaniciAdi", txtKullaniciAdi.Text));
                string karisikSifre = Convert.ToString(sifre);

                if (karisikSifre == string.Empty)
                {
                    WaitingPanel.Hide();
                    XtraMessageBox.Show("Kullanıcı adı veya kullanıcı şifresi yanlış", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return;
                }

                bool dogru = BCrypt.CheckPassword(txtKullaniciSifre.Text, karisikSifre);


                if (dogru)
                {
                    try
                    {
                        string sorguAdmin = @" SELECT Durum
                           FROM KULLANICI 
                           WHERE KullaniciAdi=@KullaniciAdi";

                        object durum =
                            SqlHelper.GetScalarValue(sorguAdmin,
                                new DinamikSqlParameter("@KullaniciAdi", txtKullaniciAdi.Text));
                        if (Convert.ToBoolean(durum))
                        {
                            FrmAnaForm frmAnaForm = new FrmAnaForm();
                            frmAnaForm.Show();
                            Kullanici _kullanici = new Kullanici();
                            List<Kullanici> KULLANICI = Kullanici.GetKullaniciByKullaniciAdi(txtKullaniciAdi.Text);

                            _kullanici = KULLANICI[0];
                            MevcutKullanici.KullaniciId = _kullanici.KullaniciId;
                            MevcutKullanici.KullaniciAdi = _kullanici.KullaniciAdi;
                            MevcutKullanici.AdSoyad = _kullanici.AdSoyad;
                            MevcutKullanici.KullaniciSifre = _kullanici.Sifre;
                            MevcutKullanici.AdminKullanici = _kullanici.AdminKullanici;
                            MevcutKullanici.Durum = _kullanici.Durum;
                            this.Hide();


                           /* Yetki _yetki = new Yetki();
                            Yetki.KantarFisiKaydetme = CommonSqlOperations.YetkiGetirBoolean(1);
                            Yetki.KantarFisiIptalEtme = CommonSqlOperations.YetkiGetirBoolean(2);
                            Yetki.UretimFisiKaydetme = CommonSqlOperations.YetkiGetirBoolean(3);
                            Yetki.UretimFisiGuncelleme = CommonSqlOperations.YetkiGetirBoolean(4);
                            Yetki.UretimFisiGoruntuleme = CommonSqlOperations.YetkiGetirBoolean(5);
                            Yetki.YeniTanimEkleme = CommonSqlOperations.YetkiGetirBoolean(6);
                            Yetki.TanimGuncelleme = CommonSqlOperations.YetkiGetirBoolean(7);
                            Yetki.TanimSilme = CommonSqlOperations.YetkiGetirBoolean(8);
                            Yetki.HatirlatmaKapatma = CommonSqlOperations.YetkiGetirBoolean(9);
                            Yetki.AracveMakineIslemleri = CommonSqlOperations.YetkiGetirBoolean(10);
                            Yetki.RasyonKaydetme = CommonSqlOperations.YetkiGetirBoolean(11);
                            Yetki.RasyonGuncelleme = CommonSqlOperations.YetkiGetirBoolean(12);
                            Yetki.RasyonGoruntuleme = CommonSqlOperations.YetkiGetirBoolean(13);
                            this.Hide();*/

                            GirisLog _girisLog = new GirisLog();
                            _girisLog.Kullanici = MevcutKullanici.KullaniciId;
                            _girisLog.ProgramNo = Convert.ToByte(Enumerations.GirisLogTipi.AnaProgram);
                            _girisLog.GirisTarihi = DateTime.Now;
                            GirisLog.InsertGirisLog(_girisLog);

                                                    
                            
                        }
                        else
                        {
                            WaitingPanel.Hide();
                            XtraMessageBox.Show("Giriş yetkiniz bulunmamaktadır. Lütfen yöneticiye başvurunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        WaitingPanel.Hide();
                        CommonHelper.WriteLog("Yetki kontrolü", ex.Message);
                        XtraMessageBox.Show("Giriş yetkiniz bulunmamaktadır." + ex.Message, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                else
                {
                    WaitingPanel.Hide();
                    XtraMessageBox.Show("Kullanıcı adı veya kullanıcı şifresi yanlış", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                WaitingPanel.Hide();
                XtraMessageBox.Show("Boş bırakılamaz! Alanları kontrol ediniz! ", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            WaitingPanel.Hide();
        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtKullaniciAdi_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                txtKullaniciSifre.Focus();
            }
        }

        private void txtKullaniciSifre_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                btnGiris_Click(btnGiris, new EventArgs());
            }
        }

        private void FrmKullaniciGirisi_Shown(object sender, EventArgs e)
        {
            if (File.Exists("info.dat"))
            {
                UniqueValue uniqueValue = new UniqueValue();
                string userInfo = uniqueValue.EnDeCrypt(File.ReadAllText("info.dat"));

                string[] userInfoArr = userInfo.Split(new string[] { "^^^" }, StringSplitOptions.RemoveEmptyEntries);

                if (userInfoArr.Length >= 3 && userInfoArr[0] == uniqueValue.FingerPrintValue)
                {
                    txtKullaniciAdi.Text = userInfoArr[1];
                    txtKullaniciSifre.Text = userInfoArr[2];

                    btnGiris_Click(sender, e);

                    return;
                }
            }

            // otomatik giriş yapılamamışsa
            txtKullaniciAdi.Focus();
        }


    }
}