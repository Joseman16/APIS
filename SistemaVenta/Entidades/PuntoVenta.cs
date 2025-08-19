using SistemaVenta.Datos;

namespace SistemaVenta.Entidades
{
    public class PuntoVenta
    {
        public int Id { get; set; }  
        public string? PuntovtaNombre { get; set; }

        public int PuntoEmisionId { get; set; }

        public int? Estado { get; set; } = 0;

        public DateTime FechaHoraReg { get; set; }

        public int UsuarioId { get; set; }

    }
}
