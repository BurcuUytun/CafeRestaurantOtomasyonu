using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace CafeRestaurantOtomasyonu.Forms.CommonForms
{
    public partial class FrmKullanicilar : DevExpress.XtraEditors.XtraForm
    {
        string _sonKullaniciAdi;
        private Kullanici _kullanici = new Kullanici();
        private int _kullaniciId = 0;
        private bool _guncelle = false;
        private bool _kullaniciKartiGetiriliyor;
        private string _personelKodu = string.Empty;
        private string _sonPersonelKodu = string.Empty;
        private bool _personelSecildi = false;

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
            var kullaniciVar = DataLayerCustom.Kullanici.KullaniciIdMevcutMu(txtKullaniciAdi.Text.Trim() == "" ? string.Empty : txtKullaniciAdi.Text.Trim());
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
                    txtMikroPersonelKodu.Text = _kullanici.MikroPersonelKodu;
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
                DataTable dataTable = DataLayerCustom.Kullanici.KullaniciDetayiGetir(kullaniciAdi, aramaMetni);

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
                        _kullanici.MikroPersonelKodu = txtMikroPersonelKodu.Text.Trim();
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
                        _kullanici.MikroPersonelKodu = txtMikroPersonelKodu.Text.Trim();
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
            _personelKodu = string.Empty; 
            _sonPersonelKodu = string.Empty;
            _personelSecildi = false;
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
            PersonelGetir(Enumerations.VeriGetirmeYontemi.Kod, true);
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

        private void txtMikroPersonelKodu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                string sorgu = @"SELECT cari_per_kod [Personel Kodu],
                                        cari_per_adi [Personel Adı]
                                 FROM CARI_PERSONEL_TANIMLARI 
                                 WHERE cari_per_kod LIKE @AramaMetni";

                DataTable dataTable  = CommonSqlOperations.GetDataTableMikro(sorgu, new DinamikSqlParameter("@AramaMetni", txtMikroPersonelKodu.Text.Trim().Replace('*', '%') + '%'));

                FrmList frmList = new FrmList("Personeller", dataTable, 440, "Personel Kodu", string.Empty);
                frmList.ShowDialog();

                if (frmList.ValueEntered)
                {
                    _personelKodu = Convert.ToString(frmList.Value1);
                    PersonelGetir(Enumerations.VeriGetirmeYontemi.Kod, false);
                }
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("Personel Seçimi", ex.Message);
                XtraMessageBox.Show("Personel seçimi sırasında hata meydana geldi. " + ex.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMikroPersonelKodu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PersonelGetir(Enumerations.VeriGetirmeYontemi.Kod, true);
            }
        }

        private void txtMikroPersonelKodu_Leave(object sender, EventArgs e)
        {

            PersonelGetir(Enumerations.VeriGetirmeYontemi.Kod, true);
        }


        private void PersonelGetir(Enumerations.VeriGetirmeYontemi personelGetirmeYontemi, bool textBox)
        {
            if (Kapatiliyor)
                return;

            SqlDataReader reader = null;
         
                try
                {
                    Personel personel = null;
                    if (personelGetirmeYontemi == Enumerations.VeriGetirmeYontemi.Kod)
                    {
                        List<Personel> personeller = Personel.GetPersonelByPersonelKodu(textBox ? txtMikroPersonelKodu.Text.Trim() : _personelKodu);

                        if (personeller.Count > 0)
                            personel = personeller[0];
                        else
                        {
                            if (_personelKodu != string.Empty || txtMikroPersonelKodu.Text.Trim() != string.Empty)
                            {
                                XtraMessageBox.Show("Hesap Bulunamadı.", "Uyarı", MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                                _personelKodu = string.Empty;
                                txtMikroPersonelKodu.Text = string.Empty;
                            }

                            _sonPersonelKodu = txtMikroPersonelKodu.Text.Trim();

                            return;
                        }
                    }
                    _personelKodu = _sonPersonelKodu = txtMikroPersonelKodu.Text = personel.PersonelKodu;

                    _personelSecildi = true;
                    PersonelKontrolu();
                }
                catch (Exception ex)
                {
                    CommonHelper.WriteLog("Personel Kartı Veri çekme", ex.Message);
                    XtraMessageBox.Show("Veritabanından veriler çekilemedi! " + ex.Message, "Uyarı",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        
        private void PersonelKontrolu()
        {
            if (!_personelSecildi)
            {
                XtraMessageBox.Show("Personel seçimi yapılmalıdır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtMikroPersonelKodu_TextChanged(object sender, EventArgs e)
        {
            _personelSecildi = false;
        }
    }
}