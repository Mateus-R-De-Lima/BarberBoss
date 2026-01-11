
using System.Net;

namespace BarberBoss.Exception.ExceptionsBase
{
    public class InvalidLoginException(string message) : BarberBossException(message)
    {       
        public override int StatusCode => (int)HttpStatusCode.Unauthorized;

        public override List<string> GetErros()
        {
            return [Message];
        }
    }
}
