using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CafeRestaurantOtomasyonu.Classes;

namespace CafeRestaurantOtomasyonu
{
    public partial class FrmKullaniciYetkileri : DevExpress.XtraEditors.XtraForm
    {
        readonly List<DataLayerCustom.KullaniciYetki> kullaniciYetkileri = new List<DataLayerCustom.KullaniciYetki>();
        public FrmKullaniciYetkileri()
        {
            InitializeComponent();

            gcDetails.DataSource = kullaniciYetkileri;
            gcDetails.BindingContext = this.BindingContext;

            cmbUser.Properties.DataSource = DataLayerCustom.Kullanici.KullanicilariAl(true);
        }

        private void cmbUser_EditValueChanged(object sender, EventArgs e)
        {
            SqlDataReader reader = null;
            try
            {
                string query = @"SELECT YT.YetkiTanimID YetkiTanimID,YT.Aciklama Aciklama,ISNULL(KY.Yetki,0) [Yetki],VeriTipi 
                                 FROM YETKI_TANIMLARI YT LEFT JOIN KULLANICI_YETKILERI KY ON KY.Fk_YetkiTanimi=YT.YetkiTanimID AND KY.Fk_Kullanici=@UserID 
                                 ORDER BY YT.YetkiTanimID";

                reader = CommonSqlOperations.GetDataReader(query, new DinamikSqlParameter("@UserID", cmbUser.EditValue));

                kullaniciYetkileri.Clear();
                while (reader.Read())
                {
                    DataLayerCustom.KullaniciYetki userAuthorization = new DataLayerCustom.KullaniciYetki();
                    userAuthorization.YetkiTanimi = Convert.ToInt16(reader["YetkiTanimID"]);
                    userAuthorization.Aciklama = reader["Aciklama"].ToString();
                    userAuthorization.Yetki = Convert.ToString(reader["Yetki"]);
                    userAuthorization.VeriTipi = Convert.ToByte(reader["VeriTipi"]);

                    kullaniciYetkileri.Add(userAuthorization);
                }

                gvDetails.RefreshData();
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("Yetkileri Getir", ex.Message);
                XtraMessageBox.Show("Yetkiler getirilirken hata meydana geldi. " + ex.Message, "Hata",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (reader != null)
                {
                    if (reader.IsClosed)
                        reader.Close();

                    reader.Dispose();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gvDetails_HiddenEditor(object sender, EventArgs e)
        {
            int focusedRowHandle = gvDetails.FocusedRowHandle;

            if (gvDetails.FocusedColumn.FieldName == "Yetki")
            {
                try
                {
                    string query = @"IF EXISTS (SELECT 1 FROM KULLANICI_YETKILERI WHERE Fk_Kullanici=@UserID AND Fk_YetkiTanimi=@YetkiTanimID) 
                                        UPDATE KULLANICI_YETKILERI 
                                        SET Yetki=@Yetki 
                                        WHERE Fk_Kullanici=@UserID AND Fk_YetkiTanimi=@YetkiTanimID 
                                     ELSE 
                                        INSERT INTO KULLANICI_YETKILERI (Fk_Kullanici,Fk_YetkiTanimi,Yetki) 
                                        VALUES (@UserID,@YetkiTanimID,@Yetki)";

                    CommonSqlOperations.ExecuteNonQuery(query, new DinamikSqlParameter("@UserID", cmbUser.EditValue),
                                                     new DinamikSqlParameter("@YetkiTanimID", kullaniciYetkileri[focusedRowHandle].YetkiTanimi),
                                                     new DinamikSqlParameter("@Yetki", kullaniciYetkileri[focusedRowHandle].Yetki));
                }
                catch (Exception ex)
                {
                    CommonHelper.WriteLog("Yetki Kaydetme", ex.Message);
                    XtraMessageBox.Show("Yetki kaydedilirken hata meydana geldi. " + ex.Message, "Hata",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DrawValueMembers(DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName != "Yetki")
                return;

            int ayarId = Convert.ToInt32(gvDetails.GetRowCellValue(e.RowHandle, "YetkiTanimID"));
            byte veriTipi = Convert.ToByte(gvDetails.GetRowCellValue(e.RowHandle, "VeriTipi"));
            switch (veriTipi)
            {
                case 1: // NumerikAlanN
                    e.RepositoryItem = txtNumerikAlanN;
                    break;
                case 2: // NumerikAlanN4
                    e.RepositoryItem = txtNumerikAlan4;
                    break;
                case 3: // Checkbox
                    e.RepositoryItem = chbBooleanAlan;
                    break;
                case 4: // Şifre
                    e.RepositoryItem = txtPassword;
                    break;
                case 5: // Combobox
                    break;
            }
        }

        private void gvDetails_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            DrawValueMembers(e);
        }

        private void gvDetails_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            DrawValueMembers(e);
        }
    }
}