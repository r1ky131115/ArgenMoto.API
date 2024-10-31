namespace ArgenMoto.Core.Entities;

public class CarritoDetalle
{
    public int Id { get; set; }
    public int IdCarrito { get; set; }
    public int IdArticulo { get; set; }
    public int Cantidad { get; set; }
    public decimal Precio { get; set; }

    public virtual Articulo Articulo { get; set; } = null!;
    public virtual Carrito Carrito { get; set; } = null!;
}
