using BibliotecaAPI.Entidades;

namespace BibliotecaAPI
{
    public class RepositorioValores: IRepositorioValores
    {
        public IEnumerable<Valor> ObtenerValores()
        {
            return new List<Valor>
            {
                new Valor { Id = 1, Nombre = "valor 1"},
                new Valor { Id = 1, Nombre = "valor 1"}
            };
        }
    }
}
