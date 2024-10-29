PRINT N'Creando tabla de usuarios'
DROP TABLE IF EXISTS Usuarios;
CREATE TABLE Usuarios (
    id INT IDENTITY(1,1) PRIMARY KEY,
    username VARCHAR(50) NOT NULL UNIQUE,
    password_hash VARCHAR(255) NOT NULL, -- Para almacenar un hash de la contraseña
    rol VARCHAR(50) NOT NULL, -- 'Cliente' o 'Administrador'
    email VARCHAR(100) NOT NULL UNIQUE,
    fecha_creacion DATE NOT NULL DEFAULT GETDATE(),
    estado VARCHAR(50) NOT NULL DEFAULT 'Activo'
);
PRINT N'Tabla de usuarios creada'

PRINT N'Creando tabla de clientes'
drop table if exists Clientes;
CREATE TABLE Clientes (
    id INT IDENTITY(1,1) PRIMARY KEY,
    id_usuario INT UNIQUE,
    tipo_documento VARCHAR(50) NOT NULL,
    numero_documento VARCHAR(50) NOT NULL UNIQUE,
    razon_social VARCHAR(100),    
    apellido VARCHAR(100),
    nombre VARCHAR(100) NOT NULL,
    fecha_registro DATE NOT NULL,
    domicilio VARCHAR(100),       
    localidad VARCHAR(100),
    provincia VARCHAR(100),       
    telefono VARCHAR(20),
    email VARCHAR(100) NOT NULL,
    FOREIGN KEY (id_usuario) REFERENCES Usuarios(id),
    CONSTRAINT UK_Cliente_NumDoc UNIQUE (tipo_documento, numero_documento)
);
PRINT N'Tabla de clientes creada'


PRINT N'Creando tabla de proovedores'
drop table if exists Proovedores;
CREATE TABLE Proveedores (
    id INT IDENTITY(1,1) PRIMARY KEY,
    cuit VARCHAR(50) NOT NULL UNIQUE,
    razon_social VARCHAR(100),    
    apellido VARCHAR(100) NOT NULL,
    nombre VARCHAR(100) NOT NULL,
    domicilio VARCHAR(100),
    localidad VARCHAR(100),
    provincia VARCHAR(100),
    telefono VARCHAR(20),
    email VARCHAR(100) NOT NULL,
    categoria VARCHAR(100),
    CONSTRAINT UK_Proveedor_CUIT UNIQUE (cuit)
);
PRINT N'Tabla de proovedores creada'


PRINT N'Creando tabla de articulos'
drop table if exists Articulos;
CREATE TABLE Articulos (
    id INT IDENTITY(1,1) PRIMARY KEY,
    codigo VARCHAR(50) NOT NULL UNIQUE,
    descripcion VARCHAR(255) NOT NULL,  
    stock_minimo DECIMAL(10,2),           
    stock_maximo DECIMAL(10,2),
    stock_actual DECIMAL(10,2),
    precio DECIMAL(10, 2) NOT NULL,
    marca VARCHAR(50) NOT NULL,
    modelo VARCHAR(50) NOT NULL,
    motor VARCHAR(50),                    
    nro_chasis VARCHAR(50),               
    año VARCHAR(4),                       
    cilindrada VARCHAR(50),               
    id_proveedor INT,                     
    FOREIGN KEY (id_proveedor) REFERENCES Proveedores(id),
    CONSTRAINT UK_Articulo_Codigo UNIQUE (codigo)
);
PRINT N'Tabla de articulos creada'


PRINT N'Creando tabla de Repuestos'
drop table if exists Repuestos;
CREATE TABLE Repuestos (
    id INT IDENTITY(1,1) PRIMARY KEY,
    codigo VARCHAR(50) NOT NULL UNIQUE,
    descripcion VARCHAR(255) NOT NULL,
    stock_minimo DECIMAL(10,2),
    stock_maximo DECIMAL(10,2),
    stock_actual DECIMAL(10,2),
    precio DECIMAL(10, 2) NOT NULL,
    marca VARCHAR(50) NOT NULL,
    modelo VARCHAR(50) NOT NULL,
    id_articulo INT,             
    id_proveedor INT,                     
    FOREIGN KEY (id_articulo) REFERENCES Articulos(id),
    FOREIGN KEY (id_proveedor) REFERENCES Proveedores(id),
    CONSTRAINT UK_Repuestos_Codigo UNIQUE (codigo)
);
PRINT N'Tabla de Repuestos creada'


PRINT N'Creando tabla de tecnicos'
drop table if exists Tecnicos;
CREATE TABLE Tecnicos (
    id INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    especialidad VARCHAR(100)
);
PRINT N'Tabla de tecnicos creada'


PRINT N'Creando tabla de vendedores'
drop table if exists Vendedores;
CREATE TABLE Vendedores (
    id INT IDENTITY(1,1) PRIMARY KEY,
    tipo_documento VARCHAR(50) NOT NULL,
    numero_documento VARCHAR(50) NOT NULL UNIQUE,
    apellido VARCHAR(100),
    nombre VARCHAR(100),
);
PRINT N'Tabla de vendedores creada'


