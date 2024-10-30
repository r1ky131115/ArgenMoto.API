using Serilog;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ArgenMoto.Infrastructure.Data;
using Microsoft.OpenApi.Models;
using ArgenMoto.Core.Interfaces;
using ArgenMoto.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Configuración de Serilog
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/argen-moto-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();
builder.Host.UseSerilog();

builder.Services.AddDbContext<ArgenMotoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Server=RAguirre;Database=ArgenMoto;Trusted_Connection=True;Encrypt=False;")));

builder.Services.AddControllers();

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IArticuloRepository, ArticuloRepository>();
builder.Services.AddScoped<IFacturaRepository, FacturaRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();


builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "ArgenMoto API",
        Version = "v1",
        Description = "API para sistema de gestión de ArgenMoto"
    });
});


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000")
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

app.UseCors("AllowReactApp");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
