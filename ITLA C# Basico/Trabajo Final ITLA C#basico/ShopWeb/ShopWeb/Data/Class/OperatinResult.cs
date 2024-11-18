using DocumentFormat.OpenXml.Drawing;

namespace ShopWeb.Data.Class
{
    public class OperatinResult<TResult>
    {
        public string? Message { get; set; }
        public bool Success { get; set; }
        public TResult? Result { get; set; }
    }
}
