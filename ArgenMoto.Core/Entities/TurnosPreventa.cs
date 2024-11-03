using System;

namespace ArgenMoto.Core.Entities
{
    public class TurnosPreventa
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string? Hora { get; set; }
        public int IdCliente { get; set; }
        public int IdArticulo { get; set; }
        public int IdTecnico { get; set; }
        public string Estado { get; set; } = "Pendiente";
        public string NumeroTurno { get; set; }

        public virtual Articulo Articulo { get; set; } = null!;
        public virtual Cliente Cliente { get; set; } = null!;
        public virtual Tecnico Tecnico { get; set; } = null!;
    }
}
