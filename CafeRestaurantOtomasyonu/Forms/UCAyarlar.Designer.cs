namespace CafeRestaurantOtomasyonu
{
    partial class UCAyarlar
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gcSettings = new DevExpress.XtraGrid.GridControl();
            this.gvSettings = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clmAciklama = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmDeger = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtNumerikAlanN = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.chbBooleanAlan = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.txtNumerikAlanN4 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.txtPassword = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.cmbComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.cmbComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.cmbComboBox3 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.cmbComboBox4 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.cmbComboBox5 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.cmbComboBox6 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.cmbComboBox7 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.cmbComboBox8 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.cmbComboBox9 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.cmbComboBox10 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.txtYaziciYolu = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.txtDosyaYolu = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.txtKlasorYolu = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumerikAlanN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chbBooleanAlan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumerikAlanN4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbComboBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbComboBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbComboBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbComboBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbComboBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbComboBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbComboBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbComboBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbComboBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYaziciYolu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDosyaYolu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKlasorYolu)).BeginInit();
            this.SuspendLayout();
            // 
            // gcSettings
            // 
            this.gcSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcSettings.Location = new System.Drawing.Point(0, 0);
            this.gcSettings.MainView = this.gvSettings;
            this.gcSettings.Name = "gcSettings";
            this.gcSettings.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.txtNumerikAlanN,
            this.chbBooleanAlan,
            this.txtNumerikAlanN4,
            this.txtPassword,
            this.cmbComboBox1,
            this.cmbComboBox2,
            this.cmbComboBox3,
            this.cmbComboBox4,
            this.cmbComboBox5,
            this.cmbComboBox6,
            this.cmbComboBox7,
            this.cmbComboBox8,
            this.cmbComboBox9,
            this.cmbComboBox10,
            this.txtYaziciYolu,
            this.txtDosyaYolu,
            this.txtKlasorYolu});
            this.gcSettings.Size = new System.Drawing.Size(731, 593);
            this.gcSettings.TabIndex = 3;
            this.gcSettings.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSettings});
            // 
            // gvSettings
            // 
            this.gvSettings.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clmAciklama,
            this.clmDeger});
            this.gvSettings.GridControl = this.gcSettings;
            this.gvSettings.Name = "gvSettings";
            this.gvSettings.OptionsCustomization.AllowColumnMoving = false;
            this.gvSettings.OptionsView.ShowGroupPanel = false;
            this.gvSettings.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gvSettings_CustomRowCellEdit);
            this.gvSettings.CustomRowCellEditForEditing += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gvSettings_CustomRowCellEditForEditing);
            this.gvSettings.HiddenEditor += new System.EventHandler(this.gvSettings_HiddenEditor);
            // 
            // clmAciklama
            // 
            this.clmAciklama.Caption = "Açıklama";
            this.clmAciklama.FieldName = "Aciklama";
            this.clmAciklama.Name = "clmAciklama";
            this.clmAciklama.OptionsColumn.AllowFocus = false;
            this.clmAciklama.Visible = true;
            this.clmAciklama.VisibleIndex = 0;
            this.clmAciklama.Width = 255;
            // 
            // clmDeger
            // 
            this.clmDeger.Caption = "Değer";
            this.clmDeger.FieldName = "Deger";
            this.clmDeger.Name = "clmDeger";
            this.clmDeger.Visible = true;
            this.clmDeger.VisibleIndex = 1;
            this.clmDeger.Width = 171;
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
            // txtNumerikAlanN4
            // 
            this.txtNumerikAlanN4.AutoHeight = false;
            this.txtNumerikAlanN4.Mask.EditMask = "N4";
            this.txtNumerikAlanN4.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtNumerikAlanN4.Mask.UseMaskAsDisplayFormat = true;
            this.txtNumerikAlanN4.Name = "txtNumerikAlanN4";
            // 
            // txtPassword
            // 
            this.txtPassword.AutoHeight = false;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            // 
            // cmbComboBox1
            // 
            this.cmbComboBox1.AutoHeight = false;
            this.cmbComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbComboBox1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Aciklama", "Seçim")});
            this.cmbComboBox1.DisplayMember = "Aciklama";
            this.cmbComboBox1.Name = "cmbComboBox1";
            this.cmbComboBox1.ValueMember = "Id";
            // 
            // cmbComboBox2
            // 
            this.cmbComboBox2.AutoHeight = false;
            this.cmbComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbComboBox2.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Aciklama", "Seçim")});
            this.cmbComboBox2.DisplayMember = "Aciklama";
            this.cmbComboBox2.Name = "cmbComboBox2";
            this.cmbComboBox2.ValueMember = "Id";
            // 
            // cmbComboBox3
            // 
            this.cmbComboBox3.AutoHeight = false;
            this.cmbComboBox3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbComboBox3.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Aciklama", "Seçim")});
            this.cmbComboBox3.DisplayMember = "Aciklama";
            this.cmbComboBox3.Name = "cmbComboBox3";
            this.cmbComboBox3.ValueMember = "Id";
            // 
            // cmbComboBox4
            // 
            this.cmbComboBox4.AutoHeight = false;
            this.cmbComboBox4.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbComboBox4.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Aciklama", "Seçim")});
            this.cmbComboBox4.DisplayMember = "Aciklama";
            this.cmbComboBox4.Name = "cmbComboBox4";
            this.cmbComboBox4.ValueMember = "Id";
            // 
            // cmbComboBox5
            // 
            this.cmbComboBox5.AutoHeight = false;
            this.cmbComboBox5.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbComboBox5.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Aciklama", "Seçim")});
            this.cmbComboBox5.DisplayMember = "Aciklama";
            this.cmbComboBox5.Name = "cmbComboBox5";
            this.cmbComboBox5.ValueMember = "Id";
            // 
            // cmbComboBox6
            // 
            this.cmbComboBox6.AutoHeight = false;
            this.cmbComboBox6.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbComboBox6.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Aciklama", "Seçim")});
            this.cmbComboBox6.DisplayMember = "Aciklama";
            this.cmbComboBox6.Name = "cmbComboBox6";
            this.cmbComboBox6.ValueMember = "Id";
            // 
            // cmbComboBox7
            // 
            this.cmbComboBox7.AutoHeight = false;
            this.cmbComboBox7.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbComboBox7.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Aciklama", "Seçim")});
            this.cmbComboBox7.DisplayMember = "Aciklama";
            this.cmbComboBox7.Name = "cmbComboBox7";
            this.cmbComboBox7.ValueMember = "Id";
            // 
            // cmbComboBox8
            // 
            this.cmbComboBox8.AutoHeight = false;
            this.cmbComboBox8.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbComboBox8.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Aciklama", "Seçim")});
            this.cmbComboBox8.DisplayMember = "Aciklama";
            this.cmbComboBox8.Name = "cmbComboBox8";
            this.cmbComboBox8.ValueMember = "Id";
            // 
            // cmbComboBox9
            // 
            this.cmbComboBox9.AutoHeight = false;
            this.cmbComboBox9.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbComboBox9.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Aciklama", "Seçim")});
            this.cmbComboBox9.DisplayMember = "Aciklama";
            this.cmbComboBox9.Name = "cmbComboBox9";
            this.cmbComboBox9.ValueMember = "Id";
            // 
            // cmbComboBox10
            // 
            this.cmbComboBox10.AutoHeight = false;
            this.cmbComboBox10.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbComboBox10.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Aciklama", "Seçim")});
            this.cmbComboBox10.DisplayMember = "Aciklama";
            this.cmbComboBox10.Name = "cmbComboBox10";
            this.cmbComboBox10.ValueMember = "Id";
            // 
            // UCAyarlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcSettings);
            this.Name = "UCAyarlar";
            this.Size = new System.Drawing.Size(731, 593);
            ((System.ComponentModel.ISupportInitialize)(this.gcSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumerikAlanN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chbBooleanAlan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumerikAlanN4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbComboBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbComboBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbComboBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbComboBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbComboBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbComboBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbComboBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbComboBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYaziciYolu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDosyaYolu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKlasorYolu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcSettings;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSettings;
        private DevExpress.XtraGrid.Columns.GridColumn clmAciklama;
        private DevExpress.XtraGrid.Columns.GridColumn clmDeger;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtNumerikAlanN;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chbBooleanAlan;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtNumerikAlanN4;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtPassword;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cmbComboBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cmbComboBox2;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cmbComboBox3;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cmbComboBox4;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cmbComboBox5;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cmbComboBox6;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cmbComboBox7;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cmbComboBox8;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cmbComboBox9;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cmbComboBox10;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit txtYaziciYolu;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit txtDosyaYolu;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit txtKlasorYolu;
    }
}
