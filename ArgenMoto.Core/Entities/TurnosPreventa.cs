using System;

namespace ArgenMoto.Core.Entities
{
    public class TurnosPreventa
    {
        public int Id { get; set; }
        public DateOnly Fecha { get; set; }
        public string? Hora { get; set; }
        public string? NumeroTurno { get; set; }
        public int IdCliente { get; set; }
        public int IdArticulo { get; set; }
        public int IdTecnico { get; set; }

        public virtual Articulo Articulo { get; set; } = null!;
        public virtual Cliente Cliente { get; set; } = null!;
        public virtual Tecnico Tecnico { get; set; } = null!;
    }
}
