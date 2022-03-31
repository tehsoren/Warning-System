using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;


namespace WarnerSystem
{
    class ScreenCaptureHandler
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct Rect
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }
        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hWnd, out Rect lpRect);
        [DllImport("user32.dll")]
        public static extern bool PrintWindow(IntPtr hWnd, IntPtr hdcBlt, int nFlags);
        [DllImport("user32.dll")]
        private static extern bool EnumWindows(EnumWindowsProc enumProc, IntPtr lParam);
        [DllImport("USER32.DLL")]
        private static extern bool IsWindowVisible(IntPtr hWnd);
        public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder strText, int maxCount);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern int GetWindowTextLength(IntPtr hWnd);

        DateTime lastUpdate;
        TimeSpan timeBetweenUpdates;
        Bitmap screen;

        public ScreenCaptureHandler()
        {
            timeBetweenUpdates = new TimeSpan(0, 0, 5);
        }
        public Bitmap CaptureScreen()
        {
            var curTime = DateTime.Now;

            if (lastUpdate == null || curTime.Ticks - lastUpdate.Ticks > timeBetweenUpdates.Ticks)
            {
                lastUpdate = curTime;
                screen = new Bitmap(800, 600);
                Graphics g = Graphics.FromImage(screen);

                g.CopyFromScreen(0, 0, 0, 0, new System.Drawing.Size(800, 600));

            }
            return screen;
        }

        public BitmapSource Convert(Bitmap bmp)
        {
            var bitmapSource = Imaging.CreateBitmapSourceFromHBitmap(bmp.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

            return bitmapSource;
        }

        public static Bitmap PrintWindow(IntPtr hwnd)
        {
            Rect rc;

            GetWindowRect(hwnd, out rc);
            Debug.WriteLine(rc.ToString());
            Bitmap bmp = new Bitmap(rc.right - rc.left, rc.bottom - rc.top);
            Graphics gfxBmp = Graphics.FromImage(bmp);
            IntPtr hdcBitmap = gfxBmp.GetHdc();

            PrintWindow(hwnd, hdcBitmap, 0);

            gfxBmp.ReleaseHdc(hdcBitmap);
            gfxBmp.Dispose();

            return bmp;
        }
        public static IEnumerable<IntPtr> FindWindows()//EnumWindowsProc filter)
        {
            IntPtr found = IntPtr.Zero;
            List<IntPtr> windows = new List<IntPtr>();

            EnumWindows(delegate (IntPtr wnd, IntPtr param)
            {
                if (IsWindowVisible(wnd) & GetWindowTextLength(wnd) > 0)//filter(wnd, param))
                {
                    // only add the windows that pass the filter
                    windows.Add(wnd);
                    Debug.WriteLine(GetWindowText(wnd));
                }

                // but return true here so that we iterate all windows
                return true;
            }, IntPtr.Zero);

            return windows;
        }

        public static string GetWindowText(IntPtr hWnd)
        {
            int size = GetWindowTextLength(hWnd);
            if (size > 0)
            {
                var builder = new StringBuilder(size + 1);
                GetWindowText(hWnd, builder, builder.Capacity);
                return builder.ToString();
            }

            return String.Empty;
        }

    }
}
