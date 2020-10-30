namespace CafeRestaurantOtomasyonu
{
    partial class FrmDBBaglanti
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDBBaglanti));
            this.pnlButonlar = new DevExpress.XtraEditors.PanelControl();
            this.pnlButonlarSag = new DevExpress.XtraEditors.PanelControl();
            this.btnVazgec = new DevExpress.XtraEditors.SimpleButton();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.grpParametreler = new DevExpress.XtraEditors.GroupControl();
            this.txtSifre = new DevExpress.XtraEditors.TextEdit();
            this.txtKullaniciAdi = new DevExpress.XtraEditors.TextEdit();
            this.txtVeritabani = new DevExpress.XtraEditors.TextEdit();
            this.txtSunucuAdi = new DevExpress.XtraEditors.TextEdit();
            this.lblSifre = new DevExpress.XtraEditors.LabelControl();
            this.lblKullaniciAdi = new DevExpress.XtraEditors.LabelControl();
            this.lblVeritabani = new DevExpress.XtraEditors.LabelControl();
            this.lblSunucuAdi = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnlButonlar)).BeginInit();
            this.pnlButonlar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlButonlarSag)).BeginInit();
            this.pnlButonlarSag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpParametreler)).BeginInit();
            this.grpParametreler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSifre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKullaniciAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVeritabani.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSunucuAdi.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlButonlar
            // 
            this.pnlButonlar.Controls.Add(this.pnlButonlarSag);
            this.pnlButonlar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButonlar.Location = new System.Drawing.Point(0, 160);
            this.pnlButonlar.Name = "pnlButonlar";
            this.pnlButonlar.Size = new System.Drawing.Size(400, 46);
            this.pnlButonlar.TabIndex = 1;
            // 
            // pnlButonlarSag
            // 
            this.pnlButonlarSag.Controls.Add(this.btnVazgec);
            this.pnlButonlarSag.Controls.Add(this.btnKaydet);
            this.pnlButonlarSag.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlButonlarSag.Location = new System.Drawing.Point(184, 2);
            this.pnlButonlarSag.Name = "pnlButonlarSag";
            this.pnlButonlarSag.Size = new System.Drawing.Size(214, 42);
            this.pnlButonlarSag.TabIndex = 0;
            // 
            // btnVazgec
            // 
            this.btnVazgec.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnVazgec.Appearance.Options.UseFont = true;
            this.btnVazgec.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnVazgec.ImageOptions.Image")));
            this.btnVazgec.Location = new System.Drawing.Point(113, 3);
            this.btnVazgec.Name = "btnVazgec";
            this.btnVazgec.Size = new System.Drawing.Size(94, 34);
            this.btnVazgec.TabIndex = 1;
            this.btnVazgec.Text = "Vazgeç";
            this.btnVazgec.Click += new System.EventHandler(this.btnVazgec_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnKaydet.Appearance.Options.UseFont = true;
            this.btnKaydet.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnKaydet.ImageOptions.Image")));
            this.btnKaydet.Location = new System.Drawing.Point(13, 3);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(94, 34);
            this.btnKaydet.TabIndex = 0;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // grpParametreler
            // 
            this.grpParametreler.Controls.Add(this.txtSifre);
            this.grpParametreler.Controls.Add(this.txtKullaniciAdi);
            this.grpParametreler.Controls.Add(this.txtVeritabani);
            this.grpParametreler.Controls.Add(this.txtSunucuAdi);
            this.grpParametreler.Controls.Add(this.lblSifre);
            this.grpParametreler.Controls.Add(this.lblKullaniciAdi);
            this.grpParametreler.Controls.Add(this.lblVeritabani);
            this.grpParametreler.Controls.Add(this.lblSunucuAdi);
            this.grpParametreler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpParametreler.Location = new System.Drawing.Point(0, 0);
            this.grpParametreler.Name = "grpParametreler";
            this.grpParametreler.Size = new System.Drawing.Size(400, 160);
            this.grpParametreler.TabIndex = 0;
            this.grpParametreler.Text = "Lütfen veritabanı parametrelerini giriniz.";
            // 
            // txtSifre
            // 
            this.txtSifre.Location = new System.Drawing.Point(93, 111);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.Properties.MaxLength = 127;
            this.txtSifre.Properties.PasswordChar = '*';
            this.txtSifre.Size = new System.Drawing.Size(300, 20);
            this.txtSifre.TabIndex = 7;
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.Location = new System.Drawing.Point(93, 82);
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Properties.MaxLength = 127;
            this.txtKullaniciAdi.Size = new System.Drawing.Size(300, 20);
            this.txtKullaniciAdi.TabIndex = 5;
            // 
            // txtVeritabani
            // 
            this.txtVeritabani.Location = new System.Drawing.Point(93, 53);
            this.txtVeritabani.Name = "txtVeritabani";
            this.txtVeritabani.Properties.MaxLength = 127;
            this.txtVeritabani.Size = new System.Drawing.Size(300, 20);
            this.txtVeritabani.TabIndex = 3;
            // 
            // txtSunucuAdi
            // 
            this.txtSunucuAdi.Location = new System.Drawing.Point(93, 24);
            this.txtSunucuAdi.Name = "txtSunucuAdi";
            this.txtSunucuAdi.Properties.MaxLength = 127;
            this.txtSunucuAdi.Size = new System.Drawing.Size(300, 20);
            this.txtSunucuAdi.TabIndex = 1;
            // 
            // lblSifre
            // 
            this.lblSifre.Location = new System.Drawing.Point(13, 109);
            this.lblSifre.Name = "lblSifre";
            this.lblSifre.Size = new System.Drawing.Size(22, 13);
            this.lblSifre.TabIndex = 6;
            this.lblSifre.Text = "Şifre";
            // 
            // lblKullaniciAdi
            // 
            this.lblKullaniciAdi.Location = new System.Drawing.Point(13, 81);
            this.lblKullaniciAdi.Name = "lblKullaniciAdi";
            this.lblKullaniciAdi.Size = new System.Drawing.Size(55, 13);
            this.lblKullaniciAdi.TabIndex = 4;
            this.lblKullaniciAdi.Text = "Kullanıcı Adı";
            // 
            // lblVeritabani
            // 
            this.lblVeritabani.Location = new System.Drawing.Point(13, 53);
            this.lblVeritabani.Name = "lblVeritabani";
            this.lblVeritabani.Size = new System.Drawing.Size(48, 13);
            this.lblVeritabani.TabIndex = 2;
            this.lblVeritabani.Text = "Veritabanı";
            // 
            // lblSunucuAdi
            // 
            this.lblSunucuAdi.Location = new System.Drawing.Point(13, 25);
            this.lblSunucuAdi.Name = "lblSunucuAdi";
            this.lblSunucuAdi.Size = new System.Drawing.Size(53, 13);
            this.lblSunucuAdi.TabIndex = 0;
            this.lblSunucuAdi.Text = "Sunucu Adı";
            // 
            // FrmDBBaglanti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 206);
            this.Controls.Add(this.grpParametreler);
            this.Controls.Add(this.pnlButonlar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmDBBaglanti";
            this.Text = "Veritabanı Bağlantı Parametreleri";
            ((System.ComponentModel.ISupportInitialize)(this.pnlButonlar)).EndInit();
            this.pnlButonlar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlButonlarSag)).EndInit();
            this.pnlButonlarSag.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpParametreler)).EndInit();
            this.grpParametreler.ResumeLayout(false);
            this.grpParametreler.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSifre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKullaniciAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVeritabani.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSunucuAdi.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlButonlar;
        private DevExpress.XtraEditors.GroupControl grpParametreler;
        private DevExpress.XtraEditors.PanelControl pnlButonlarSag;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private DevExpress.XtraEditors.SimpleButton btnVazgec;
        private DevExpress.XtraEditors.TextEdit txtKullaniciAdi;
        private DevExpress.XtraEditors.TextEdit txtVeritabani;
        private DevExpress.XtraEditors.TextEdit txtSunucuAdi;
        private DevExpress.XtraEditors.LabelControl lblSifre;
        private DevExpress.XtraEditors.LabelControl lblKullaniciAdi;
        private DevExpress.XtraEditors.LabelControl lblVeritabani;
        private DevExpress.XtraEditors.LabelControl lblSunucuAdi;
        private DevExpress.XtraEditors.TextEdit txtSifre;
    }
}