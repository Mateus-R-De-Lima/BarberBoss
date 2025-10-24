using System.Globalization;
using System.Threading.Tasks;

namespace BarberBoss.Api.Middleware
{
    public class CultureMiddleware
    {
        private readonly RequestDelegate _next;

        public CultureMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var supportedLanguages = CultureInfo.GetCultures(CultureTypes.AllCultures).ToList();

            var cultureHeaders = context.Request.Headers.AcceptLanguage.FirstOrDefault();

            var cultureInfo = new CultureInfo("en"); 

            if(!string.IsNullOrWhiteSpace(cultureHeaders) &&
                supportedLanguages.Exists(l => l.Name.Equals(cultureHeaders)))
                cultureInfo = new CultureInfo(cultureHeaders);

            CultureInfo.CurrentCulture = cultureInfo;
            CultureInfo.CurrentUICulture = cultureInfo;

            await _next(context);
        }
    }
}