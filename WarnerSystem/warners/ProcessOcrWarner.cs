using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Controls;

namespace WarnerSystem.warners
{
    public class ProcessOcrWarner : Warner
    {
        ListBox processesListBox;
        OCR.OcrIron ocrIron;
        public ProcessOcrWarner(string title) : base(title)
        {
            ocrIron = new OCR.OcrIron();
        }
        public override void InfoWindowClear()
        {
            throw new NotImplementedException();
        }

        public override StackPanel InfoWindowFillout()
        {
            StackPanel sp = new StackPanel();

            processesListBox = new ListBox();
            TextBox t1 = new TextBox();
            t1.TextChanged += DesiredProcessNameText_Changed;

            //Temporary
            Image image = new Image();
            sp.Children.Add(image);
            var bmp = utils.CaptureHelper.CaptureScreen(100,40,0,0);
            
            image.Source = XAMLHelper.BitmapToSource(bmp);
            ocrIron.TryGetResult(bmp, out OCR.OCRResult res);
            Debug.WriteLine(res.Result);
            //
            sp.Children.Add(t1);
            sp.Children.Add(processesListBox);
            FillProcessList();
            return sp;
        }
        private void FillProcessList()
        {

            /*var k = utils.CaptureHelper.GetWindowProcesses();
            foreach (var process in k)
            {
                
                processesListBox.Items.Add(process.MainWindowTitle);//do something with the process here. To display it's name, use process.MainWindowTitle
            }-*/

        }

        private void DesiredProcessNameText_Changed(object sender, TextChangedEventArgs args)
        {

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
