using CafeRestaurantOtomasyonu.Classes;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CafeRestaurantOtomasyonu
{
    internal class UniqueValue
    {
        #region Private Variables

        private const int N = 256;
        private int[] sbox;
        private string appCode = "cxyyrhvOPFtCZOf5ZwOh";
        private string fingerPrintValue = string.Empty;
        private string reducedFingerPrintValue = string.Empty;

        #endregion

        internal UniqueValue()
        {
            fingerPrintValue = FingerPrint.Value();
            reducedFingerPrintValue = GetReducedFingerPrintValue();
        }

        #region Properties

        internal string FingerPrintValue
        {
            get { return fingerPrintValue; }
        }

        internal string ReducedFingerPrintValue
        {
            get { return reducedFingerPrintValue; }
        }

        #endregion

        #region Private Methods

        private string GetReducedFingerPrintValue()
        {
            string[] foursomeGroup = fingerPrintValue.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < foursomeGroup.Length; i++)
            {
                if (i % 2 == 1)
                    reducedFingerPrintValue = string.Concat(reducedFingerPrintValue, foursomeGroup[i]);
            }

            return reducedFingerPrintValue;
        }

        private void RC4Initialize()
        {
            sbox = new int[N];
            int[] key = new int[N];
            int n = appCode.Length;
            for (int a = 0; a < N; a++)
            {
                key[a] = (int)appCode[a % n];
                sbox[a] = a;
            }

            int b = 0;
            for (int a = 0; a < N; a++)
            {
                b = (b + sbox[a] + key[a]) % N;
                int tempSwap = sbox[a];
                sbox[a] = sbox[b];
                sbox[b] = tempSwap;
            }
        }

        #endregion

        #region Internal Methods

        internal bool AddLicence(string licence)
        {
            try
            {
                string text = HexStrToStr(licence);

                if (reducedFingerPrintValue == EnDeCrypt(text))
                {
                    FileInfo licenceFile = new FileInfo(GetLicenceFilePath());
                    if (licenceFile.Exists)
                    {
                        licenceFile.Attributes = licenceFile.Attributes & ~(FileAttributes.Archive | FileAttributes.ReadOnly | FileAttributes.Hidden);
                        licenceFile.Delete();
                    }
                    StreamWriter TxtFileCreater = licenceFile.CreateText();
                    TxtFileCreater.Write(text);
                    TxtFileCreater.Close();
                    licenceFile.Attributes |= FileAttributes.Hidden;
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal string EnDeCrypt(string text)
        {
            RC4Initialize();
            int i = 0, j = 0, k = 0;
            StringBuilder cipher = new StringBuilder();
            for (int a = 0; a < text.Length; a++)
            {
                i = (i + 1) % N;
                j = (j + sbox[i]) % N;
                int tempSwap = sbox[i];
                sbox[i] = sbox[j];
                sbox[j] = tempSwap;

                k = sbox[(sbox[i] + sbox[j]) % N];
                int cipherBy = ((int)text[a]) ^ k;  //xor operation
                cipher.Append(Convert.ToChar(cipherBy));
            }
            return cipher.ToString();
        }

        internal bool IsLicenceValid(string licence)
        {
            try
            {
                if (reducedFingerPrintValue == EnDeCrypt(HexStrToStr(licence)))
                    return true;
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }

        #endregion

        #region Internal Static Methods

        internal static string GetDemoFilePath()
        {
            return Path.Combine(Application.StartupPath, string.Format("{0}1.dat", CommonHelper.AssemblyProduct));
        }

        internal static string GetLicenceFilePath()
        {
            return Path.Combine(Application.StartupPath, string.Format("{0}.dat", CommonHelper.AssemblyProduct));
        }

        internal static string HexStrToStr(string hexStr)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hexStr.Length; i += 2)
            {
                int n = Convert.ToInt32(hexStr.Substring(i, 2), 16);
                sb.Append(Convert.ToChar(n));
            }
            return sb.ToString();
        }

        internal static string StrToHexStr(string str)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                int v = Convert.ToInt32(str[i]);
                sb.Append(string.Format("{0:X2}", v));
            }
            return sb.ToString();
        }

        #endregion
    }
}
