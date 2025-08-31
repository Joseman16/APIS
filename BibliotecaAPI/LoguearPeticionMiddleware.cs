namespace BibliotecaAPI
{
    public class LoguearPeticionMiddleware
    {
        readonly RequestDelegate next;

        public LoguearPeticionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext contexto)
        {
            //Viene la petición HTTP
            var logger = contexto.RequestServices.GetRequiredService<ILogger<Program>>();
            logger.LogInformation($"Peticion: {contexto.Request.Method} {contexto.Request.Path}");

            await next.Invoke(contexto); //Invoco el siguiente middleware en la tuberia

            //Se va la respiesta HTTP
            logger.LogInformation($"Respuesta: {contexto.Response.StatusCode}");

        }
    }

    public static class LoguearPeticionMiddlewareExtensions
    {
        //UseLoguearPeticion es un metodo de extensión
        public static IApplicationBuilder UseLoguearPeticion(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoguearPeticionMiddleware>();
        }
    }
}
