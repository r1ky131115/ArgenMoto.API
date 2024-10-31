namespace ArgenMoto.Core.Entities;

public class Carrito
{
    public int Id { get; set; }
    public int IdCliente { get; set; }
    public DateOnly FechaCreacion { get; set; }

    public virtual ICollection<CarritoDetalle> CarritoDetalles { get; set; } = new List<CarritoDetalle>();
    public virtual Cliente Cliente { get; set; } = null!;
}
