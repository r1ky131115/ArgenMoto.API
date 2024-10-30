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

        public virtual DbSet<Carrito> Carritos { get; set; }

        public virtual DbSet<CarritoDetalle> CarritoDetalles { get; set; }

        public virtual DbSet<Cliente> Clientes { get; set; }

        public virtual DbSet<Factura> Facturas { get; set; }

        public virtual DbSet<FormasCobro> FormasCobros { get; set; }

        public virtual DbSet<HistorialPedido> HistorialPedidos { get; set; }

        public virtual DbSet<OrdenCompraDetalle> OrdenCompraDetalles { get; set; }

        public virtual DbSet<OrdenesCompra> OrdenesCompras { get; set; }

        public virtual DbSet<Proveedor> Proveedores { get; set; }

        public virtual DbSet<Repuesto> Repuestos { get; set; }

        public virtual DbSet<Tecnico> Tecnicos { get; set; }

        public virtual DbSet<TurnosPreventa> TurnosPreventa { get; set; }

        public virtual DbSet<Usuario> Usuarios { get; set; }

        public virtual DbSet<Vendedor> Vendedores { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    => optionsBuilder.UseSqlServer("Server=RAguirre;Database=ArgenMoto;Trusted_Connection=True;Encrypt=False;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Articulo>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Articulo__3213E83F24ACB216");

                entity.HasIndex(e => e.Codigo, "UK_Articulo_Codigo").IsUnique();

                entity.HasIndex(e => e.Codigo, "UQ__Articulo__40F9A206D7A99EBD").IsUnique();

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
                    .HasConstraintName("FK__Articulos__id_pr__48CFD27E");
            });

            modelBuilder.Entity<Carrito>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Carrito__3213E83F557B6944");

                entity.ToTable("Carrito");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.FechaCreacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnName("fecha_creacion");
                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.HasOne(d => d.Cliente).WithMany(p => p.Carritos)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Carrito__id_clie__6B24EA82");
            });

            modelBuilder.Entity<CarritoDetalle>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__CarritoD__3213E83F1593E070");

                entity.ToTable("CarritoDetalle");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Cantidad).HasColumnName("cantidad");
                entity.Property(e => e.IdArticulo).HasColumnName("id_articulo");
                entity.Property(e => e.IdCarrito).HasColumnName("id_carrito");
                entity.Property(e => e.Precio)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("precio");

                entity.HasOne(d => d.Articulo).WithMany(p => p.CarritoDetalles)
                    .HasForeignKey(d => d.IdArticulo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CarritoDe__id_ar__6EF57B66");

                entity.HasOne(d => d.Carrito).WithMany(p => p.CarritoDetalles)
                    .HasForeignKey(d => d.IdCarrito)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CarritoDe__id_ca__6E01572D");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Clientes__3213E83F7E246130");

                entity.HasIndex(e => new { e.TipoDocumento, e.NumeroDocumento }, "UK_Cliente_NumDoc").IsUnique();

                entity.HasIndex(e => e.IdUsuario, "UQ__Clientes__4E3E04AC7D6C94C7").IsUnique();

                entity.HasIndex(e => e.NumeroDocumento, "UQ__Clientes__7B886A63188F3C92").IsUnique();

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
                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
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

                entity.HasOne(d => d.Usuario).WithOne(p => p.Cliente)
                    .HasForeignKey<Cliente>(d => d.IdUsuario)
                    .HasConstraintName("FK__Clientes__id_usu__403A8C7D");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Factura__3213E83F9F39A699");

                entity.ToTable("Factura");

                entity.HasIndex(e => e.NumeroPedido, "UQ__Factura__7F98F76D11BE6CA1").IsUnique();

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
                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
                entity.Property(e => e.IdFormaCobro).HasColumnName("id_forma_cobro");
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

                entity.HasOne(d => d.Cliente).WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Factura__id_clie__6383C8BA");

                entity.HasOne(d => d.FormasCobro).WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.IdFormaCobro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Factura__id_form__628FA481");
            });

            modelBuilder.Entity<FormasCobro>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__FormasCo__3213E83FEFC577FB");

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

            modelBuilder.Entity<HistorialPedido>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Historia__3213E83FA7817EDA");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Estado)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValue("Pendiente")
                    .HasColumnName("estado");
                entity.Property(e => e.FechaPedido).HasColumnName("fecha_pedido");
                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
                entity.Property(e => e.IdFactura).HasColumnName("id_factura");

                entity.HasOne(d => d.Cliente).WithMany(p => p.HistorialPedidos)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Historial__id_cl__72C60C4A");

                entity.HasOne(d => d.IdFacturaNavigation).WithMany(p => p.HistorialPedidos)
                    .HasForeignKey(d => d.IdFactura)
                    .HasConstraintName("FK__Historial__id_fa__73BA3083");
            });

            modelBuilder.Entity<OrdenCompraDetalle>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__OrdenCom__3213E83F8C645751");

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
                    .HasConstraintName("FK__OrdenComp__id_ar__6754599E");

                entity.HasOne(d => d.OrdenesCompra).WithMany(p => p.OrdenCompraDetalles)
                    .HasForeignKey(d => d.IdOrdenCompra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrdenComp__id_or__66603565");
            });

            modelBuilder.Entity<OrdenesCompra>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__OrdenesC__3213E83F4573FFE3");

                entity.ToTable("OrdenesCompra");

                entity.HasIndex(e => e.Numero, "UQ__OrdenesC__FC77F211364AE46D").IsUnique();

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
                entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");
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

                entity.HasOne(d => d.Proveedor).WithMany(p => p.OrdenesCompras)
                    .HasForeignKey(d => d.IdProveedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrdenesCo__id_pr__5BE2A6F2");
            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Proveedo__3213E83FAF828D86");

                entity.HasIndex(e => e.Cuit, "UK_Proveedor_CUIT").IsUnique();

                entity.HasIndex(e => e.Cuit, "UQ__Proveedo__2CDD9897BD71A0F0").IsUnique();

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
                entity.HasKey(e => e.Id).HasName("PK__Repuesto__3213E83F15C2F65F");

                entity.HasIndex(e => e.Codigo, "UK_Repuestos_Codigo").IsUnique();

                entity.HasIndex(e => e.Codigo, "UQ__Repuesto__40F9A2062310C31E").IsUnique();

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
                    .HasConstraintName("FK__Repuestos__id_ar__4D94879B");

                entity.HasOne(d => d.Proveedor).WithMany(p => p.Repuestos)
                    .HasForeignKey(d => d.IdProveedor)
                    .HasConstraintName("FK__Repuestos__id_pr__4E88ABD4");
            });

            modelBuilder.Entity<Tecnico>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Tecnicos__3213E83FD0FEE122");

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
                entity.HasKey(e => e.Id).HasName("PK__TurnosPr__3213E83FD4A292D8");

                entity.ToTable(tb => tb.HasTrigger("trg_generar_numero_turno"));

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
                    .HasConstraintName("FK__TurnosPre__id_ar__571DF1D5");

                entity.HasOne(d => d.Cliente).WithMany(p => p.TurnosPreventa)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TurnosPre__id_cl__5629CD9C");

                entity.HasOne(d => d.Tecnico).WithMany(p => p.TurnosPreventa)
                    .HasForeignKey(d => d.IdTecnico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TurnosPre__id_te__5812160E");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Usuarios__3213E83FD2A22026");

                entity.HasIndex(e => e.Email, "UQ__Usuarios__AB6E6164D06CC633").IsUnique();

                entity.HasIndex(e => e.Username, "UQ__Usuarios__F3DBC572CA46122E").IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");
                entity.Property(e => e.Estado)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValue("Activo")
                    .HasColumnName("estado");
                entity.Property(e => e.FechaCreacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnName("fecha_creacion");
                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("password_hash");
                entity.Property(e => e.Rol)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("rol");
                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Vendedor>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Vendedor__3213E83F6B4413B6");

                entity.HasIndex(e => e.NumeroDocumento, "UQ__Vendedor__7B886A63187AB1BA").IsUnique();

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
