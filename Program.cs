using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using MicroservicioMateria.Data;

var builder = WebApplication.CreateBuilder(args);

// ---------------------------------------------
// CONFIGURAR SQL SERVER (usa tu connectionString)
// ---------------------------------------------
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ---------------------------------------------
// CONFIGURAR CONTROLADORES Y API
// ---------------------------------------------
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ---------------------------------------------
// MIDDLEWARE
// ---------------------------------------------
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// ---------------------------------------------
// EJECUTAR MIGRACIONES AUTOMÁTICAMENTE (opcional)
// ---------------------------------------------
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

app.Run();
