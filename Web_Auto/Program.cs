using Web_Auto.Class;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

/*
 ne radi
var service = new ServiceCollection();
service.AddScoped<ICar, Car>();
IServiceProvider provider = service.BuildServiceProvider();
provider.GetRequiredService<ICar>();

 */

var service = builder.Services.AddScoped<ICar,Car>();
var ervice1 = builder.Services.AddScoped<IImmobilizer, Immobilizer>();

IServiceProvider provider = service.BuildServiceProvider();
var ccar = provider.GetRequiredService<ICar>();
var carr = provider.GetRequiredService<IImmobilizer>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




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
