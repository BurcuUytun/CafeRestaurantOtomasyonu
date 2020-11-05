using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeRestaurantOtomasyonu.Classes
{
    class CommonHelper
    {
        public static string AssemblyVersion
        {
            get { return Assembly.GetExecutingAssembly().GetName().Version.ToString(); }
        }

        public static string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly()
                    .GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public static void AlanlariTemizle(LayoutControlGroup layoutControlGroup,
            string[] haricTutulacakKontrolIsimleri = null)
        {
            foreach (var groupItem in layoutControlGroup.Items)
            {
                if (groupItem is LayoutControlItem)
                {
                    LayoutControlItem layoutControlItem = (LayoutControlItem)groupItem;

                    if (layoutControlItem is EmptySpaceItem)
                        continue;

                    if (!StringExistsInArray(layoutControlItem.Control.Name, haricTutulacakKontrolIsimleri))
                    {
                        if (layoutControlItem.Control is ComboBoxEdit)
                        {
                            ComboBoxEdit control = ((ComboBoxEdit)layoutControlItem.Control);

                            if (control.Properties.Items.Count > 0)
                                control.SelectedIndex = 0;
                        }
                        else if (layoutControlItem.Control is PictureEdit)
                        {
                            ((PictureEdit)layoutControlItem.Control).EditValue = null;
                        }
                        else if (layoutControlItem.Control is BaseEdit)
                        {
                            ((BaseEdit)layoutControlItem.Control).EditValue = null;
                        }
                        else
                        {
                            layoutControlItem.Control.Text = string.Empty;
                        }
                    }
                }
                else if (groupItem is LayoutControlGroup)
                {
                    AlanlariTemizle((LayoutControlGroup)groupItem, haricTutulacakKontrolIsimleri);
                }
            }
        }
        internal static void DataUpgradeDinamik()
        {

            string[] queries =
                Properties.Resources.Update.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var query in queries)
            {
                try
                {
                    SqlHelper.ExecuteNonQuery(query);
                }
                catch
                {
                    // ignored
                }
            }
        }

        public static void DegerleriTagaAl(LayoutControlGroup layoutControlGroup, string[] haricTutulacakKontrolIsimleri = null)
        {
            foreach (var groupItem in layoutControlGroup.Items)
            {
                if (groupItem is EmptySpaceItem)
                    continue;

                if (groupItem is LayoutControlItem)
                {
                    LayoutControlItem layoutControlItem = (LayoutControlItem)groupItem;

                    layoutControlItem.Control.Tag = layoutControlItem.Control.Text;
                }
                else if (groupItem is LayoutControlGroup)
                {
                    DegerleriTagaAl((LayoutControlGroup)groupItem);
                }
            }
        }
        /// <summary>
        /// Farklılık var ise true döndürür.
        /// </summary>
        /// <param name="haricTutulacakKontrol"></param>
        /// <returns></returns>
        public static bool DegerleriTagdanFarkliMi(LayoutControlGroup layoutControlGroup,
            string[] haricTutulacakKontrolIsimleri = null)
        {
            try
            {
                foreach (var groupItem in layoutControlGroup.Items)
                {
                    if (groupItem is LayoutControlItem)
                    {
                        LayoutControlItem layoutControlItem = (LayoutControlItem)groupItem;
                        if (groupItem is EmptySpaceItem)
                            continue;

                        if (!StringExistsInArray(layoutControlItem.Control.Name, haricTutulacakKontrolIsimleri) &&
                            layoutControlItem.Control.Tag != null &&
                            layoutControlItem.Control.Tag.ToString() != layoutControlItem.Control.Text)
                            return true;
                    }
                    else if (groupItem is LayoutControlGroup)
                    {
                        return DegerleriTagdanFarkliMi((LayoutControlGroup)groupItem, haricTutulacakKontrolIsimleri);
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLog("DegerleriTagdanFarkliMi()", ex.Message);
            }
            return false;

        }
        internal static bool StringExistsInArray(string str, string[] args)
        {
            if (args == null || args.Length < 1)
                return false;

            foreach (string arg in args)
            {
                if (arg.ToLower() == str.ToLower())
                    return true;
            }

            return false;
        }

        internal static bool VeritabaniAyarlariGetir()
        {
            if (Settings.VeritabaniAyarlariGetir())
                return true;

            return false;
        }
        public static void WriteLog(string methodName, string logMessage)
        {
            if (!Directory.Exists(string.Format("{0}\\Log", Application.StartupPath)))
                Directory.CreateDirectory(string.Format("{0}\\Log", Application.StartupPath));

            StreamWriter writer =
                new StreamWriter(
                    string.Format("{0}\\Log\\Log{1:yyyyMMdd}.txt", Application.StartupPath, DateTime.Today), true);

            try
            {
                writer.WriteLine(string.Format("{0:dd.MM.yyyy HH:mm:ss}\t{1}\t{2}", DateTime.Now, methodName,
                    logMessage));
            }
            catch
            {
            }
            finally
            {
                writer.Close();
                writer.Dispose();
            }
        }
    }
}
