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
