using ERP2.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// ===========================
// 1️⃣ Configurar servicios
// ===========================

// Agregar Razor Pages
builder.Services.AddRazorPages();

// Configurar DbContext con SQL Server
// Asegúrate de tener la cadena de conexión en appsettings.json
// Ejemplo de appsettings.json:
// {
//   "ConnectionStrings": {
//       "BaseERP": "Server=DESKTOP-KCFLU5L\\SQLEXPRESS;Database=BASE_ERP;Trusted_Connection=True;"
//   }
// }

builder.Services.AddDbContext<BaseErpContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BaseERP")));


// Opcional: evitar problemas con ciclos de referencia en JSON
builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// ===========================
// 2️⃣ Construir la aplicación
// ===========================
var app = builder.Build();

// ===========================
// 3️⃣ Configurar pipeline HTTP
// ===========================

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Mapear Razor Pages y controladores
app.MapRazorPages();
app.MapControllers(); // si usaras API

// ===========================
// 4️⃣ Ejecutar la aplicación
// ===========================
app.Run();

