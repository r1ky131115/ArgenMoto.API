using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgenMoto.Core.DTOs.Turno
{
    public class UpdateTurnoDTO
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }
        public byte estado { get; set; }
        public int IdCliente { get; set; }
        public int IdArticulo { get; set; }
        public int IdTecnico { get; set; }
    }
}
