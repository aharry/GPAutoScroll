using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Timers;


namespace GPAutoScroll
{
    public partial class Form1 : Form
    {
        const uint EVENT_OBJECT_DESTROY = 0x8000;
        const uint EVENT_OBJECT_LOCATIONCHANGE = 0x800B;
        const uint WINEVENT_OUTOFCONTEXT = 0;
        const uint WM_MOUSEWHEEL = 0x20A;
        const uint WHEEL_DELTA = 120;

        protected static IntPtr hWndGP;
        protected static IntPtr hWndIE;
        protected static Int16 lines;
        protected static RECT rct;
        private IntPtr hhook;
        private static System.Timers.Timer aTimer;

        public delegate void WinEventDelegate(IntPtr hWinEventHook, uint eventType,
                IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime);

        public delegate void MidiInProc(IntPtr hMidiIn, int wMsg, IntPtr dwInstance, int dwParam1, int dwParam2);


        // Need to ensure delegates are not collected while we're using it,
        // storing it in a class field is simplest way to do this.
        public static WinEventDelegate procDelegate = new WinEventDelegate(WinEventProc);
        public static MidiInProc procMidiDelegate = new MidiInProc(MidiInputProc);

        public Form1()
        {
            InitializeComponent();
            btnStop.Enabled = false;
        }

        private static void SetTimer(decimal time)
        {
            // Create a timer
            aTimer = new System.Timers.Timer( Convert.ToDouble(time) * 1000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            var wParam = new ParamUnion { Number = 0x0 };
            wParam.High = (short)-lines;
            var lParam = new ParamUnion { Number = 0x0 };
            lParam.High = (short) rct.Top;
            lParam.Low = (short) rct.Left;

            var result = NativeMethods.PostMessage(hWndIE, WM_MOUSEWHEEL, wParam.Number, lParam.Number);
        }

        private void btnAttch_Click(object sender, EventArgs e)
        {
            UInt32 d = NativeMethods.midiInGetNumDevs();
            Console.WriteLine(d);
        }

        private void findWindow()
        {
            Process[] pList;
            pList = Process.GetProcesses();

            hWndGP = IntPtr.Zero;
            hWndIE = IntPtr.Zero;
            foreach (Process p in pList)
            {
                if (p.MainWindowTitle.Contains(Properties.Resources.Title))
                {
                    hWndGP = p.MainWindowHandle;
                    IntPtr hWnd = NativeMethods.FindWindowEx(hWndGP, IntPtr.Zero, "Shell Embedding", null);
                    hWnd = NativeMethods.FindWindowEx(hWnd, IntPtr.Zero, "Shell DocObject View", null);
                    hWndIE = NativeMethods.FindWindowEx(hWnd, IntPtr.Zero, "Internet Explorer_Server", null);
                }
            }

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (hWndIE != IntPtr.Zero)
            {
                SetTimer(scrollTime.Value);
                scrollTime.Enabled = false;
                NativeMethods.GetWindowRect(hWndIE, out rct);
                NativeMethods.SetForegroundWindow(hWndIE);
                btnStart.Enabled = false;
                btnStop.Enabled = true;
            }
        }


        private void btnStop_Click(object sender, EventArgs e)
        {
            aTimer.Stop();
            aTimer.Dispose();
            scrollTime.Enabled = true;
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            findWindow();
            hhook = NativeMethods.SetWinEventHook(EVENT_OBJECT_DESTROY, EVENT_OBJECT_LOCATIONCHANGE, IntPtr.Zero,
                    procDelegate, 0, 0, WINEVENT_OUTOFCONTEXT);
            lines = Convert.ToInt16(scrollLines.Value);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            NativeMethods.UnhookWinEvent(hhook);
        }

        public static void WinEventProc(IntPtr hWinEventHook, uint eventType,
                IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
        {
            // filter out non-HWND namechanges... (eg. items within a listbox)
            if (idObject != 0 || idChild != 0 || hwnd != hWndGP || hWndGP == IntPtr.Zero)
            {
                return;
            }

            switch(eventType)
            {
                case EVENT_OBJECT_DESTROY:
                    hWndGP = IntPtr.Zero;
                    hWndIE = IntPtr.Zero;
                    break;
                case EVENT_OBJECT_LOCATIONCHANGE:
                    NativeMethods.GetWindowRect(hWndIE, out rct);
                    break;
            }
        }

        public static void MidiInputProc(IntPtr hMidiIn,
                        int wMsg,
                        IntPtr dwInstance,
                        int dwParam1,
                        int dwParam2)
        {
        
        }


        internal static class NativeMethods
        {

            [DllImport("user32.dll")]
            public static extern System.IntPtr FindWindowEx(System.IntPtr hwndParent, 
                System.IntPtr hwndChildAfter, string className, string windowName);

            [DllImport("user32.dll")]
            public static extern IntPtr PostMessage(IntPtr hWnd, UInt32 Msg, UInt32 wParam, UInt32 lParam);

            [DllImport("user32.dll")]
            public static extern IntPtr SetWinEventHook(uint eventMin, uint eventMax, IntPtr
               hmodWinEventProc, WinEventDelegate lpfnWinEventProc, uint idProcess,
               uint idThread, uint dwFlags);

            [DllImport("user32.dll")]
            public static extern bool UnhookWinEvent(IntPtr hWinEventHook);

            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool SetForegroundWindow(IntPtr hWnd);

            [DllImport("winmm.dll", SetLastError = true)]
            internal static extern UInt32 midiInGetNumDevs();

            [DllImport("winmm.dll")]
            internal static extern int midiInClose(
                        IntPtr hMidiIn);

            [DllImport("winmm.dll")]
            internal static extern int midiInOpen(
                out IntPtr lphMidiIn,
                int uDeviceID,
                MidiInProc dwCallback,
                IntPtr dwCallbackInstance,
                int dwFlags);

            [DllImport("winmm.dll")]
            internal static extern int midiInStart(
                IntPtr hMidiIn);

            [DllImport("winmm.dll")]
            internal static extern int midiInStop(
                IntPtr hMidiIn);
        }

        private void scrollTime_ValueChanged(object sender, EventArgs e)
        {

        }

        private void scrollLines_ValueChanged(object sender, EventArgs e)
        {

            lines = Convert.ToInt16(scrollLines.Value);

        }

        [StructLayout(LayoutKind.Explicit)]
        struct ParamUnion
        {

            [FieldOffset(0)]
            public uint Number;

            [FieldOffset(0)]
            public short Low;

            [FieldOffset(2)]
            public short High;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;        // x position of upper-left corner
            public int Top;         // y position of upper-left corner
            public int Right;       // x position of lower-right corner
            public int Bottom;      // y position of lower-right corner
        }

    }

}
