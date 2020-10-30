using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using CafeRestaurantOtomasyonu.Classes;

namespace CafeRestaurantOtomasyonu
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                
                bool saveDbSettings = false;
                if (System.Diagnostics.Process
                        .GetProcessesByName(System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly
                            .GetEntryAssembly().Location)).Length > 1)
                {
                    MessageBox.Show("Uygulama daha önce çalıştırılmıştır.", "Uyarı",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Application.Exit();
                }
                else
                {
                    SqlHelper.BaglantiCumleleriAta();

                    if (!SqlHelper.OpenDinamikConn(false))
                    {

                        FrmDBBaglanti frmConnectionSetting = new FrmDBBaglanti(0);
                        frmConnectionSetting.ShowDialog();

                        saveDbSettings = true;
                    }
                    if (saveDbSettings)
                    {
                        SqlHelper.BaglantiCumleleriKaydet();
                    }


                    if (Settings.InitializeSettings() && CommonHelper.VeritabaniAyarlariGetir())
                    {
                        Application.Run(new FrmKullaniciGirisi());
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("Main", ex.Message);
                throw;
            }
        }
    }
}
