using IronOcr;
using System.Drawing;

namespace OCR
{
    public class OcrIron : IOCR
    {
        private IronTesseract tesseract;
        public OcrIron()
        {
            tesseract = new IronTesseract();
        }
        public bool TryGetResult(Bitmap image, out OCRResult result)
        {
            using(OcrInput input = new OcrInput(image))
            {
                var ocrRes = tesseract.Read(input);
                result = new OCRResult(ocrRes.Text);
            }
            return true;
        }

        public bool TryGetResult(string filePath, out OCRResult result)
        {
            using (OcrInput input = new OcrInput(filePath))
            {
                var ocrRes = tesseract.Read(input);
                result = new OCRResult(ocrRes.Text);
            }

            return true;
                
            
            
            
        }
    }
}