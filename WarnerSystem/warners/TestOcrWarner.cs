using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WarnerSystem.warners
{
    public class TestOcrWarner : Warner
    {
        public TestOcrWarner(string title) : base(title)
        {
        }
        public override TaskStatus? GetWarnerStatus()
        {
            throw new NotImplementedException();
        }

        public override void InfoWindowClear()
        {
            throw new NotImplementedException();
        }

        public override StackPanel InfoWindowFillout()
        {
            throw new NotImplementedException();
        }

        public override void InfoWindowUpdate()
        {
            throw new NotImplementedException();
        }

        public override Action WarnerAction(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        private void OCR()
        {
            //ScreenCaptureHandler sch = new ScreenCaptureHandler();

            //Bitmap sc = sch.CaptureScreen();


            //testimg.Source = sch.Convert(sc);
            //testimg.Source = new BitmapImage(new Uri(@"G:\testcap.jpg"));
            //ImageSourceConverter c = new ImageSourceConverter();
            //testimg.Source = (ImageSource)c.ConvertFrom(sc);
            //BitmapImage bmi = new BitmapImage()
            //var ocr = new AutoOcr() { ReadBarCodes = false };
            //var bm = Bitmap.FromFile(@"C:\Users\Soren\Desktop\t.png");
            //var res = ocr.Read();//(@"C:\Users\Soren\Desktop\t.png");
            //var res = ocr.Read(bm);
            //Debug.WriteLine(res.Text);
            //kk[0].Start();

            /*ScreenCaptureHandler sch = new ScreenCaptureHandler();
            Process[] procs = Process.GetProcesses();
            Process proc = Process.GetProcessesByName("firefox")[0];

            Bitmap bmp = ScreenCaptureHandler.PrintWindow(proc.MainWindowHandle);
            testimg.Source = sch.Convert(bmp);

            IEnumerable<IntPtr> test = ScreenCaptureHandler.FindWindows();
            Debug.WriteLine(test.Count());*/
        }
    }
}
