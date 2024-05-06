using System.IdentityModel.Tokens.Jwt;

namespace Unicam.Paradigmi.Progetto.Application.Middlewares
{
    public class JwtMiddleware
    {
        /*
         * This class is a middleware that manages the JWT token in the request
         * 
         * @param _next: the next middleware in the pipeline
         * @return: the response to the request
         * **/
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (token != null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;
                var idUtente = Convert.ToInt32(jwtToken.Claims.First(claim => claim.Type == "IdUtente").Value);
                if (idUtente != 0)
                {
                    // Add the user ID to the HTTP context to be used in subsequent requests
                    context.Items["IdUtente"] = idUtente;
                }
            }

            await _next(context); // Call the next delegate/middleware in the pipeline, If we want to add new middleware we can add it here with .Invoke(context)
        }
    }
}
