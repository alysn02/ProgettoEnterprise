
using Microsoft.EntityFrameworkCore;
using Unicam.Paradigmi.Progetto.Application.Services;
using Unicam.Paradigmi.Progetto.Models.Context;
using Unicam.Paradigmi.Progetto.Models.Repositories;
using Unicam.Paradigmi.Progetto.Models.Extensions;
using Unicam.Paradigmi.Progetto.Application.Abstractions.Services;
using Unicam.Paradigmi.Progetto.Web.Extensions;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<UtenteService>();
builder.Services.AddScoped<UtenteRepository>();
builder.Services.AddScoped<ListaUtenzaService>();
builder.Services.AddScoped<ListaUtenzaRepository>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddWebService(builder.Configuration);
builder.Services.AddModelServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
