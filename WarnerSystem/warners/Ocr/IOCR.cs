using System.Drawing;

namespace OCR
{
    public interface IOCR
    {
        public bool TryGetResult(Bitmap image, out OCRResult result);

        public bool TryGetResult(string filePath, out OCRResult result);
    }
}