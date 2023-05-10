namespace DMS.API.Models
{
    public class JSONResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; } = string.Empty;
        public object Data { get; set; } = string.Empty;
        public string ErrorMessage { get; set; } = string.Empty;
        public string ErrorDetail { get; set; } = string.Empty;
    }
}
