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
    public partial class FrmMasaTanitimKarti : CustomXtraForm
    {
        string _sonMasaAdi;
        private Masa _masa = new Masa();
        private int _masaId = 0;
        private bool _guncelle = false;
        private bool _masaGetiriliyor;

        public FrmMasaTanitimKarti()
        {
            InitializeComponent();
            FormuTemizle(false);
        }

        #region Functions

        private void MasaGetir(Enumerations.VeriGetirmeYontemi masaGetirmeYontemi)
        {
            if (_masaGetiriliyor || Kapatiliyor)
                return;
            var cariVar = DataLayerCustom.Masa.MasaIdMevcutMu(txtMasaAdi.Text == "" ? string.Empty : txtMasaAdi.Text);
            _masaGetiriliyor = true;
            bool degerlerFarkliMi =
                CommonHelper.DegerleriTagdanFarkliMi(layoutControlGroup2, new string[] { txtMasaAdi.Name });

            if (degerlerFarkliMi && cariVar)
            {
                DialogResult soru = XtraMessageBox.Show("Kaydedilmeyen değişiklikler kaybolacak devam edilsin mi?",
                    "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (soru != DialogResult.Yes)
                {
                    if (ItemForMasaAdi.Control.Tag != null)
                        txtMasaAdi.Text = ItemForMasaAdi.Control.Tag.ToString();
                    _masaGetiriliyor = false;
                    return;
                }

            }
            SqlDataReader reader = null;
            if (masaGetirmeYontemi == Enumerations.VeriGetirmeYontemi.Ad &&
                ((string.IsNullOrWhiteSpace(txtMasaAdi.Text) || txtMasaAdi.Text == _sonMasaAdi) && !degerlerFarkliMi))
            {
                _masaGetiriliyor = false;
                return;
            }
            else
            {
                try
                {
                    if (masaGetirmeYontemi == Enumerations.VeriGetirmeYontemi.Id)
                    {
                        _masa = Masa.GetMasaById(_masaId);
                        if (_masa == null)
                        {
                            _masaGetiriliyor = false;
                            return;
                        }

                    }
                    else if (masaGetirmeYontemi == Enumerations.VeriGetirmeYontemi.Ad)
                    {
                        List<Masa> masalar = Masa.GetMasaByMasaAdi(txtMasaAdi.Text.Trim());

                        if (masalar.Count > 0)
                            _masa = masalar[0];
                        else
                        {
                            if (_masaId > 0)
                            {
                                FormuTemizle(true);
                            }

                            _sonMasaAdi = txtMasaAdi.Text.Trim();
                            _masaGetiriliyor = false;
                            return;
                        }
                    }
                    _masaId = _masa.MasaId;
                    _sonMasaAdi = txtMasaAdi.Text = _masa.MasaAdi;
                    txtAciklama.Text = _masa.Aciklama;

                    CommonHelper.DegerleriTagaAl(layoutControlGroup2);

                    _guncelle = true;
                    btnSil.Enabled = true;
                }
                catch (Exception ex)
                {
                    CommonHelper.WriteLog("Masa Veri çekme", ex.Message);
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
            _masaGetiriliyor = false;
        }

        private void MasaListesiGetir(bool masaAsi, string aramaMetni)
        {
            try
            {
                DataTable dataTable = DataLayerCustom.Masa.MasaDetayiGetir(aramaMetni);

                FrmList frmList = new FrmList("Masalar", dataTable, 440, "MasaId", string.Empty, 0);
                frmList.ShowDialog();

                if (frmList.ValueEntered)
                {
                    _masaId = Convert.ToInt32(frmList.Value1);
                    MasaGetir(Enumerations.VeriGetirmeYontemi.Id);
                }
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("Masa Seçimi", ex.Message);
                XtraMessageBox.Show("Masa seçimi sırasında hata meydana geldi. " + ex.Message, "Hata",
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
                        _masa = new Masa();
                        _masa.MasaAdi = txtMasaAdi.Text.Trim();
                        _masa.Aciklama = txtAciklama.Text.Trim();
                        _masa.Ekleyen = MevcutKullanici.KullaniciId;
                        _masa.Guncelleyen = MevcutKullanici.KullaniciId;
                        _masa.MasaId = Masa.InsertMasa(_masa);

                        XtraMessageBox.Show("Veritabanına ekleme işlemi başarılı!", "Uyarı", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        FormuTemizle(false);
                        _sonMasaAdi = "";
                    }

                    catch (Exception ex)
                    {
                        CommonHelper.WriteLog("Masa Veri Ekleme.", ex.Message);
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
                        _masa = new Masa();
                        _masa.MasaId = _masaId;
                        _masa.MasaAdi = txtMasaAdi.Text.Trim();
                        _masa.Aciklama = txtAciklama.Text.Trim();
                        _masa.Ekleyen = MevcutKullanici.KullaniciId;
                        _masa.Guncelleyen = MevcutKullanici.KullaniciId;
                        Masa.UpdateMasa(_masa);

                        XtraMessageBox.Show("Güncelleme işlemi başarılı! ", "Uyarı", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        FormuTemizle(false);
                        _sonMasaAdi = "";
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
                        CommonHelper.WriteLog("Masa Güncelleme.", ex.Message);
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

                        Masa.DeleteMasa(_masaId);

                        XtraMessageBox.Show("Veritabanından silme işlemi başarılı!  ", "Uyarı", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        FormuTemizle(false);
                        _sonMasaAdi = "";
                        _guncelle = false;
                    }

                    catch (Exception ex)
                    {
                        CommonHelper.WriteLog("Masa Veri Silme", ex.Message);
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
                _sonMasaAdi = "";
            }
            else
            {
                return;
            }
        }

        private void FormuTemizle(bool kodHaric)
        {
            _masaId = 0;
            _sonMasaAdi = string.Empty;
            _masa = new Masa();
            _masaGetiriliyor = false;
            CommonHelper.AlanlariTemizle(layoutControlGroup2,
                kodHaric ? new string[] { txtMasaAdi.Name } : null);
            CommonHelper.DegerleriTagaAl(layoutControlGroup2);
            btnKaydet.Visible = true;
            btnYeni.Visible = true;
            btnSil.Enabled = false;
            _guncelle = false;
            txtMasaAdi.Focus();
        }
        
        #endregion
        private void txtMasaAdi_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            MasaListesiGetir(true, txtMasaAdi.Text);
        }
        private void txtMasaAdi_Leave(object sender, EventArgs e)
        {
            MasaGetir(Enumerations.VeriGetirmeYontemi.Ad);
        }

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

    }
}