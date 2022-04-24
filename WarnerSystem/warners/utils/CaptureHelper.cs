using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows;

namespace WarnerSystem.warners.utils
{
    static class CaptureHelper
    {
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
