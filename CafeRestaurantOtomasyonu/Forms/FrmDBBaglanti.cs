
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using CafeRestaurantOtomasyonu.Classes;
using DevExpress.XtraEditors;

namespace CafeRestaurantOtomasyonu
{
    public partial class FrmDBBaglanti : DevExpress.XtraEditors.XtraForm
    { /// <summary>
      /// 0: Dinamik, 1: Mikro
      /// </summary>
        byte dbType = 0;
        public FrmDBBaglanti(byte dbType)
        {
            InitializeComponent();
            this.dbType = dbType;

            string connStr = string.Empty;
            string explanation = string.Empty;

            if (dbType == 0)
            {
                connStr = SqlHelper.DinamikConnStr;
                //explanation = "Dinamik";
            }
            //grpParametreler.Text = string.Format(grpParametreler.Text, explanation);
            grpParametreler.Text = grpParametreler.Text;

            SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder(connStr);
                        
            txtSunucuAdi.Text = connectionStringBuilder.DataSource;
            txtVeritabani.Text = connectionStringBuilder.InitialCatalog;
            txtKullaniciAdi.Text = connectionStringBuilder.UserID;
            txtSifre.Text = connectionStringBuilder.Password;
        }

        private void btnKaydet_Click(object sender, System.EventArgs e)
        {
            try
            {
                string sunucuAdi = txtSunucuAdi.Text;
                string veritabani = txtVeritabani.Text;
                string kullaniciAdi = txtKullaniciAdi.Text;
                string sifre = txtSifre.Text;
                string masterConnectionString = string.Format("Data Source={0};Initial Catalog=master;User ID={1};Password={2};", sunucuAdi, kullaniciAdi, sifre);

                Boolean sonuc = SqlHelper.OpenMasterConn(masterConnectionString);

                if (sonuc)
                {
                    string connStr = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};", sunucuAdi, veritabani, kullaniciAdi, sifre);

                    bool connectionSuccessful = false;
                    string errorMessage;
                    if (dbType == 0)
                    {
                        SqlHelper.DinamikConnStr = connStr;
                    connectionSuccessful = SqlHelper.OpenDinamikConn(false, out errorMessage);

                        if (!connectionSuccessful && !string.IsNullOrWhiteSpace(errorMessage))
                        {
                            XtraMessageBox.Show("Bağlantı açılamadı. Hata: " + errorMessage, "Hata",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Bağlantı başarısız. ", "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bağlantı kaydedilemedi! " + ex.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVazgec_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }
    }
}