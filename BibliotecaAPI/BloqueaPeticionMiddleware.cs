namespace BibliotecaAPI
{
    public class BloqueaPeticionMiddleware
    {
        private readonly RequestDelegate next;
        public BloqueaPeticionMiddleware(RequestDelegate next)
        {
            this.next = next;

        }

        public async Task InvokeAsync(HttpContext contexto)
        {
            if (contexto.Request.Path == "/bloqueado")
            {
                contexto.Response.StatusCode = 403; //403 = prohibido
                await contexto.Response.WriteAsync("Acceso denegado");
            }
            else
            {
                await next.Invoke(contexto); //Invoco el siguiente middleware en la tuberia
            }
        }
    }

    // Mover la clase de extensión fuera de BloqueaPeticionMiddleware y hacerla estática de nivel superior
    public static class BloqueaPeticionMiddlewareExtensions
    {
        //UseBloqueaPeticion es un metodo de extensión
        public static IApplicationBuilder UseBloqueaPeticion(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<BloqueaPeticionMiddleware>();
        }
    }
}
