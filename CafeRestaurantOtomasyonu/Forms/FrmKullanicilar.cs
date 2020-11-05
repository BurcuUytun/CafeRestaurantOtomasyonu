using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using CafeRestaurantOtomasyonu.Classes;
using CafeRestaurantOtomasyonu.DataLayer;
using DevExpress.XtraEditors;

namespace CafeRestaurantOtomasyonu.Forms.CommonForms
{
    public partial class FrmKullanicilar : CustomXtraForm
    {
        string _sonKullaniciAdi;
        private Kullanici _kullanici = new Kullanici();
        private int _kullaniciId = 0;
        private bool _guncelle = false;
        private bool _kullaniciKartiGetiriliyor;

        public FrmKullanicilar()
        {
            InitializeComponent();
            FormuTemizle(false);
        }

        #region Functions

     private void KullaniciGetir(Enumerations.VeriGetirmeYontemi kullaniciGetirmeYontemi)
        {
            if (_kullaniciKartiGetiriliyor || Kapatiliyor)
                return;
            var kullaniciVar = Kullanici.KullaniciIdMevcutMu(txtKullaniciAdi.Text.Trim() == "" ? string.Empty : txtKullaniciAdi.Text.Trim());
            _kullaniciKartiGetiriliyor = true;
            bool degerlerFarkliMi =
                CommonHelper.DegerleriTagdanFarkliMi(layoutControlGroup2, new string[] { txtKullaniciAdi.Name });

            if (degerlerFarkliMi && kullaniciVar)
            {
                DialogResult soru = XtraMessageBox.Show("Kaydedilmeyen değişiklikler kaybolacak devam edilsin mi?",
                    "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (soru != DialogResult.Yes)
                {
                    if (ItemForKullaniciAdi.Control.Tag != null)
                        txtKullaniciAdi.Text = ItemForKullaniciAdi.Control.Tag.ToString();
                    _kullaniciKartiGetiriliyor = false;
                    return;
                }

            }
            SqlDataReader reader = null;
            if (kullaniciGetirmeYontemi == Enumerations.VeriGetirmeYontemi.Ad &&
                ((string.IsNullOrWhiteSpace(txtKullaniciAdi.Text.Trim()) || txtKullaniciAdi.Text.Trim() == _sonKullaniciAdi)
                && !degerlerFarkliMi))
            {
                _kullaniciKartiGetiriliyor = false;
                return;
            }
            else
            {
                try
                {
                    if (kullaniciGetirmeYontemi == Enumerations.VeriGetirmeYontemi.Id)
                    {
                        _kullanici = Kullanici.GetKullaniciById(_kullaniciId);
                        if (_kullanici == null)
                        {

                            _kullaniciKartiGetiriliyor = false;
                            return;
                        }

                    }
                    else if (kullaniciGetirmeYontemi == Enumerations.VeriGetirmeYontemi.Ad)
                    {
                        List<Kullanici> KULLANICI = Kullanici.GetKullaniciByKullaniciAdi(txtKullaniciAdi.Text.Trim());

                        if (KULLANICI.Count > 0)
                            _kullanici = KULLANICI[0];
                        else
                        {
                            if (_kullaniciId > 0)
                            {
                                FormuTemizle(true);
                            }

                            _sonKullaniciAdi = txtKullaniciAdi.Text.Trim();
                            _kullaniciKartiGetiriliyor = false;
                            return;
                        }
                    }
                    _kullaniciId = _kullanici.KullaniciId;
                    _sonKullaniciAdi = txtKullaniciAdi.Text = _kullanici.KullaniciAdi;
                    txtAdSoyad.Text = _kullanici.AdSoyad;
                    txtSifre.Text = "********";
                    txtSifre.ReadOnly = true;
                    chbSifreDegistir.Visible = true;
                    chbAdminKullanici.EditValue = _kullanici.AdminKullanici;
                    chbDurum.EditValue = _kullanici.Durum == 0 ? false : true;
                    CommonHelper.DegerleriTagaAl(layoutControlGroup2);

                    _guncelle = true;
                    btnSil.Enabled = true;
                }
                catch (Exception ex)
                {
                    CommonHelper.WriteLog("Kullanici Kartı Veri çekme", ex.Message);
                    XtraMessageBox.Show("Veritabanından veriler çekilemedi! " + ex.Message, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                    if (reader != null)
                    {
                        if (!reader.IsClosed)
                            reader.Close();
                        reader.Dispose();
                    }
                }
            }
            _kullaniciKartiGetiriliyor = false;
        }

        private void KullaniciListesiGetir(bool kullaniciAdi, string aramaMetni)
        {
            try
            {
                DataTable dataTable = Kullanici.KullaniciDetayiGetir(kullaniciAdi, aramaMetni);

                FrmList frmList = new FrmList("Kullanıcılar", dataTable, 440, "KullaniciId", string.Empty, 0);
                frmList.ShowDialog();

                if (frmList.ValueEntered)
                {
                    _kullaniciId = Convert.ToInt32(frmList.Value1);
                    KullaniciGetir(Enumerations.VeriGetirmeYontemi.Id);
                }
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("Kullanıcı Seçimi", ex.Message);
                XtraMessageBox.Show("Kullanıcı seçimi sırasında hata meydana geldi. " + ex.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void KaydetGuncelle()
        {
            if (!_guncelle)
            {
                if (vpDogrulama.Validate())
                {
                    try
                    {
                        _kullanici = new Kullanici();

                        string hashedSifre = BCrypt.HashPassword(txtSifre.Text.Trim(), BCrypt.GenerateSalt(12));
                        _kullanici.KullaniciAdi = txtKullaniciAdi.Text.Trim();
                        _kullanici.AdSoyad = txtAdSoyad.Text.Trim();
                        _kullanici.Sifre = hashedSifre;
                        _kullanici.AdminKullanici = chbAdminKullanici.Checked;
                        _kullanici.Durum = Convert.ToByte(chbDurum.Checked);
                        _kullanici.Ekleyen = MevcutKullanici.KullaniciId;
                        _kullanici.Guncelleyen = MevcutKullanici.KullaniciId;
                        _kullanici.KullaniciId = Kullanici.InsertKullanici(_kullanici);

                        XtraMessageBox.Show("Veritabanına ekleme işlemi başarılı!", "Uyarı", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        FormuTemizle(false);
                        _sonKullaniciAdi = "";
                    }

                    catch (Exception ex)
                    {
                        CommonHelper.WriteLog("Kullanici Kartı Veri Ekleme.", ex.Message);
                        XtraMessageBox.Show("Ekleme işlemi sırasında hata meydana geldi! " + ex.Message, "Uyarı",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    XtraMessageBox.Show("Boş bırakılamaz! Alanları kontrol ediniz! ", "Uyarı", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else
            {
                if (vpDogrulama.Validate())
                {
                    try
                    {
                        _kullanici = new Kullanici();
                        string hashedSifre = BCrypt.HashPassword(txtSifre.Text.Trim(), BCrypt.GenerateSalt(12));
                        _kullanici.KullaniciId = _kullaniciId;
                        _kullanici.KullaniciAdi = txtKullaniciAdi.Text.Trim();
                        _kullanici.AdSoyad = txtAdSoyad.Text.Trim();
                        _kullanici.AdminKullanici = chbAdminKullanici.Checked;
                        _kullanici.Durum = Convert.ToByte(chbDurum.Checked);
                        _kullanici.Guncelleyen = MevcutKullanici.KullaniciId;
                        if (chbSifreDegistir.Checked)
                        {
                            _kullanici.Sifre = hashedSifre;
                            Kullanici.UpdateKullanici(_kullanici);
                        }
                        else
                        {
                            Kullanici.UpdateKullaniciSifresiz(_kullanici);
                        }
                        XtraMessageBox.Show("Güncelleme işlemi başarılı! ", "Uyarı", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        FormuTemizle(false);
                        _sonKullaniciAdi = "";
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 2601)
                        {
                            CommonHelper.WriteLog("Veri değişimi", ex.Message);
                            XtraMessageBox.Show("Değişim yapılan veri zaten mevcut! " + ex.Message, "Uyarı",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                            XtraMessageBox.Show("Veriler veritabanında güncellenemedi! Hata: " + ex.Message, "Uyarı",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        CommonHelper.WriteLog("Kullanıcı Kartı Güncelleme.", ex.Message);
                        XtraMessageBox.Show("Ekleme işlemi sırasında hata meydana geldi! " + ex.Message, "Uyarı",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    XtraMessageBox.Show("Boş bırakılamaz! Alanları kontrol ediniz! ", "Uyarı", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        public override void Sil()
        {
            DialogResult sonuc = new DialogResult();
            sonuc = XtraMessageBox.Show("Verileri silmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (sonuc == DialogResult.No)
                return;
            else if (sonuc == DialogResult.Yes)
            {
                if (vpDogrulama.Validate())
                {
                    try
                    {

                        Kullanici.DeleteKullanici(_kullaniciId);

                        XtraMessageBox.Show("Veritabanından silme işlemi başarılı!  ", "Uyarı", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        FormuTemizle(false);
                        _sonKullaniciAdi = "";
                        _guncelle = false;
                    }

                    catch (Exception ex)
                    {
                        CommonHelper.WriteLog("Kullanici Kartı Veri Silme", ex.Message);
                        XtraMessageBox.Show("Silme işlemi sırasında hata meydana geldi! " + ex.Message, "Uyarı", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
                else
                {
                    XtraMessageBox.Show("Boş bırakılamaz! Alanları kontrol ediniz! ", "Uyarı", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        public override void Temizle(bool kodHaric)
        {
            DialogResult soru = DialogResult.Yes;

            if (CommonHelper.DegerleriTagdanFarkliMi(layoutControlGroup2))
            {
                soru = XtraMessageBox.Show("Kaydedilmeyen değişiklikler kaybolacak devam edilsin mi?", "Uyarı",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }

            if (soru == DialogResult.Yes)
            {
                FormuTemizle(kodHaric);
                _sonKullaniciAdi = "";
            }
            else
            {
                return;
            }

        }

        private void FormuTemizle(bool kodHaric)
        {
            _kullaniciId = 0;
            _sonKullaniciAdi = string.Empty;
            _kullanici = new Kullanici();
            _kullaniciKartiGetiriliyor = false;
            CommonHelper.AlanlariTemizle(layoutControlGroup2, kodHaric ? new string[] { txtKullaniciAdi.Name } : null);
            CommonHelper.DegerleriTagaAl(layoutControlGroup2);
            btnKaydet.Visible = true;
            btnYeni.Visible = true;
            btnSil.Enabled = false;
            _guncelle = false;
            txtSifre.ReadOnly = false;
            txtKullaniciAdi.Focus();
            chbAdminKullanici.CheckState = CheckState.Unchecked;
            chbDurum.CheckState = CheckState.Unchecked;
            chbSifreDegistir.CheckState = CheckState.Unchecked;
        }

        #endregion

        private void btnKaydet_Click(object sender, System.EventArgs e)
      {
            KaydetGuncelle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            Sil();
        }

        private void btnYeni_Click(object sender, System.EventArgs e)
        {
            Temizle(false);
        }

        private void chbSifreDegistir_CheckedChanged(object sender, EventArgs e)
        {
            if (chbSifreDegistir.Checked)
            {
                txtSifre.Text = string.Empty;
                txtSifre.ReadOnly = false;
            }
            else

                txtSifre.ReadOnly = true;

        }

        private void txtKullaniciAdi_Leave(object sender, EventArgs e)
        {
            KullaniciGetir(Enumerations.VeriGetirmeYontemi.Ad);
        }

        private void txtKullaniciAdi_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            KullaniciListesiGetir(true, txtKullaniciAdi.Text.Trim());
        }

        private void txtAdSoyad_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

            KullaniciListesiGetir(false, txtAdSoyad.Text.Trim());
        }
    }
}