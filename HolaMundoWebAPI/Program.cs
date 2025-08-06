
/*Tipos de valor y Tipos de referncia

//Tipo de valor: Es cuando la variable contiene la instancia del tipo
int edad = 90; //ejemplo de tipo valor...

//Tipo de referencia: Es cuando la variable contiene una referencia a la instancia del tipo
string? nombre = "Josman";
nombre = null;

if(nombre is not null)
{
    nombre.ToUpper();
}
*/




var builder = WebApplication.CreateBuilder(args);

var cadenaDeConexion = builder.Configuration.GetValue<string>("cadenaDeConexion");

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapGet("/", () => cadenaDeConexion);

app.Run();
