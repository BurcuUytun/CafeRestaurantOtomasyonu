using CafeRestaurantOtomasyonu.Classes;
using System.Threading;

namespace CafeRestaurantOtomasyonu
{
    public class WaitingPanel
    {
        public WaitingPanel()
        {
        }

        static FrmWaiting _frmWaiting = null;

        static Thread _threadBekleme = null;

        public static void Hide()
        {
            try
            {
                if (_threadBekleme != null && _threadBekleme.ThreadState == ThreadState.Running && _frmWaiting != null)
                {
                    System.Threading.Thread.Sleep(2000);
                    _frmWaiting.Invoke((System.Windows.Forms.MethodInvoker)delegate
                    {
                        _frmWaiting.Close();
                    });
                }
            }
            catch (System.Exception ex)
            {
                CommonHelper.WriteLog("Hide Waiting Panel", ex.Message);
            }
        }

        public static void Show(string caption, string description)
        {
            try
            {
                if (_threadBekleme == null || _threadBekleme.ThreadState != ThreadState.Running)
                {
                    _threadBekleme = new Thread(() => (_frmWaiting = new FrmWaiting(caption, description)).ShowDialog());
                    _threadBekleme.TrySetApartmentState(ApartmentState.MTA);
                    _threadBekleme.Start();
                }
            }
            catch (System.Exception ex)
            {
                CommonHelper.WriteLog("Show Waiting Panel", ex.Message);
            }
        }
    }
}
