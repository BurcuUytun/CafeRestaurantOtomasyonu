namespace CafeRestaurantOtomasyonu
{
    partial class FrmWaiting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWaiting));
            this.ppWaiting = new DevExpress.XtraWaitForm.ProgressPanel();
            this.SuspendLayout();
            // 
            // ppWaiting
            // 
            this.ppWaiting.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.ppWaiting.Appearance.Options.UseBackColor = true;
            this.ppWaiting.AppearanceCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ppWaiting.AppearanceCaption.Options.UseFont = true;
            this.ppWaiting.AppearanceDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ppWaiting.AppearanceDescription.Options.UseFont = true;
            this.ppWaiting.Caption = "Lütfen Bekleyiniz";
            this.ppWaiting.Description = "Rapor alınıyor ...";
            this.ppWaiting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ppWaiting.Location = new System.Drawing.Point(0, 0);
            this.ppWaiting.Name = "ppWaiting";
            this.ppWaiting.Size = new System.Drawing.Size(246, 66);
            this.ppWaiting.TabIndex = 0;
            this.ppWaiting.Text = "Lütfen bekleyiniz...";
            // 
            // FrmWaiting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 66);
            this.Controls.Add(this.ppWaiting);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmWaiting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraWaitForm.ProgressPanel ppWaiting;

    }
}