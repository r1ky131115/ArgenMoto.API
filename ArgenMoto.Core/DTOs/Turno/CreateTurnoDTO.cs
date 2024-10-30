using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgenMoto.Core.DTOs.Turno
{
    public class CreateTurnoDTO
    {
        public int IdCliente { get; set; }
        public int IdArticulo { get; set; }
        public int IdTecnico { get; set; }
        public DateOnly Fecha { get; set; }
        public string? Hora { get; set; }
    }
}
