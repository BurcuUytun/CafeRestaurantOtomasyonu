namespace CafeRestaurantOtomasyonu
{
    partial class FrmAnaForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAnaForm));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.applicationMenu1 = new DevExpress.XtraBars.Ribbon.ApplicationMenu(this.components);
            this.btnCikis = new DevExpress.XtraBars.BarButtonItem();
            this.btnLisansAl = new DevExpress.XtraBars.BarButtonItem();
            this.btnHakkinda = new DevExpress.XtraBars.BarButtonItem();
            this.lblKullaniciBilgisi = new DevExpress.XtraBars.BarStaticItem();
            this.btnKullaniciTanimlama = new DevExpress.XtraBars.BarButtonItem();
            this.btnKullaniciYetkileri = new DevExpress.XtraBars.BarButtonItem();
            this.btnAyarlar = new DevExpress.XtraBars.BarButtonItem();
            this.rpAyarlarveTanimlamalar = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgTanimlamalar = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.tmrCtrlLic = new System.Windows.Forms.Timer(this.components);
            this.bntMasa = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ApplicationButtonDropDownControl = this.applicationMenu1;
            this.ribbon.ApplicationButtonImageOptions.Image = global::CafeRestaurantOtomasyonu.Properties.Resources.coffee;
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.ribbon.SearchEditItem,
            this.lblKullaniciBilgisi,
            this.btnCikis,
            this.btnLisansAl,
            this.btnHakkinda,
            this.btnKullaniciTanimlama,
            this.btnKullaniciYetkileri,
            this.btnAyarlar,
            this.bntMasa});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 10;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rpAyarlarveTanimlamalar});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2007;
            this.ribbon.ShowMoreCommandsButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.Size = new System.Drawing.Size(442, 143);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // applicationMenu1
            // 
            this.applicationMenu1.ItemLinks.Add(this.btnCikis);
            this.applicationMenu1.ItemLinks.Add(this.btnLisansAl);
            this.applicationMenu1.ItemLinks.Add(this.btnHakkinda);
            this.applicationMenu1.Name = "applicationMenu1";
            this.applicationMenu1.Ribbon = this.ribbon;
            // 
            // btnCikis
            // 
            this.btnCikis.Caption = "Çıkış";
            this.btnCikis.Id = 3;
            this.btnCikis.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCikis.ImageOptions.Image")));
            this.btnCikis.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnCikis.ImageOptions.LargeImage")));
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCikis_ItemClick);
            // 
            // btnLisansAl
            // 
            this.btnLisansAl.Caption = "Lisans Al";
            this.btnLisansAl.Id = 4;
            this.btnLisansAl.Name = "btnLisansAl";
            this.btnLisansAl.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLisansAl_ItemClick);
            // 
            // btnHakkinda
            // 
            this.btnHakkinda.Caption = "Hakkında";
            this.btnHakkinda.Id = 5;
            this.btnHakkinda.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnHakkinda.ImageOptions.Image")));
            this.btnHakkinda.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnHakkinda.ImageOptions.LargeImage")));
            this.btnHakkinda.Name = "btnHakkinda";
            this.btnHakkinda.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnHakkinda_ItemClick);
            // 
            // lblKullaniciBilgisi
            // 
            this.lblKullaniciBilgisi.Caption = "KULLANICI";
            this.lblKullaniciBilgisi.Id = 2;
            this.lblKullaniciBilgisi.Name = "lblKullaniciBilgisi";
            // 
            // btnKullaniciTanimlama
            // 
            this.btnKullaniciTanimlama.Caption = "Kullanıcı Tanımlama";
            this.btnKullaniciTanimlama.Id = 6;
            this.btnKullaniciTanimlama.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnKullaniciTanimlama.ImageOptions.Image")));
            this.btnKullaniciTanimlama.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnKullaniciTanimlama.ImageOptions.LargeImage")));
            this.btnKullaniciTanimlama.Name = "btnKullaniciTanimlama";
            this.btnKullaniciTanimlama.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnKullaniciTanimlama_ItemClick);
            // 
            // btnKullaniciYetkileri
            // 
            this.btnKullaniciYetkileri.Caption = "Kullanıcı Yetkileri";
            this.btnKullaniciYetkileri.Id = 7;
            this.btnKullaniciYetkileri.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnKullaniciYetkileri.ImageOptions.Image")));
            this.btnKullaniciYetkileri.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnKullaniciYetkileri.ImageOptions.LargeImage")));
            this.btnKullaniciYetkileri.Name = "btnKullaniciYetkileri";
            this.btnKullaniciYetkileri.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnKullaniciYetkileri_ItemClick);
            // 
            // btnAyarlar
            // 
            this.btnAyarlar.Caption = "Ayarlar";
            this.btnAyarlar.Id = 8;
            this.btnAyarlar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAyarlar.ImageOptions.Image")));
            this.btnAyarlar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnAyarlar.ImageOptions.LargeImage")));
            this.btnAyarlar.Name = "btnAyarlar";
            this.btnAyarlar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAyarlar_ItemClick);
            // 
            // rpAyarlarveTanimlamalar
            // 
            this.rpAyarlarveTanimlamalar.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgTanimlamalar});
            this.rpAyarlarveTanimlamalar.Name = "rpAyarlarveTanimlamalar";
            this.rpAyarlarveTanimlamalar.Text = "Ayarlar ve Tanımlamalar";
            // 
            // rpgTanimlamalar
            // 
            this.rpgTanimlamalar.ItemLinks.Add(this.btnKullaniciTanimlama);
            this.rpgTanimlamalar.ItemLinks.Add(this.btnKullaniciYetkileri);
            this.rpgTanimlamalar.ItemLinks.Add(this.btnAyarlar);
            this.rpgTanimlamalar.ItemLinks.Add(this.bntMasa);
            this.rpgTanimlamalar.Name = "rpgTanimlamalar";
            this.rpgTanimlamalar.Text = "Tanımlamalar";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.lblKullaniciBilgisi);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 418);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(442, 31);
            // 
            // tmrCtrlLic
            // 
            this.tmrCtrlLic.Interval = 60000;
            // 
            // bntMasa
            // 
            this.bntMasa.Caption = "Masa Tanıtım Kartı";
            this.bntMasa.Id = 9;
            this.bntMasa.Name = "bntMasa";
            this.bntMasa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bntMasa_ItemClick);
            // 
            // FrmAnaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 449);
            this.ControlBox = false;
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "FrmAnaForm";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "FrmAnaForm2";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.FrmAnaForm2_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpAyarlarveTanimlamalar;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgTanimlamalar;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.Ribbon.ApplicationMenu applicationMenu1;
        private DevExpress.XtraBars.BarStaticItem lblKullaniciBilgisi;
        private DevExpress.XtraBars.BarButtonItem btnCikis;
        private DevExpress.XtraBars.BarButtonItem btnLisansAl;
        private DevExpress.XtraBars.BarButtonItem btnHakkinda;
        private System.Windows.Forms.Timer tmrCtrlLic;
        private DevExpress.XtraBars.BarButtonItem btnKullaniciTanimlama;
        private DevExpress.XtraBars.BarButtonItem btnKullaniciYetkileri;
        private DevExpress.XtraBars.BarButtonItem btnAyarlar;
        private DevExpress.XtraBars.BarButtonItem bntMasa;
    }
}