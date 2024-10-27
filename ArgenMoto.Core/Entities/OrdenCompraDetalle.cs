namespace ArgenMoto.Core.Entities
{
    public class OrdenCompraDetalle
    {
        public int Id { get; set; }
        public int IdOrdenCompra { get; set; }
        public int IdArticulo { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }

        public virtual Articulo Articulo { get; set; } = null!;
        public virtual OrdenesCompra OrdenesCompra { get; set; } = null!;
    }
}
