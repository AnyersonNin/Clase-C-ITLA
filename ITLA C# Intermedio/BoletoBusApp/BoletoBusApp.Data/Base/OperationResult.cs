
namespace BoletoBusApp.Data.Base
{
    public class OperationResult<TDate>
    {
        public OperationResult()
        {
            this.Success = true;
        }
        public bool Success { get; set; }
        public string? Message { get; set; }
        public TDate? Result { get; set; }

    }
}
