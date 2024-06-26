﻿using Unicam.Paradigmi.Progetto.Application.Middlewares;

namespace Unicam.Paradigmi.Progetto.Web.Extensions
{
    public static class MiddlewareExtension
    {
        public static WebApplication? AddWebMiddleware(this WebApplication? app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.UseMiddleware<JwtMiddleware>();
            return app;
        }
    }
}
