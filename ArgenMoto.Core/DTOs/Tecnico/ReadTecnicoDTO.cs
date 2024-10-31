using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgenMoto.Core.DTOs.Tecnico
{
    public class ReadTecnicoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Especialidad { get; set; }
    }
}
