using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using CafeRestaurantOtomasyonu.Classes;
using DevExpress.XtraEditors;

namespace CafeRestaurantOtomasyonu
{
    public partial class UCAyarlar : DevExpress.XtraEditors.XtraUserControl
    {
        private List<Ayar> _ayarlar = new List<Ayar>();
        public UCAyarlar()
        {
            InitializeComponent();
        
        }

        internal void GetSettings(int ayarGrubu)
        {
            try
            {
                string query = @"SELECT * 
                                 FROM AYARLAR 
                                 WHERE AyarId>0 AND Fk_AyarGrup=@AyarGrupId
                                 ORDER BY AyarId";
                DataTable datatable = CommonSqlOperations.GetDataTable(query,
                    new DinamikSqlParameter("@AyarGrupId", ayarGrubu));
                gcSettings.DataSource = datatable;
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("Ayarları Getirme", ex.Message);
                XtraMessageBox.Show("Ayarlar getirilirken hata meydana geldi. " + ex.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DrawValueMembers(DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName != "Deger")
                return;

            int ayarId = Convert.ToInt32(gvSettings.GetRowCellValue(e.RowHandle, "AyarId"));
            byte alanTipi = Convert.ToByte(gvSettings.GetRowCellValue(e.RowHandle, "AlanTipi"));
            switch (alanTipi)
            {
                case 1:
                    e.RepositoryItem = txtNumerikAlanN;
                    break;
                case 2:
                    e.RepositoryItem = txtNumerikAlanN4;
                    break;
                case 3:
                    e.RepositoryItem = chbBooleanAlan;
                    break;
                case 4:
                    e.RepositoryItem = txtPassword;
                    break;
                /*case 5:
                    if (ayarId == 5)
                    {
                        // Kur Hesaplama Şekli (0:Döviz Alış, 1:DövizSatış, 2: Efektif Alış, 3:Efektif Satış)
                        e.RepositoryItem = cmbComboBox1;
                    }
                    break;    */           
            }
        }

        private void gvSettings_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            DrawValueMembers(e);
        }

        private void gvSettings_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            DrawValueMembers(e);
        }
        private void gvSettings_HiddenEditor(object sender, EventArgs e)
        {
            int focusedRowHandle = gvSettings.FocusedRowHandle;

            if (gvSettings.FocusedColumn.FieldName == "Deger")
            {
                try
                {
                    string sorgu = @"UPDATE AYARLAR
                                         SET Deger=@Deger 
                                         WHERE AyarId=@AyarId";

                    CommonSqlOperations.ExecuteNonQuery(sorgu, new DinamikSqlParameter("@AyarId", Convert.ToInt16(gvSettings.GetRowCellValue(focusedRowHandle, "AyarId"))),
                                                               new DinamikSqlParameter("@Deger", gvSettings.GetRowCellValue(focusedRowHandle, "Deger").ToString()));


                }
                catch (Exception ex)
                {
                    CommonHelper.WriteLog("Ayar Kaydetme", ex.Message);
                    XtraMessageBox.Show("Ayar kaydedilirken hata meydana geldi. " + ex.Message, "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

