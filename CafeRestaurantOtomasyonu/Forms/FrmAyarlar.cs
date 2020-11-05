using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using CafeRestaurantOtomasyonu.Classes;
using DevExpress.XtraEditors;
using DevExpress.XtraTab;

namespace CafeRestaurantOtomasyonu
{
    public partial class FrmAyarlar : DevExpress.XtraEditors.XtraForm
    {
        readonly UCAyarlar _ucAyarlar = new UCAyarlar();
        bool _bilgiGetirme = false;

        public FrmAyarlar()
        {
            InitializeComponent();
            _ucAyarlar.Dock = DockStyle.Fill;

            AyarGruplariniGetir();
        }

        private void AyarGruplariniGetir()
        {
            SqlDataReader reader = null;
            try
            {
                tabGenel.TabPages.Clear();

                string sorgu = @"SELECT * 
                                 FROM AYAR_GRUPLARI 
                                 ORDER BY AyarGrupId";

                reader = SqlHelper.GetDataReader(sorgu);

                _bilgiGetirme = true;

                while (reader.Read())
                {
                    XtraTabPage tabPage = new XtraTabPage();
                    tabPage.Text = reader["Aciklama"].ToString();
                    tabPage.Tag = reader["AyarGrupId"];
                    tabGenel.TabPages.Add(tabPage);
                }
                _bilgiGetirme = false;
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("Ayar Grupları Getirme", ex.Message);
                XtraMessageBox.Show("Ayarlar getirilirken hata meydana geldi. " + ex.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                {
                    reader.Close();
                }
            }
        }

        private void tabGenel_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            if (_bilgiGetirme || e.Page == null)
                return;

            byte ayarGrubu = Convert.ToByte(e.Page.Tag);
            e.Page.Controls.Add(_ucAyarlar);
            _ucAyarlar.GetSettings(ayarGrubu);

        }
        private void FrmAyarlar_Load(object sender, EventArgs e)
        {

            tabGenel_SelectedPageChanged(tabGenel, new TabPageChangedEventArgs(tabGenel.TabPages[1], tabGenel.TabPages[0]));
        }
    }
}