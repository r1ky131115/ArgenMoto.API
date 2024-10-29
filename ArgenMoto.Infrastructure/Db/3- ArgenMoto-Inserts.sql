PRINT N'Creando insert generales'
-- INSERTS

PRINT N'Insertando Clientes'
INSERT INTO Usuarios (username, password_hash, rol, email, fecha_creacion, estado) VALUES
('admin', '12345678', 'admin', 'juan.perez@example.com', '2023-01-15', 'Activo'),
('test1', '87654321', 'cliente', 'ana.gomez@example.com', '2023-02-20', 'Activo'),
('test2', '13579246', 'cliente', 'carlos.lopez@example.com', '2023-03-10', 'Activo');

PRINT N'Insertando Clientes'
INSERT INTO Clientes (id_usuario ,tipo_documento, numero_documento, apellido, nombre, fecha_registro, localidad, telefono, email) VALUES
(1, 'DNI', '12345678', 'Pérez', 'Juan', '2023-01-15', 'Buenos Aires', '011-1234-5678', 'juan.perez@example.com'),
(2, 'DNI', '87654321', 'Gómez', 'Ana', '2023-02-20', 'La Plata', '011-2345-6789', 'ana.gomez@example.com'),
(3, 'DNI', '13579246', 'López', 'Carlos', '2023-03-10', 'Mendoza', '0261-345-6789', 'carlos.lopez@example.com');


PRINT N'Insertando Tecnicos'
INSERT INTO Tecnicos (nombre, especialidad) VALUES
('Diego López', 'Mecánica Automotriz'),
('Sofía Martínez', 'Electricidad Automotriz'),
('Lucas Pérez', 'Diagnóstico de Vehículos'),
('María González', 'Mantenimiento Preventivo'),
('Andrés Sánchez', 'Reparación de Transmisiones'),
('Claudia Fernández', 'Sistema de Suspensión'),
('Javier Ramírez', 'Sistemas de Frenos'),
('juan Torres', 'Reparación de Motores'),
('Fernando Castro', 'Instalación de Accesorios'),
('Franco Díaz', 'Reparación de Carrocerías');


PRINT N'Insertando Articulos'
INSERT INTO Articulos (codigo, descripcion, stock_minimo, stock_maximo, stock_actual, precio, marca, modelo, motor, nro_chasis, año, cilindrada) VALUES
('MOTO001', 'Moto deportiva 1000cc', 5, 20, 10, 15000.00, 'Yamaha', 'YZF-R1', 123456, 654321, 2022, '4 cilindros'),
('MOTO002', 'Moto cruiser 800cc', 3, 15, 8, 12000.00, 'Harley-Davidson', 'Iron 883', 223344, 443322, 2021, '2 cilindros'),
('MOTO003', 'Moto touring 1200cc', 4, 10, 6, 18000.00, 'BMW', 'R1250GS', 334455, 554433, 2023, '2 cilindros'),
('MOTO004', 'Scooter 150cc', 10, 50, 30, 3000.00, 'Honda', 'PCX150', 445566, 665544, 2022, '1 cilindro'),
('MOTO005', 'Moto off-road 250cc', 8, 40, 20, 7000.00, 'KTM', '250 EXC', 556677, 776655, 2023, '1 cilindro'),
('MOTO006', 'Moto naked 600cc', 6, 25, 12, 9000.00, 'Kawasaki', 'Z900', 667788, 887766, 2020, '4 cilindros'),
('MOTO007', 'Dirt bike 125cc', 15, 70, 50, 2500.00, 'Suzuki', 'DR-Z125', 778899, 998877, 2022, '1 cilindro');


PRINT N'Insertando Proveedores'
INSERT INTO Proveedores (cuit, razon_social, apellido, nombre, domicilio, localidad, provincia, telefono, email, categoria) VALUES
('20-12345678-9', 'Proveeduria Ejemplo S.A.', 'González', 'María', 'Av. Libertador 1234', 'Buenos Aires', 'Buenos Aires', '011-1234-5678', 'maria@ejemplo.com', 'Alimentos'),
('27-23456789-0', 'Distribuciones Ficticias SRL', 'Pérez', 'Carlos', 'Calle Falsa 456', 'CABA', 'Buenos Aires', '011-9876-5432', 'carlos@ficticias.com', 'Ropa'),
('30-34567890-1', 'Servicios de Suministros S.A.', 'López', 'Ana', 'Ruta 5 Km 20', 'Mendoza', 'Mendoza', '0261-345-6789', 'ana@suminitros.com', 'Servicios'),
('34-45678901-2', 'Comercializadora XYZ', 'Martínez', 'Jorge', 'Plaza Central 100', 'Córdoba', 'Córdoba', '0351-123-4567', 'jorge@xyz.com', 'Electrodomésticos'),
('20-56789012-3', 'Alimentos y Bebidas S.A.', 'Rodríguez', 'Sofía', 'Av. Santa Fe 789', 'Rosario', 'Santa Fe', '0341-987-6543', 'sofia@alimentos.com', 'Alimentos'),
('23-67890123-4', 'Tecnologías Avanzadas SRL', 'Fernández', 'Luis', 'Calle Innovación 32', 'La Plata', 'Buenos Aires', '021-456-7890', 'luis@tecnologias.com', 'Tecnología'),
('27-78901234-5', 'Construcciones del Futuro', 'Gutiérrez', 'Clara', 'Av. de la Construcción 500', 'Tucumán', 'Tucumán', '0381-234-5678', 'clara@construcciones.com', 'Construcción'),
('30-89012345-6', 'Textiles y Más', 'Díaz', 'Esteban', 'Calle Textil 15', 'Salta', 'Salta', '0387-987-6543', 'esteban@textiles.com', 'Textiles'),
('34-90123456-7', 'Papelería y Suministros', 'Morales', 'Valentina', 'Av. del Papel 88', 'Neuquén', 'Neuquén', '0299-123-4567', 'valentina@papeleria.com', 'Papelería'),
('40-01234567-8', 'Servicios de Limpieza', 'Castro', 'Diego', 'Calle Limpieza 20', 'San Juan', 'San Juan', '0264-987-6543', 'diego@limpieza.com', 'Servicios');


