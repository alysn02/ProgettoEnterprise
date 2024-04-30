using Newtonsoft.Json;

namespace Unicam.Paradigmi.Progetto.Application.Middlewares
{
    public class ErrorResponseMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorResponseMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var error = new ErrorResponse
                {
                    Message = "Errore interno del server"
                };

                var Json = JsonConvert.SerializeObject(error);
                context.Response.ContentType = "Errore, Non sei autorizzato";
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync(Json);
                
            }
            await _next.Invoke(context);
        }

        public class ErrorResponse
        {
            public int StatusCode { get; set; }
            public string Message { get; set; }
        }
    }

}
