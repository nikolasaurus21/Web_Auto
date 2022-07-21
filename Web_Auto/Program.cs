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
var service1 = builder.Services.AddSingleton<IImmobilizer, Immobilizer>();

IServiceProvider provider = service.BuildServiceProvider();
IServiceProvider provider1 = service1.BuildServiceProvider();
var ccar = provider.GetRequiredService<ICar>();
var carr = provider1.GetRequiredService<IImmobilizer>();

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
