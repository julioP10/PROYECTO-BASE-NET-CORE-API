namespace Infraestructure.Crosscutting.Logging
{
    public class JsonResult<TData>
    {
        public bool Valid { get; set; }
        public string Message { get; set; }
        public TData Data { get; set; }

        public JsonResult()
        {
        }

        public JsonResult(TData data)
        {
            Valid = true;
            Data = data;
        }

        public JsonResult(bool valid = true, TData data = default(TData), string message = null)
        {
            Data = data;
            Valid = valid;
            Message = message;
        }

        public JsonResult(bool valid, string message = null)
        {
            Valid = valid;
            Message = message;
        }
    }
}