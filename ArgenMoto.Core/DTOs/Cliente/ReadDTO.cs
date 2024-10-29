using ArgenMoto.Core.Entities;
using System;
using System.Collections.Generic;

namespace ArgenMoto.Core.DTOs.Cliente
{
    public class ReadDTO
    {
        public int Id { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string? RazonSocial { get; set; }
        public string? Apellido { get; set; }
        public string Nombre { get; set; }
        public string? Domicilio { get; set; }
        public string? Localidad { get; set; }
        public string? Provincia { get; set; }
        public string? Telefono { get; set; }
        public string Email { get; set; }
    }

    public class test
    {
        public int Id { get; set; }
        public string TipoDocumento { get; set; } = null!;
        public string NumeroDocumento { get; set; } = null!;
        public string? RazonSocial { get; set; }
        public string? Apellido { get; set; }
        public string Nombre { get; set; } = null!;
        public DateOnly FechaRegistro { get; set; }
        public string? Domicilio { get; set; }
        public string? Localidad { get; set; }
        public string? Provincia { get; set; }
        public string? Telefono { get; set; }
        public string Email { get; set; } = null!;

        public virtual ICollection<OrdenesCompra> OrdenesCompras { get; set; } = new List<OrdenesCompra>();

        public virtual ICollection<TurnosPreventa> TurnosPreventa { get; set; } = new List<TurnosPreventa>();
    }
}
