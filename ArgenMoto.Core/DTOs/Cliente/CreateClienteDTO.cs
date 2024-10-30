using System;

namespace ArgenMoto.Core.DTOs.Cliente
{
    public class CreateClienteDTO
    {
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Domicilio { get; set; }
        public string Localidad { get; set; }
        public string Provincia { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
    }
}
