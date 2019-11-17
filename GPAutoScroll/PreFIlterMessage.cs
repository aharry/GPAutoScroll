using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPAutoScroll
{
    class PreFilterMessage : IMessageFilter
    {
        private IntPtr hWnd;

        public PreFilterMessage(IntPtr hWnd)
        {
            this.hWnd = hWnd;
        }

        bool IMessageFilter.PreFilterMessage(ref Message m)
        {
            if (m.Msg == 0x20A)     //  WM_MOUSEWHEEL
            {

                    if (this.hWnd != null)
                    {
                        var handle = hWnd;
                        handle = NativeMethods.FindWindowEx(handle, IntPtr.Zero, "Shell Embedding", null);
                        handle = NativeMethods.FindWindowEx(handle, IntPtr.Zero, "Shell DocObject View", null);
                        handle = NativeMethods.FindWindowEx(handle, IntPtr.Zero, "Internet Explorer_Server", null);
                        NativeMethods.PostMessage(handle, m.Msg, m.WParam, m.LParam);
                        return true;
                    }
            }
            return false;
        }

        protected static class NativeMethods
        {
            [System.Runtime.InteropServices.DllImport("user32.dll")]
            public static extern System.IntPtr SendMessage(System.IntPtr hWnd, System.Int32 Msg, System.IntPtr wParam, System.IntPtr lParam);
            [System.Runtime.InteropServices.DllImport("user32.dll")]
            public static extern System.Boolean PostMessage(System.IntPtr hWnd, System.Int32 Msg, System.IntPtr wParam, System.IntPtr lParam);
            [System.Runtime.InteropServices.DllImport("user32.dll")]
            public static extern System.IntPtr FindWindowEx(System.IntPtr hwndParent, System.IntPtr hwndChildAfter, string className, string windowName);
        }

    }


}
