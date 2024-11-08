using Microsoft.EntityFrameworkCore;
using Trabajo.Api.Services;
using Trabajo.Api.Models;

var builder = WebApplication.CreateBuilder(args);

// Configuración del DbContext con MySQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 39)),
        mySqlOptions => mySqlOptions.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null) // Configuración de reintento en caso de fallos de conexión
    )
);

// Agregar EmployeeService al contenedor de dependencias (DI)
builder.Services.AddScoped<EmployeeService>();

// Agregar servicios al contenedor
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuración del pipeline de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
