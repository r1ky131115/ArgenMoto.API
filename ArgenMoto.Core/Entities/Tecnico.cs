using System.Collections.Generic;

namespace ArgenMoto.Core.Entities
{
    public class Tecnico
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Especialidad { get; set; }

        public virtual ICollection<TurnosPreventa> TurnosPreventa { get; set; } = new List<TurnosPreventa>();
    }
}
