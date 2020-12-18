using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using CafeRestaurantOtomasyonu.Classes;
using CafeRestaurantOtomasyonu.Forms;
using CafeRestaurantOtomasyonu.Forms.CommonForms;

namespace CafeRestaurantOtomasyonu
{
    public partial class FrmAnaForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FrmAnaForm()
        {
            InitializeComponent();
        }

        private void btnCikis_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void FrmAnaForm2_Shown(object sender, EventArgs e)
        {
            /*if (MevcutKullanici.AdminKullanici)
            {
                btnKullaniciYetkileri.Visibility = BarItemVisibility.Always;
                btnKullaniciTanimlama.Visibility = BarItemVisibility.Always;
                btnAyarlar.Visibility = BarItemVisibility.Always;
            }
            else
            {
                btnKullaniciYetkileri.Visibility = BarItemVisibility.Never;
                btnKullaniciTanimlama.Visibility = BarItemVisibility.Never;
                btnAyarlar.Visibility = BarItemVisibility.Never;

            }*/
            lblKullaniciBilgisi.Caption = string.Format("KULLANICI: {0}", MevcutKullanici.AdSoyad);
        }

        private void btnLisansAl_ItemClick(object sender, ItemClickEventArgs e)
        {
           /* if (UniqueValueOperations.ValueControl(false))
            {
                btnLisansAl.Visibility = BarItemVisibility.Never;
                tmrCtrlLic.Enabled = false;
            }*/
        }

        private void btnHakkinda_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmHakkinda frmHakkinda = new FrmHakkinda();
            frmHakkinda.ShowDialog();

        }

        private void btnKullaniciTanimlama_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form is FrmKullanicilar)
                {
                    form.Activate();
                    return;
                }
            }

            FrmKullanicilar frmKullanicilar = new FrmKullanicilar();
            frmKullanicilar.MdiParent = this;
            frmKullanicilar.Show();
        }

        private void btnKullaniciYetkileri_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form is FrmKullaniciYetkileri)
                {
                    form.Activate();
                    return;
                }
            }

            FrmKullaniciYetkileri frmKullaniciYetkileri = new FrmKullaniciYetkileri();
            frmKullaniciYetkileri.MdiParent = this;
            frmKullaniciYetkileri.Show();
        }

        private void btnAyarlar_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form is FrmAyarlar)
                {
                    form.Activate();
                    return;
                }
            }

            FrmAyarlar frmAyarlar = new FrmAyarlar();
            frmAyarlar.MdiParent = this;
            frmAyarlar.Show();
            frmAyarlar.WindowState = FormWindowState.Maximized;
        }

        private void bntMasa_ItemClick(object sender, ItemClickEventArgs e)
        {


            FrmMasaTanitimKarti frmMasaTanitimKarti = new FrmMasaTanitimKarti();
            frmMasaTanitimKarti.ShowDialog();
        }
    }
}