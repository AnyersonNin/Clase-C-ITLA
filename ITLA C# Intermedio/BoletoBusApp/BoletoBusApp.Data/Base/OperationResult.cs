
namespace BoletoBusApp.Data.Base
{
    public class OperationResult<TDate>
    {
      public bool Success { get; set; }
        public string? Message { get; set; }

        public TDate? Result { get; set; }

    }
}
