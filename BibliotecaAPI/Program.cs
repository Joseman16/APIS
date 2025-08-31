using BibliotecaAPI;
using BibliotecaAPI.Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Area de servicios
builder.Services.AddRazorPages();

builder.Services.AddTransient<ServicioTransient>();
builder.Services.AddScoped<ServicioScoped>();
builder.Services.AddSingleton<ServicioSingleton>();

builder.Services.AddTransient<IRepositorioValores, RepositorioValores>();
builder.Services.AddSingleton<IRepositorioValores, RepositorioValoresOracle>();


builder.Services.AddControllers().AddJsonOptions(opciones => 
    opciones.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddDbContext<ApplicationDbContext>(opciones =>
opciones.UseSqlServer("name=DefaultConnection"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//área de los middlewares

/*app.Use(async (contexto, next) =>
{
    //Guardamos en el log, la información de la petición HTTP
    var logger = contexto.RequestServices.GetRequiredService<ILogger<Program>>();
    logger.LogInformation($"Peticion: {contexto.Request.Method} {contexto.Request.Path}");

    //Este invoke, me permite invocar el resto de la tuberia de pipeline (el resto de los middlewares)
    await next.Invoke();
    //YO quiero guardar la información acerca de la respuesta HTTP
    logger.LogInformation($"Respuesta: {contexto.Response.StatusCode}"); 
});*/

app.UseLoguearPeticion();

app.UseBloqueaPeticion();

/*app.Use(async (contexto, next) =>
{
    if (contexto.Request.Path == "/bloqueado")
    {
        contexto.Response.StatusCode = 403; //403 = prohibido
        await contexto.Response.WriteAsync("Acceso denegado");
    }
    else
    {
        await next.Invoke();
    }
});*/

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.MapRazorPages();

app.Run();




