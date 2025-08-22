using ERP.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// -----------------------------
// 1) Registrar servicios ANTES de builder.Build()
// -----------------------------

// Razor Pages (si vas a usar p�ginas)
builder.Services.AddRazorPages();

// Controladores con JSON (si usar�s API)
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

// Agregar DbContext con la cadena de conexi�n
builder.Services.AddDbContext<BaseErpContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BaseERP"));
});


// -----------------------------
// 2) Construir la aplicaci�n
// -----------------------------
var app = builder.Build();

// -----------------------------
// 3) Configurar el pipeline
// -----------------------------
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers(); // importante para tus APIs

app.Run();
