using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Controls;

namespace WarnerSystem.warners
{
    public class ScreenOcrWarner : Warner
    {
        Image testCaptureImage;
        TextBox tb;
        OCR.OcrIron ocrIron;
        public ScreenOcrWarner(string title) : base(title)
        {
            ocrIron = new OCR.OcrIron();
            testCaptureImage = new Image();
            tb = new TextBox();
        }
        public override void InfoWindowClear()
        {
            throw new NotImplementedException();
        }

        public override StackPanel InfoWindowFillout()
        {
            StackPanel sp = new StackPanel();
            Button b1 = new Button();
            b1.Click += B1_Click;
            b1.Content = "test";
            //Temporary

            sp.Children.Add(b1);
            sp.Children.Add(tb);
            sp.Children.Add(testCaptureImage);
            return sp;
        }

        private void B1_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            TestCapture();
        }

        private void TestCapture()
        {
            var vals = tb.Text.Split(",");
            var v1 = int.Parse(vals[0]);
            var v2 = int.Parse(vals[1]);
            var v3 = int.Parse(vals[2]);
            var v4 = int.Parse(vals[3]);
            var bmp = utils.CaptureHelper.CaptureScreen(v1, v2, v3, v4);
            testCaptureImage.Source = XAMLHelper.BitmapToSource(bmp);
        }

        public override void InfoWindowUpdate()
        {
            throw new NotImplementedException();
        }

        public override Action WarnerAction(CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
