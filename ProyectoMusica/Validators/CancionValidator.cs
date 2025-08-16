using ProyectoMusica.Models;

namespace ProyectoMusica.Validators
{
    public class CancionValidator
    {
        public static bool EsValida(Cancion cancion)
        {
            if (string.IsNullOrWhiteSpace(cancion.Titulo))
                return false;
            if (cancion.CantanteId <= 0 || cancion.GeneroId <= 0)
                return false;

            return true;
        }
    }
}
