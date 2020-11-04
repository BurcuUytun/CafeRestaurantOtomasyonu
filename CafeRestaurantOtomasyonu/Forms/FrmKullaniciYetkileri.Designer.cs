namespace CafeRestaurantOtomasyonu
{
    partial class FrmKullaniciYetkileri
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmKullaniciYetkileri));
            this.pnlButonlarAna = new DevExpress.XtraEditors.PanelControl();
            this.pnlButonlar = new DevExpress.XtraEditors.PanelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.pnlSecim = new DevExpress.XtraEditors.PanelControl();
            this.cmbUser = new DevExpress.XtraEditors.LookUpEdit();
            this.lblUser = new DevExpress.XtraEditors.LabelControl();
            this.gcDetails = new DevExpress.XtraGrid.GridControl();
            this.gvDetails = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clmAciklama = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmYetki = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtNumerikAlanN = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.chbBooleanAlan = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.txtNumerikAlan4 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.txtPassword = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlButonlarAna)).BeginInit();
            this.pnlButonlarAna.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlButonlar)).BeginInit();
            this.pnlButonlar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSecim)).BeginInit();
            this.pnlSecim.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumerikAlanN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chbBooleanAlan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumerikAlan4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlButonlarAna
            // 
            this.pnlButonlarAna.Controls.Add(this.pnlButonlar);
            this.pnlButonlarAna.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButonlarAna.Location = new System.Drawing.Point(0, 456);
            this.pnlButonlarAna.Name = "pnlButonlarAna";
            this.pnlButonlarAna.Size = new System.Drawing.Size(514, 55);
            this.pnlButonlarAna.TabIndex = 8;
            // 
            // pnlButonlar
            // 
            this.pnlButonlar.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlButonlar.Controls.Add(this.btnCancel);
            this.pnlButonlar.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlButonlar.Location = new System.Drawing.Point(390, 2);
            this.pnlButonlar.Name = "pnlButonlar";
            this.pnlButonlar.Size = new System.Drawing.Size(122, 51);
            this.pnlButonlar.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.ImageOptions.Image")));
            this.btnCancel.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnCancel.Location = new System.Drawing.Point(18, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 34);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Kapat";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pnlSecim
            // 
            this.pnlSecim.Controls.Add(this.cmbUser);
            this.pnlSecim.Controls.Add(this.lblUser);
            this.pnlSecim.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSecim.Location = new System.Drawing.Point(0, 0);
            this.pnlSecim.Name = "pnlSecim";
            this.pnlSecim.Size = new System.Drawing.Size(514, 45);
            this.pnlSecim.TabIndex = 0;
            // 
            // cmbUser
            // 
            this.cmbUser.Location = new System.Drawing.Point(64, 16);
            this.cmbUser.Name = "cmbUser";
            this.cmbUser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbUser.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("KullaniciAdi", "Kullanıcı Adı"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AdSoyad", "Ad Soyad")});
            this.cmbUser.Properties.DisplayMember = "AdSoyad";
            this.cmbUser.Properties.NullText = "Seçim Yapınız.";
            this.cmbUser.Properties.ValueMember = "KullaniciID";
            this.cmbUser.Size = new System.Drawing.Size(300, 20);
            this.cmbUser.TabIndex = 1;
            this.cmbUser.EditValueChanged += new System.EventHandler(this.cmbUser_EditValueChanged);
            // 
            // lblUser
            // 
            this.lblUser.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblUser.Appearance.Options.UseFont = true;
            this.lblUser.Location = new System.Drawing.Point(12, 19);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(46, 13);
            this.lblUser.TabIndex = 0;
            this.lblUser.Text = "Kullanıcı";
            // 
            // gcDetails
            // 
            this.gcDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDetails.Location = new System.Drawing.Point(0, 45);
            this.gcDetails.MainView = this.gvDetails;
            this.gcDetails.Name = "gcDetails";
            this.gcDetails.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.txtNumerikAlanN,
            this.chbBooleanAlan,
            this.txtNumerikAlan4,
            this.txtPassword});
            this.gcDetails.Size = new System.Drawing.Size(514, 411);
            this.gcDetails.TabIndex = 9;
            this.gcDetails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDetails});
            // 
            // gvDetails
            // 
            this.gvDetails.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvDetails.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gvDetails.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clmAciklama,
            this.clmYetki});
            this.gvDetails.GridControl = this.gcDetails;
            this.gvDetails.Name = "gvDetails";
            this.gvDetails.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvDetails.OptionsCustomization.AllowColumnMoving = false;
            this.gvDetails.OptionsCustomization.AllowFilter = false;
            this.gvDetails.OptionsCustomization.AllowGroup = false;
            this.gvDetails.OptionsCustomization.AllowQuickHideColumns = false;
            this.gvDetails.OptionsCustomization.AllowSort = false;
            this.gvDetails.OptionsView.ShowGroupPanel = false;
            this.gvDetails.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gvDetails_CustomRowCellEdit);
            this.gvDetails.CustomRowCellEditForEditing += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gvDetails_CustomRowCellEditForEditing);
            this.gvDetails.HiddenEditor += new System.EventHandler(this.gvDetails_HiddenEditor);
            // 
            // clmAciklama
            // 
            this.clmAciklama.Caption = "Açıklama";
            this.clmAciklama.FieldName = "Aciklama";
            this.clmAciklama.Name = "clmAciklama";
            this.clmAciklama.Visible = true;
            this.clmAciklama.VisibleIndex = 0;
            this.clmAciklama.Width = 423;
            // 
            // clmYetki
            // 
            this.clmYetki.Caption = "Yetki";
            this.clmYetki.FieldName = "Yetki";
            this.clmYetki.Name = "clmYetki";
            this.clmYetki.Visible = true;
            this.clmYetki.VisibleIndex = 1;
            this.clmYetki.Width = 100;
            // 
            // txtNumerikAlanN
            // 
            this.txtNumerikAlanN.AutoHeight = false;
            this.txtNumerikAlanN.Mask.BeepOnError = true;
            this.txtNumerikAlanN.Mask.EditMask = "N0";
            this.txtNumerikAlanN.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtNumerikAlanN.Mask.UseMaskAsDisplayFormat = true;
            this.txtNumerikAlanN.Name = "txtNumerikAlanN";
            // 
            // chbBooleanAlan
            // 
            this.chbBooleanAlan.AutoHeight = false;
            this.chbBooleanAlan.Name = "chbBooleanAlan";
            this.chbBooleanAlan.ValueChecked = "1";
            this.chbBooleanAlan.ValueUnchecked = "0";
            // 
            // txtNumerikAlan4
            // 
            this.txtNumerikAlan4.AutoHeight = false;
            this.txtNumerikAlan4.Mask.EditMask = "N4";
            this.txtNumerikAlan4.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtNumerikAlan4.Mask.UseMaskAsDisplayFormat = true;
            this.txtNumerikAlan4.Name = "txtNumerikAlan4";
            // 
            // txtPassword
            // 
            this.txtPassword.AutoHeight = false;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            // 
            // FrmKullaniciYetkileri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 511);
            this.Controls.Add(this.gcDetails);
            this.Controls.Add(this.pnlSecim);
            this.Controls.Add(this.pnlButonlarAna);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmKullaniciYetkileri";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kullanıcı Yetkileri";
            ((System.ComponentModel.ISupportInitialize)(this.pnlButonlarAna)).EndInit();
            this.pnlButonlarAna.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlButonlar)).EndInit();
            this.pnlButonlar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlSecim)).EndInit();
            this.pnlSecim.ResumeLayout(false);
            this.pnlSecim.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumerikAlanN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chbBooleanAlan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumerikAlan4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlButonlarAna;
        private DevExpress.XtraEditors.PanelControl pnlButonlar;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.PanelControl pnlSecim;
        private DevExpress.XtraEditors.LookUpEdit cmbUser;
        private DevExpress.XtraEditors.LabelControl lblUser;
        private DevExpress.XtraGrid.GridControl gcDetails;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDetails;
        private DevExpress.XtraGrid.Columns.GridColumn clmAciklama;
        private DevExpress.XtraGrid.Columns.GridColumn clmYetki;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtNumerikAlanN;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chbBooleanAlan;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtNumerikAlan4;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtPassword;
    }
}