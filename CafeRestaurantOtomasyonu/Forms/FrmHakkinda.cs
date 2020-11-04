using System;
using System.Reflection;
using System.Windows.Forms;

namespace CafeRestaurantOtomasyonu.Forms
{
    partial class FrmHakkinda : Form
    {
        public FrmHakkinda()
        {
            InitializeComponent();

           // bool asilDenemeSurumu = UniqueValueOperations.SecondValueExisting;

            this.Text = String.Format("{0} :: Hakkında", AssemblyTitle);this.labelProductName.Text = AssemblyProduct;
            this.labelVersion.Text = String.Format("{0} Sürümü", AssemblyVersion);
            this.labelCopyright.Text = AssemblyCopyright;
            this.labelCompanyName.Text = AssemblyCompany;

            // this.textBoxDescription.Text = UniqueValueOperations.SecondValueExisting ? string.Format("Deneme süresi {0:d MMMM yyyy} tarihinde sona erecektir.", UniqueValueOperations.EndDate) : "Program lisanslıdır.";
            this.textBoxDescription.Text = "Deneme sürümü";

         //   UniqueValueOperations.SecondValueExisting = asilDenemeSurumu;
        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

        private void FrmHakkinda_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();
        }
    }
}
