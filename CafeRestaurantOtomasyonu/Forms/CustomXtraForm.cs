using System;
using System.Windows.Forms;
using CafeRestaurantOtomasyonu.Classes;
using DevExpress.XtraDataLayout;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;

namespace CafeRestaurantOtomasyonu.Forms
{
    public class CustomXtraForm : XtraForm
    {
        internal bool Kapatiliyor = false;
        LayoutControlGroup layoutControlGroup2;
        internal bool GridDegisti;
        private bool _keyDownFired;

        public CustomXtraForm()
        {
            this.KeyPreview = true;
            this.Shown += CustomXtraForm_Shown;
            this.KeyDown += CustomXtraForm_KeyDown;
            this.FormClosing += CustomXtraForm_FormClosing;
        }

        public virtual void KaydetGuncelle()
        {
        }

        public virtual void Sil()
        {
        }

        public virtual void Temizle(bool kodHaric)
        {
        }

        private void CustomXtraForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (layoutControlGroup2 == null)
                {
                    if (GridDegisti)
                    {
                        DialogResult soru = XtraMessageBox.Show(
                              "Kaydedilmeyen değişiklikler kaybolacak, yine de çıkış yapılsın mı?",
                              "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (soru == DialogResult.Yes)
                            Kapatiliyor = true;
                        else
                            e.Cancel = true;
                    }
                }
                else
                {
                    if (CommonHelper.DegerleriTagdanFarkliMi(layoutControlGroup2) || GridDegisti)
                    {
                        DialogResult soru = XtraMessageBox.Show(
                            "Kaydedilmeyen değişiklikler kaybolacak, yine de çıkış yapılsın mı?",
                            "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (soru == DialogResult.Yes)
                            Kapatiliyor = true;
                        else
                            e.Cancel = true;
                    }
                }
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("CustomXtraForm_FormClosing()", ex.Message);
            }
        }

        private void CustomXtraForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (_keyDownFired)
                return;

            _keyDownFired = true;

            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
                else if (e.Control && e.KeyCode == Keys.N)
                {
                    Temizle(false);
                }
                else if (e.Control && e.KeyCode == Keys.S)
                {
                    KaydetGuncelle();
                }
                else if (e.Control && e.KeyCode == Keys.Delete)
                {
                    Sil();
                }
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("CustomXtraForm_KeyDown()", ex.Message);
            }

            _keyDownFired = false;
        }

        private void CustomXtraForm_Shown(object sender, EventArgs e)
        {
            AssignGridViewChangedEvent(this);

            foreach (Control control in this.Controls)
            {
                if (control is DataLayoutControl)
                {
                    foreach (LayoutControlGroup subControl in (control as DataLayoutControl).Root.Items)
                    {
                        layoutControlGroup2 = subControl;

                        AssignF10(layoutControlGroup2);

                        CommonHelper.DegerleriTagaAl(layoutControlGroup2);
                        return;
                    }
                }
            }
        }

        private void AssignGridViewChangedEvent(Control control)
        {
            if (control is GridControl)
            {
                var gridControl = (GridControl)control;

                if (gridControl.Views.Count > 0)
                {
                    var gridView = gridControl.Views[0] as GridView;
                    if (gridView != null)
                        gridView.HiddenEditor += CustomXtraForm_HiddenEditor;
                }
            }
            else
                foreach (Control subControl in control.Controls)
                {
                    AssignGridViewChangedEvent(subControl);
                }
        }

        private void CustomXtraForm_HiddenEditor(object sender, EventArgs eventArgs)
        {
            GridDegisti = true;
        }

        public void AssignF10(LayoutControlGroup layoutControlGroup)
        {
            foreach (var groupItem in layoutControlGroup.Items)
            {
                if (groupItem is LayoutControlItem)
                {
                    LayoutControlItem layoutControlItem = (LayoutControlItem)groupItem;
                    if (groupItem is EmptySpaceItem)
                        continue;
                    if (layoutControlItem.Control is ButtonEdit && ((ButtonEdit)layoutControlItem.Control).Properties.Buttons.Count > 0)
                        ((ButtonEdit)layoutControlItem.Control).Properties.Buttons[0].Shortcut =
                            new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F10);
                    layoutControlItem.Control.KeyDown += SonrakiControlFocus;
                }
                else if (groupItem is LayoutControlGroup)
                {
                    AssignF10((LayoutControlGroup)groupItem);
                }
            }
        }

        private void SonrakiControlFocus(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && sender is BaseEdit && layoutControlGroup2 != null)
            {
                var baseEdit = (BaseEdit)sender;
                var tabIndex = baseEdit.TabIndex;

                bool selectNextGroup = false;
                int groupIndex = -1;

                foreach (var groupItem in layoutControlGroup2.Items)
                {
                    if (groupItem is LayoutControlGroup)
                    {
                        groupIndex++;

                        var subLayoutControlGroup = (LayoutControlGroup)groupItem;

                        foreach (LayoutControlItem subLayoutControlItem in subLayoutControlGroup.Items)
                        {
                            if (subLayoutControlItem.Control.Name == baseEdit.Name)
                            {
                                var yeniSubTabIndex = tabIndex + 1 < subLayoutControlGroup.Items.Count
                                    ? tabIndex + 1
                                    : 0;

                                if (yeniSubTabIndex > 0)
                                {
                                    var nextSubLayoutControlItem =
                                        subLayoutControlGroup.Items[yeniSubTabIndex] as LayoutControlItem;
                                    if (nextSubLayoutControlItem != null)
                                        nextSubLayoutControlItem.Control.Focus();
                                }
                                else
                                {
                                    selectNextGroup = true;
                                    break;
                                }
                            }
                        }

                        if (selectNextGroup)
                            break;
                    }
                }

                if (selectNextGroup && layoutControlGroup2.Items.Count > groupIndex + 1 &&
                    layoutControlGroup2.Items[groupIndex + 1] is LayoutControlGroup &&
                    (layoutControlGroup2.Items[groupIndex + 1] as LayoutControlGroup).Items.Count > 0)
                    ((layoutControlGroup2.Items[groupIndex + 1] as LayoutControlGroup).Items[0] as LayoutControlItem)
                        .Control.Focus(); if (groupIndex < 0)
                {
                    var yeniTabIndex = tabIndex + 1 < layoutControlGroup2.Items.Count ? tabIndex + 1 : 0;

                    LayoutControlItem nextLayoutControlItem = null;

                    foreach (LayoutControlItem layoutItem in layoutControlGroup2.Items)
                    {
                        if (layoutItem is EmptySpaceItem)
                            continue;
                        if (layoutItem.Control.TabIndex >= yeniTabIndex &&
                            (nextLayoutControlItem == null ||
                             (layoutItem.Control.TabIndex < nextLayoutControlItem.Control.TabIndex)))
                            nextLayoutControlItem = layoutItem;

                        if (layoutItem.Control.TabIndex == yeniTabIndex)
                            break;
                    }

                    if (nextLayoutControlItem != null)
                        nextLayoutControlItem.Control.Focus();
                }
            }
        }
    }
}
