﻿using System;

namespace ArgenMoto.Core.Entities
{
    public partial class Factura
    {
        public int Id { get; set; }
        public string NumeroPedido { get; set; } = null!;
        public DateOnly Fecha { get; set; }
        public string Apellido { get; set; } = null!;
        public string? Descripcion { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
        public decimal? Descuento { get; set; }
        public decimal MontoTotal { get; set; }
        public string? Iva { get; set; }
        public string? Estado { get; set; }
        public int IdOrdenCompra { get; set; }
        public int IdFormaCobro { get; set; }

        public virtual FormasCobro FormasCobro { get; set; } = null!;
        public virtual OrdenesCompra OrdenesCompra { get; set; } = null!;
    }
}
