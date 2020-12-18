namespace CafeRestaurantOtomasyonu.Forms.CommonForms
{
    partial class FrmMasaTanitimKarti
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMasaTanitimKarti));
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.txtMasaAdi = new DevExpress.XtraEditors.ButtonEdit();
            this.masaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtAciklama = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForMasaAdi = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForAciklama = new DevExpress.XtraLayout.LayoutControlItem();
            this.vpDogrulama = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnYeni = new DevExpress.XtraEditors.SimpleButton();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.btnSil = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMasaAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.masaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAciklama.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForMasaAdi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAciklama)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vpDogrulama)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.txtMasaAdi);
            this.dataLayoutControl1.Controls.Add(this.txtAciklama);
            this.dataLayoutControl1.DataSource = this.masaBindingSource;
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(533, 195, 942, 350);
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            this.dataLayoutControl1.Size = new System.Drawing.Size(496, 78);
            this.dataLayoutControl1.TabIndex = 0;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // txtMasaAdi
            // 
            this.txtMasaAdi.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.masaBindingSource, "MasaAdi", true));
            this.txtMasaAdi.Location = new System.Drawing.Point(58, 12);
            this.txtMasaAdi.Name = "txtMasaAdi";
            this.txtMasaAdi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F10), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.txtMasaAdi.Size = new System.Drawing.Size(426, 20);
            this.txtMasaAdi.StyleController = this.dataLayoutControl1;
            this.txtMasaAdi.TabIndex = 5;
            this.txtMasaAdi.Tag = "";
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "Boş Bırakılamaz.";
            this.vpDogrulama.SetValidationRule(this.txtMasaAdi, conditionValidationRule1);
            this.txtMasaAdi.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtMasaAdi_ButtonClick);
            this.txtMasaAdi.Leave += new System.EventHandler(this.txtMasaAdi_Leave);
            // 
            // masaBindingSource
            // 
            this.masaBindingSource.DataSource = typeof(CafeRestaurantOtomasyonu.DataLayer.Masa);
            // 
            // txtAciklama
            // 
            this.txtAciklama.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.masaBindingSource, "Aciklama", true));
            this.txtAciklama.Location = new System.Drawing.Point(58, 36);
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Size = new System.Drawing.Size(426, 20);
            this.txtAciklama.StyleController = this.dataLayoutControl1;
            this.txtAciklama.TabIndex = 6;
            this.txtAciklama.Tag = "";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(496, 78);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.AllowDrawBackground = false;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForMasaAdi,
            this.ItemForAciklama});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "autoGeneratedGroup0";
            this.layoutControlGroup2.Size = new System.Drawing.Size(476, 58);
            // 
            // ItemForMasaAdi
            // 
            this.ItemForMasaAdi.Control = this.txtMasaAdi;
            this.ItemForMasaAdi.CustomizationFormText = "Masa Adı";
            this.ItemForMasaAdi.Location = new System.Drawing.Point(0, 0);
            this.ItemForMasaAdi.Name = "ItemForMasaAdi";
            this.ItemForMasaAdi.Size = new System.Drawing.Size(476, 24);
            this.ItemForMasaAdi.Text = "Masa Adı";
            this.ItemForMasaAdi.TextSize = new System.Drawing.Size(43, 13);
            // 
            // ItemForAciklama
            // 
            this.ItemForAciklama.Control = this.txtAciklama;
            this.ItemForAciklama.CustomizationFormText = "Açıklama";
            this.ItemForAciklama.Location = new System.Drawing.Point(0, 24);
            this.ItemForAciklama.Name = "ItemForAciklama";
            this.ItemForAciklama.Size = new System.Drawing.Size(476, 34);
            this.ItemForAciklama.Text = "Açıklama";
            this.ItemForAciklama.TextSize = new System.Drawing.Size(43, 13);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.btnYeni, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnKaydet, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSil, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 78);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(496, 40);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // btnYeni
            // 
            this.btnYeni.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnYeni.Appearance.Options.UseFont = true;
            this.btnYeni.ImageOptions.Image = global::CafeRestaurantOtomasyonu.Properties.Resources.add_icon;
            this.btnYeni.Location = new System.Drawing.Point(199, 3);
            this.btnYeni.Name = "btnYeni";
            this.btnYeni.Size = new System.Drawing.Size(94, 34);
            this.btnYeni.TabIndex = 0;
            this.btnYeni.Text = "Yeni";
            this.btnYeni.Click += new System.EventHandler(this.btnYeni_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnKaydet.Appearance.Options.UseFont = true;
            this.btnKaydet.ImageOptions.Image = global::CafeRestaurantOtomasyonu.Properties.Resources.ok_icon;
            this.btnKaydet.Location = new System.Drawing.Point(299, 3);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(94, 34);
            this.btnKaydet.TabIndex = 1;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnSil
            // 
            this.btnSil.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSil.Appearance.Options.UseFont = true;
            this.btnSil.ImageOptions.Image = global::CafeRestaurantOtomasyonu.Properties.Resources.delete_icon;
            this.btnSil.Location = new System.Drawing.Point(399, 3);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(94, 34);
            this.btnSil.TabIndex = 2;
            this.btnSil.Text = "Sil";
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // FrmMasaTanitimKarti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 118);
            this.Controls.Add(this.dataLayoutControl1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMasaTanitimKarti";
            this.ShowIcon = false;
            this.Text = "Masa Tanıtım Kartı";
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtMasaAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.masaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAciklama.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForMasaAdi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAciklama)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vpDogrulama)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider vpDogrulama;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.ButtonEdit txtMasaAdi;
        private System.Windows.Forms.BindingSource masaBindingSource;
        private DevExpress.XtraEditors.TextEdit txtAciklama;
        private DevExpress.XtraLayout.LayoutControlItem ItemForMasaAdi;
        private DevExpress.XtraLayout.LayoutControlItem ItemForAciklama;
        private DevExpress.XtraEditors.SimpleButton btnYeni;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private DevExpress.XtraEditors.SimpleButton btnSil;
    }
}