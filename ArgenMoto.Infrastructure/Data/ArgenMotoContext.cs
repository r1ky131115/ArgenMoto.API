using ArgenMoto.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ArgenMoto.Infrastructure.Data
{

    public partial class ArgenMotoContext : DbContext
    {
        public ArgenMotoContext()
        {
        }

        public ArgenMotoContext(DbContextOptions<ArgenMotoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Articulo> Articulos { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Factura> Facturas { get; set; }
        public virtual DbSet<FormasCobro> FormasCobros { get; set; }
        public virtual DbSet<OrdenCompraDetalle> OrdenCompraDetalles { get; set; }
        public virtual DbSet<OrdenesCompra> OrdenesCompras { get; set; }
        public virtual DbSet<Proveedor> Proveedores { get; set; }
        public virtual DbSet<Repuesto> Repuestos { get; set; }
        public virtual DbSet<Tecnico> Tecnicos { get; set; }
        public virtual DbSet<TurnosPreventa> TurnosPreventa { get; set; }
        public virtual DbSet<Vendedor> Vendedores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Server=RAguirre;Database=ArgenMoto;Trusted_Connection=True;Encrypt=False;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Articulo>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Articulo__3213E83F6D4B6573");

                entity.HasIndex(e => e.Codigo, "UK_Articulo_Codigo").IsUnique();

                entity.HasIndex(e => e.Codigo, "UQ__Articulo__40F9A2060BAE0ECD").IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Año)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("año");
                entity.Property(e => e.Cilindrada)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cilindrada");
                entity.Property(e => e.Codigo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("codigo");
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");
                entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");
                entity.Property(e => e.Marca)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("marca");
                entity.Property(e => e.Modelo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("modelo");
                entity.Property(e => e.Motor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("motor");
                entity.Property(e => e.NroChasis)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nro_chasis");
                entity.Property(e => e.Precio)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("precio");
                entity.Property(e => e.StockActual)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("stock_actual");
                entity.Property(e => e.StockMaximo)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("stock_maximo");
                entity.Property(e => e.StockMinimo)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("stock_minimo");

                entity.HasOne(d => d.Proveedor).WithMany(p => p.Articulos)
                    .HasForeignKey(d => d.IdProveedor)
                    .HasConstraintName("FK__Articulos__id_pr__412EB0B6");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Clientes__3213E83F88899310");

                entity.HasIndex(e => new { e.TipoDocumento, e.NumeroDocumento }, "UK_Cliente_NumDoc").IsUnique();

                entity.HasIndex(e => e.NumeroDocumento, "UQ__Clientes__7B886A63521331EC").IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Apellido)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("apellido");
                entity.Property(e => e.Domicilio)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("domicilio");
                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");
                entity.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
                entity.Property(e => e.Localidad)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("localidad");
                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
                entity.Property(e => e.NumeroDocumento)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("numero_documento");
                entity.Property(e => e.Provincia)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("provincia");
                entity.Property(e => e.RazonSocial)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("razon_social");
                entity.Property(e => e.Telefono)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("telefono");
                entity.Property(e => e.TipoDocumento)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tipo_documento");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Factura__3213E83F6377C977");

                entity.ToTable("Factura");

                entity.HasIndex(e => e.NumeroPedido, "UQ__Factura__7F98F76DB0DEE3D6").IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Apellido)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("apellido");
                entity.Property(e => e.Cantidad).HasColumnName("cantidad");
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");
                entity.Property(e => e.Descuento)
                    .HasDefaultValue(0m)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("descuento");
                entity.Property(e => e.Estado)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("estado");
                entity.Property(e => e.Fecha).HasColumnName("fecha");
                entity.Property(e => e.IdFormaCobro).HasColumnName("id_forma_cobro");
                entity.Property(e => e.IdOrdenCompra).HasColumnName("id_orden_compra");
                entity.Property(e => e.Iva)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("iva");
                entity.Property(e => e.MontoTotal)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("monto_total");
                entity.Property(e => e.NumeroPedido)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("numero_pedido");
                entity.Property(e => e.PrecioUnitario)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("precio_unitario");
                entity.Property(e => e.Subtotal)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("subtotal");

                entity.HasOne(d => d.FormasCobro).WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.IdFormaCobro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Factura__id_form__5BE2A6F2");

                entity.HasOne(d => d.OrdenesCompra).WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.IdOrdenCompra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Factura__id_orde__5AEE82B9");
            });

            modelBuilder.Entity<FormasCobro>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__FormasCo__3213E83F7417BAF3");

                entity.ToTable("FormasCobro");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Detalle)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("detalle");
                entity.Property(e => e.Tipo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("tipo");
            });

            modelBuilder.Entity<OrdenCompraDetalle>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__OrdenCom__3213E83F892986D9");

                entity.ToTable("OrdenCompraDetalle");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Cantidad).HasColumnName("cantidad");
                entity.Property(e => e.IdArticulo).HasColumnName("id_articulo");
                entity.Property(e => e.IdOrdenCompra).HasColumnName("id_orden_compra");
                entity.Property(e => e.Precio)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("precio");

                entity.HasOne(d => d.Articulo).WithMany(p => p.OrdenCompraDetalles)
                    .HasForeignKey(d => d.IdArticulo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrdenComp__id_ar__5FB337D6");

                entity.HasOne(d => d.OrdenesCompra).WithMany(p => p.OrdenCompraDetalles)
                    .HasForeignKey(d => d.IdOrdenCompra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrdenComp__id_or__5EBF139D");
            });

            modelBuilder.Entity<OrdenesCompra>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__OrdenesC__3213E83FFA6B9B86");

                entity.ToTable("OrdenesCompra");

                entity.HasIndex(e => e.Numero, "UQ__OrdenesC__FC77F2116132FCA8").IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Cantidad).HasColumnName("cantidad");
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");
                entity.Property(e => e.Domicilio)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("domicilio");
                entity.Property(e => e.Estado)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("estado");
                entity.Property(e => e.Fecha).HasColumnName("fecha");
                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
                entity.Property(e => e.Iva)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("iva");
                entity.Property(e => e.Localidad)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("localidad");
                entity.Property(e => e.Numero)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("numero");
                entity.Property(e => e.PrecioMario)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("precio_mario");
                entity.Property(e => e.PrecioReal)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("precio_real");
                entity.Property(e => e.PrecioTotal)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("precio_total");
                entity.Property(e => e.Provincia)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("provincia");
                entity.Property(e => e.RazonSocial)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("razon_social");

                entity.HasOne(d => d.Cliente).WithMany(p => p.OrdenesCompras)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrdenesCo__id_cl__5441852A");
            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Proveedo__3213E83F0EE07311");

                entity.HasIndex(e => e.Cuit, "UK_Proveedor_CUIT").IsUnique();

                entity.HasIndex(e => e.Cuit, "UQ__Proveedo__2CDD989720F83ACE").IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Apellido)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("apellido");
                entity.Property(e => e.Categoria)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("categoria");
                entity.Property(e => e.Cuit)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cuit");
                entity.Property(e => e.Domicilio)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("domicilio");
                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");
                entity.Property(e => e.Localidad)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("localidad");
                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
                entity.Property(e => e.Provincia)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("provincia");
                entity.Property(e => e.RazonSocial)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("razon_social");
                entity.Property(e => e.Telefono)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("telefono");
            });

            modelBuilder.Entity<Repuesto>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Repuesto__3213E83FC7165988");

                entity.HasIndex(e => e.Codigo, "UK_Repuestos_Codigo").IsUnique();

                entity.HasIndex(e => e.Codigo, "UQ__Repuesto__40F9A20613C6A1A6").IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Codigo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("codigo");
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");
                entity.Property(e => e.IdArticulo).HasColumnName("id_articulo");
                entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");
                entity.Property(e => e.Marca)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("marca");
                entity.Property(e => e.Modelo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("modelo");
                entity.Property(e => e.Precio)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("precio");
                entity.Property(e => e.StockActual)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("stock_actual");
                entity.Property(e => e.StockMaximo)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("stock_maximo");
                entity.Property(e => e.StockMinimo)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("stock_minimo");

                entity.HasOne(d => d.Articulo).WithMany(p => p.Repuestos)
                    .HasForeignKey(d => d.IdArticulo)
                    .HasConstraintName("FK__Repuestos__id_ar__45F365D3");

                entity.HasOne(d => d.Proveedor).WithMany(p => p.Repuestos)
                    .HasForeignKey(d => d.IdProveedor)
                    .HasConstraintName("FK__Repuestos__id_pr__46E78A0C");
            });

            modelBuilder.Entity<Tecnico>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Tecnicos__3213E83F1CC810EF");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Especialidad)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("especialidad");
                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<TurnosPreventa>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__TurnosPr__3213E83FA4B8B2EA");

                entity.ToTable(tb => tb.HasTrigger("trg_GenerarNumeroTurno"));

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Fecha).HasColumnName("fecha");
                entity.Property(e => e.Hora)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("hora");
                entity.Property(e => e.IdArticulo).HasColumnName("id_articulo");
                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
                entity.Property(e => e.IdTecnico).HasColumnName("id_tecnico");
                entity.Property(e => e.NumeroTurno)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("numero_turno");

                entity.HasOne(d => d.Articulo).WithMany(p => p.TurnosPreventa)
                    .HasForeignKey(d => d.IdArticulo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TurnosPre__id_ar__4F7CD00D");

                entity.HasOne(d => d.Cliente).WithMany(p => p.TurnosPreventa)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TurnosPre__id_cl__4E88ABD4");

                entity.HasOne(d => d.Tecnico).WithMany(p => p.TurnosPreventa)
                    .HasForeignKey(d => d.IdTecnico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TurnosPre__id_te__5070F446");
            });

            modelBuilder.Entity<Vendedor>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Vendedor__3213E83FD2C9173B");

                entity.HasIndex(e => e.NumeroDocumento, "UQ__Vendedor__7B886A63BA4D29A8").IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Apellido)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("apellido");
                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
                entity.Property(e => e.NumeroDocumento)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("numero_documento");
                entity.Property(e => e.TipoDocumento)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tipo_documento");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
