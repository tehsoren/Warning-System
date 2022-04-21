namespace OCR
{
    public class OCRResult
    {
        readonly string _result;
        readonly bool _succeded;
        public OCRResult(string result)
        {
            _result = result;
            _succeded = true;
        }
        public OCRResult()
        {
        }
        public string Result { get => _result;}
        public bool Succeded { get => _succeded; }

        public bool TryGetResult(out string result)
        {
            result = _result;
            return _succeded;
        }



    }
}