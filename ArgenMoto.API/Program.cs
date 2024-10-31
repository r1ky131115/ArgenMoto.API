using Serilog;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ArgenMoto.Infrastructure.Data;
using Microsoft.OpenApi.Models;
using ArgenMoto.Core.Interfaces;
using ArgenMoto.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ArgenMoto.Core.Utils;
using ArgenMoto.API.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Configuraci�n de Serilog
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/argen-moto-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();
builder.Host.UseSerilog();

// Configuraci�n del contexto de la base de datos
builder.Services.AddDbContext<ArgenMotoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ArgenMotoDatabase")));

builder.Services.AddControllers();

// Configuraci�n de los repositorios
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IArticuloRepository, ArticuloRepository>();
builder.Services.AddScoped<IFacturaRepository, FacturaRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IProveedorRepository, ProveedorRepository>();
builder.Services.AddScoped<ITurnoRepository, TurnoRepository>();

// Configuraci�n de PasswordHasher y JwtService
builder.Services.AddSingleton<IPasswordHasher, PasswordHasher>();
builder.Services.AddSingleton<IJwtService>(provider => new JwtService(builder.Configuration["Jwt:SecretKey"]));

// Configuraci�n de autenticaci�n JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"])),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

// Configuraci�n de AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

// Configuraci�n de Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "ArgenMoto API",
        Version = "v1",
        Description = "API para sistema de gesti�n de ArgenMoto"
    });
});

// Configuraci�n de CORS
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

// Configuraci�n de la tuber�a de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowReactApp");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
