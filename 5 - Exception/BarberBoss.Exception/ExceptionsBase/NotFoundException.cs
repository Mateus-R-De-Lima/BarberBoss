
namespace BarberBoss.Exception.ExceptionsBase
{
    public class NotFoundException : BarberBossException
    {
        public NotFoundException(string message) : base(message)
        {

        }
        public override int StatusCode => throw new NotImplementedException();

        public override List<string> GetErros()
        {
            return [Message];
        }
    }
}
