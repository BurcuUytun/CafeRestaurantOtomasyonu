using System;
using System.Data;
using System.Windows.Forms;

namespace CafeRestaurantOtomasyonu.Forms
{
    public partial class FrmList : DevExpress.XtraEditors.XtraForm
    {
        readonly string _fieldName1 = string.Empty;
        readonly string _fieldName2 = string.Empty;
        bool _valueEntered = false;

        public FrmList(string caption, DataTable dataTable, int width, string fieldName1, string fieldName2 = "", sbyte gizlenecekKolonIndex = -1)
        {
            InitializeComponent();
            this._fieldName1 = fieldName1;
            this._fieldName2 = fieldName2;
            this.Text = caption;

            gcDetails.DataSource = dataTable;
            Width = width;

            if (gizlenecekKolonIndex >= 0)
                gvDetails.Columns[gizlenecekKolonIndex].Visible = false;
        }

        internal object Value1
        {
            get { return gvDetails.GetRowCellValue(gvDetails.FocusedRowHandle, _fieldName1); }
        }

        internal object Value2
        {
            get { return gvDetails.GetRowCellValue(gvDetails.FocusedRowHandle, _fieldName2); }
        }


        internal bool ValueEntered
        {
            get { return _valueEntered; }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _valueEntered = true;
            this.Close();
        }

        private void gvDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (gvDetails.FocusedRowHandle >= 0 && e.KeyCode == Keys.Enter)
            {
                btnOk_Click(null, null);
            }
        }

        private void FrmList_Shown(object sender, EventArgs e)
        {
            gvDetails.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _valueEntered = false;
            this.Close();
        }

        private void gvDetails_DoubleClick(object sender, EventArgs e)
        {
            _valueEntered = true;
            this.Close();
        }

    }
}