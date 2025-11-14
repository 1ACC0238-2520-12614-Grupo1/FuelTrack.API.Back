using Microsoft.OpenApi.Models;

using FuelTrack.API.Back.Services.Auth;
using FuelTrack.API.Back.Services.Orders;
using FuelTrack.API.Back.Services.Tariffs;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "FuelTrack.API.Back",
        Version = "v1",
        Description = "API backend de FuelTrack para gestionar login, pedidos de clientes y tarifas de proveedores.",
        Contact = new OpenApiContact
        {
            Name = "Bryan Ronald Espejo Gamarra",
            Email = "u202213278@upc.edu.pe"
            // Url = new Uri("https://github.com/SaeBryxn") // opcional
        },
        License = new OpenApiLicense
        {
            Name = "Uso académico - UPC"
        }
    });
});

// Dependency Injection de servicios
builder.Services.AddSingleton<IAuthService, AuthService>();
builder.Services.AddSingleton<IClientOrderService, ClientOrderService>();
builder.Services.AddSingleton<ISupplierOrderService, SupplierOrderService>();
builder.Services.AddSingleton<ITariffService, TariffService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();