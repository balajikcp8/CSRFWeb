using Microsoft.AspNetCore.Antiforgery;

namespace CSRFWeb.Middleware
{
    public class AntiforgeryMiddleware
    {
        public const string HeaderName = "X-CSRF-TOKEN";
        public const string CookieName = "X-CSRF-TOKEN";
        public const string FormFieldName = "X-CSRF-TOKEN";

        private readonly RequestDelegate _next;
        private readonly IAntiforgery _antiforgery;

        public AntiforgeryMiddleware(RequestDelegate next, IAntiforgery antiforgery)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _antiforgery = antiforgery;
        }

        public async Task Invoke(HttpContext context)
        {
            var tokens = _antiforgery.GetAndStoreTokens(context);
            context.Response.Cookies.Append(CookieName,
                tokens.RequestToken!,
                new CookieOptions()
                {
                    HttpOnly = false,
                    //SameSite = SameSiteMode.Strict
                });

            await _next.Invoke(context);
        }
    }
}
