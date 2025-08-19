namespace SistemaVenta.Entidades
{
    public class PuntoEmision
    {
        public int Id { get; set; }
        public string? lugaEmision {get; set;}
        public int estado { get; set; } = 0;
        public DateTime fechaHoraReg { get; set;} = DateTime.Now;

        public int usuarioId { get; set; }
    }
}
