using System;
using System.Threading.Tasks;

namespace WarnerSystem.warners
{
    class TestOcrWarner : IWarner
    {
        public string GetTitle()
        {
            throw new NotImplementedException();
        }

        public string GetWarnerStatus()
        {
            throw new NotImplementedException();
        }

        public void InfoWindowClear()
        {
            throw new NotImplementedException();
        }

        public void InfoWindowFillout()
        {
            throw new NotImplementedException();
        }

        public void InfoWindowUpdate()
        {
            throw new NotImplementedException();
        }

        public Task StartWarner()
        {
            throw new NotImplementedException();
        }

        public void StopWarner()
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
