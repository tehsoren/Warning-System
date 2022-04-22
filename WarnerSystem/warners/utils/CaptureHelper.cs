using System.Diagnostics;
using System.Drawing;

namespace WarnerSystem.warners.utils
{
    static class CaptureHelper
    {
        public static Process[] GetProcesses()
        {
            Process[] processes = Process.GetProcesses();
            return processes;
        }
        public static Process[] GetProcesses(string processName)
        {

            Process[] processes = Process.GetProcessesByName(processName);
            return processes;
        }

        public static Bitmap CaptureScreen(int width, int height,int offx,int offy)
        {
            var screen = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(screen))
            {
                g.CopyFromScreen(offx, offy, 0, 0, new System.Drawing.Size(width, height));
            }
            return screen;
        }


    }
}
