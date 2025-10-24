using CarBrand.Infraestructure;
using CardBrand.Application;
using CarBrand.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

builder.Services.AddInfraestructureServices(builder.Configuration);
builder.Services.AddApplicationServices();

var app = builder.Build();

//Aplicar Migraciones despues de registrar el servicio de contexto
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<CarBrandContext>();
    
    var maxRetries = 10;
    var delay = TimeSpan.FromSeconds(5);

    for (int attempt = 1; attempt <= maxRetries; attempt++)
    {
        try
        {
            dbContext.Database.Migrate();
            Console.WriteLine("✅ Migración completada.");
            break;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"⏳ Intento {attempt}: PostgreSQL no está listo. Error: {ex.Message}");
            if (attempt == maxRetries)
            {
                Console.WriteLine("❌ No se pudo conectar a la base de datos después de varios intentos.");
                throw;
            }
            Thread.Sleep(delay);
        }
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
