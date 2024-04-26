using Unicam.Paradigmi.Progetto.Models.Extensions;
using Unicam.Paradigmi.Progetto.Web.Extensions;
using Unicam.Paradigmi.Progetto.Application.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddWebService(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);
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
