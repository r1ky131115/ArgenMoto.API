using System;
using System.Collections.Generic;

namespace ArgenMoto.Core.Entities;

public class HistorialPedido
{
    public int Id { get; set; }
    public int IdCliente { get; set; }
    public DateOnly FechaPedido { get; set; }
    public string Estado { get; set; } = null!;
    public int? IdFactura { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;
    public virtual Factura? IdFacturaNavigation { get; set; }
}