PRINT N'Creando tabla de turnos'
drop table if exists TurnosPreventa;
CREATE TABLE TurnosPreventa (
    id INT IDENTITY(1,1) PRIMARY KEY,
    fecha DATE NOT NULL,
    hora VARCHAR(50),       
    numero_turno VARCHAR(50),         
    id_cliente INT NOT NULL,   
    id_articulo INT NOT NULL,
    id_tecnico INT NOT NULL,                 
    FOREIGN KEY (id_cliente) REFERENCES Clientes(id),
    FOREIGN KEY (id_articulo) REFERENCES Articulos(id),
    FOREIGN KEY (id_tecnico) REFERENCES Tecnicos(id)
);
PRINT N'Tabla de turnos creada'


PRINT N'Creando tabla de ordenes_compra creada'
DROP TABLE IF EXISTS OrdenesCompra;
CREATE TABLE OrdenesCompra (
    id INT IDENTITY(1,1) PRIMARY KEY,
    numero VARCHAR(50) NOT NULL UNIQUE,    
    fecha DATE NOT NULL,
    id_proveedor INT NOT NULL,               
    razon_social VARCHAR(100) NOT NULL,
    domicilio VARCHAR(100),
    localidad VARCHAR(100),
    provincia VARCHAR(100),
    precio_mario DECIMAL(10, 2),           
    descripcion VARCHAR(255),
    cantidad INT NOT NULL,
    precio_total DECIMAL(10, 2) NOT NULL,
    precio_real DECIMAL(10, 2) NOT NULL,   
    iva VARCHAR(50),                       
    estado VARCHAR(50),
    FOREIGN KEY (id_proveedor) REFERENCES Proveedores(id)
);
PRINT N'Tabla de ordenes_compra creada'

PRINT N'Creando Tabla de forma_cobro creada'
DROP TABLE IF EXISTS FormasCobro;
CREATE TABLE FormasCobro (
    id INT IDENTITY(1,1) PRIMARY KEY,
    tipo VARCHAR(100) NOT NULL,
    detalle VARCHAR(255)
);
PRINT N'Tabla de forma_cobro creada'


PRINT N'Creando Tabla de factura creada'
DROP TABLE IF EXISTS Factura;
CREATE TABLE Factura (
    id INT IDENTITY(1,1) PRIMARY KEY,
    numero_pedido VARCHAR(50) NOT NULL UNIQUE,
    fecha DATE NOT NULL,
    apellido VARCHAR(100) NOT NULL,        
    descripcion VARCHAR(255),
    cantidad INT NOT NULL,
    precio_unitario DECIMAL(10, 2) NOT NULL,
    subtotal DECIMAL(10, 2) NOT NULL,
    descuento DECIMAL(10, 2) DEFAULT 0.00,
    monto_total DECIMAL(10, 2) NOT NULL,
    iva VARCHAR(50),                       
    estado VARCHAR(50),         
    id_forma_cobro INT NOT NULL,
    id_cliente INT NOT NULL,            
    FOREIGN KEY (id_forma_cobro) REFERENCES FormasCobro(id),
    FOREIGN KEY (id_cliente) REFERENCES Clientes(id)
);
PRINT N'Tabla de factura creada'


PRINT N'Creando Tabla de OrdenCompraDetalle creada'
DROP TABLE IF EXISTS OrdenCompraDetalle;
CREATE TABLE OrdenCompraDetalle(
    id INT IDENTITY(1,1) PRIMARY KEY,     
    id_orden_compra INT NOT NULL,
    id_articulo INT NOT NULL,
    cantidad INT NOT NULL,
    precio DECIMAL(10, 2) NOT NULL,        
    FOREIGN KEY (id_orden_compra) REFERENCES OrdenesCompra(id),
    FOREIGN KEY (id_articulo) REFERENCES Articulos(id)
);
PRINT N'Tabla de OrdenCompraDetalle creada'


PRINT N'Creando tabla de carrito'
DROP TABLE IF EXISTS Carrito;
CREATE TABLE Carrito (
    id INT IDENTITY(1,1) PRIMARY KEY,
    id_cliente INT NOT NULL,
    fecha_creacion DATE NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (id_cliente) REFERENCES Clientes(id)
);
PRINT N'Tabla de carrito creada'


PRINT N'Creando tabla de carrito detalle'
DROP TABLE IF EXISTS CarritoDetalle;
CREATE TABLE CarritoDetalle (
    id INT IDENTITY(1,1) PRIMARY KEY,
    id_carrito INT NOT NULL,
    id_articulo INT NOT NULL,
    cantidad INT NOT NULL,
    precio DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (id_carrito) REFERENCES Carrito(id),
    FOREIGN KEY (id_articulo) REFERENCES Articulos(id)
);
PRINT N'Tabla de carrito detalle creada'


PRINT N'Creando tabla de historial de pedidos'
DROP TABLE IF EXISTS HistorialPedidos;
CREATE TABLE HistorialPedidos (
    id INT IDENTITY(1,1) PRIMARY KEY,
    id_cliente INT NOT NULL,
    fecha_pedido DATE NOT NULL,
    estado VARCHAR(50) NOT NULL DEFAULT 'Pendiente', -- 'Pendiente', 'Enviada', 'Entregada', etc.
    id_factura INT,
    FOREIGN KEY (id_cliente) REFERENCES Clientes(id),
    FOREIGN KEY (id_factura) REFERENCES Factura(id)
);
PRINT N'Tabla de historial de pedidos creada'
