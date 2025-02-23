using System.Globalization;

namespace T_Camps.Middleware
{
    public class LocalizationMiddleware
    {
        private readonly RequestDelegate _next;

        public LocalizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var cultureCookie = context.Request.Cookies["Language"];
            if (!string.IsNullOrEmpty(cultureCookie))
            {
                var culture = new CultureInfo(cultureCookie);
                Thread.CurrentThread.CurrentCulture = culture;
                Thread.CurrentThread.CurrentUICulture = culture;
            }

            await _next(context);
        }
    }
}