PRINT N'Insertando Vendedores'
INSERT INTO Vendedores (tipo_documento, numero_documento, apellido, nombre) VALUES
('DNI', '12345678', 'García', 'Lucía'),
('DNI', '87654321', 'Fernández', 'Javier'),
('DNI', '23456789', 'Martínez', 'Sofía'),
('DNI', '34567890', 'Pérez', 'Miguel'),
('DNI', '45678901', 'López', 'Ana'),
('DNI', '56789012', 'Gutiérrez', 'Carlos'),
('DNI', '67890123', 'Rodríguez', 'Valentina'),
('DNI', '78901234', 'Morales', 'Diego'),
('DNI', '89012345', 'Díaz', 'Esteban'),
('DNI', '90123456', 'Castro', 'Clara');


PRINT N'Insertando FormasCobro'
INSERT INTO FormasCobro (tipo, detalle) VALUES
('Efectivo', 'Pago en efectivo al momento de la compra'),
('Tarjeta de Crédito', 'Pago a través de tarjeta de crédito con cuotas'),
('Transferencia Bancaria', 'Transferencia directa desde la cuenta bancaria del cliente');


PRINT N'Insertando Repuestos'
INSERT INTO Repuestos (codigo, descripcion, stock_minimo, stock_maximo, stock_actual, precio, marca, modelo) VALUES
('REP-001', 'Freno de disco delantero', 5, 20, 15, 12000.00, 'Brembo', 'DB-101'),
('REP-002', 'Bujía de encendido', 10, 50, 30, 2000.50, 'NGK', 'CR8E'),
('REP-003', 'Filtro de aceite', 8, 40, 25, 3500.75, 'Mahle', 'OC-202'),
('REP-004', 'Cadena de transmisión', 5, 25, 12, 8000.00, 'DID', '520VX2'),
('REP-005', 'Amortiguador trasero', 3, 15, 8, 25000.00, 'Öhlins', 'STX36'),
('REP-006', 'Pastillas de freno trasero', 4, 20, 10, 6000.00, 'EBC', 'FA201'),
('REP-007', 'Espejo retrovisor', 6, 30, 18, 4500.00, 'Hella', 'HM-100'),
('REP-008', 'Kit de transmisión', 5, 18, 9, 15000.00, 'RK', '520R'),
('REP-009', 'Filtro de aire', 7, 35, 20, 3000.00, 'K&N', 'KA-1001'),
('REP-010', 'Tubo de escape', 2, 10, 4, 35000.00, 'Akrapovic', 'R-1');


PRINT N'Insertando Repuestos segun proveeodr y articulo'
INSERT INTO Repuestos (codigo, descripcion, stock_minimo, stock_maximo, stock_actual, precio, marca, modelo, id_articulo, id_proveedor) VALUES
('REP-011', 'Radiador de aceite', 3, 12, 6, 12000.00, 'FJR', 'OR-200', 1, 1),
('REP-012', 'Batería sellada', 5, 20, 15, 18000.00, 'Yuasa', 'YTX12-BS', 2, 2),
('REP-013', 'Cubre cadenas', 4, 16, 9, 9000.00, 'Zeta', 'ZC-2', 3, 3);


PRINT N'Insertando Articulos segun proveedor'
INSERT INTO Articulos (codigo, descripcion, stock_minimo, stock_maximo, stock_actual, precio, marca, modelo, motor, nro_chasis, año, cilindrada, id_proveedor) VALUES
('MOTO008', 'Moto eléctrica', 2, 8, 4, 4500.00, 'Zero', 'SRS', 889900, 109988, 2023, '0 cilindros', 1),
('MOTO009', 'Café racer 500cc', 7, 35, 18, 8000.00, 'Triumph', 'Street Cup', 990011, 210099, 2021, '2 cilindros', 2),
('MOTO010', 'Chopper personalizada', 1, 5, 2, 25000.00, 'Custom', 'Chopper 1', 100220, 220011, 2020, '2 cilindros', 3);
   

PRINT N'Insertando TurnosPreventa'
INSERT INTO TurnosPreventa (fecha, hora, id_cliente, id_articulo, id_tecnico) VALUES
('2024-10-15', '10:00:00', 4, 1, 1),
('2024-10-24', '11:00:00', 5, 2, 3);