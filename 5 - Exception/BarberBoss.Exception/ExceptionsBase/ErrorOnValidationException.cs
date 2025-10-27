using System.Net;

namespace BarberBoss.Exception.ExceptionsBase
{
    public class ErrorOnValidationException : BarberBossException
    {
        private List<string> _errorMessages { get; set; }

        public override int StatusCode => (int)HttpStatusCode.BadRequest;
        public ErrorOnValidationException(List<string> errorMessages) : base(string.Empty)
        {
            _errorMessages = errorMessages;
        }

        public override List<string> GetErros()
        {
            return _errorMessages;
        }
    }
}
