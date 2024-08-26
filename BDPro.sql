/*Creacion de la BD*/
CREATE DATABASE TiendaGeek;
GO

/*Usar la BD*/
USE TiendaGeek;
GO

/*Creacion de tablas*/
--Tabla de usuarios--
CREATE TABLE Usuario (
    CodigoUsuario INT IDENTITY(1,1) PRIMARY KEY,
    Rol VARCHAR(50),
    Nombre VARCHAR(100),
    PrimerApellido VARCHAR(100),
    SegundoApellido VARCHAR(100),
    Contrasena VARCHAR(100),
    Estado BIT  
);

--Tabla de categoria de productos--
CREATE TABLE Categoria (
    CodigoCategoria INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100),
    Descripcion TEXT
);

--Tabla de productos--
CREATE TABLE Producto (
    CodigoProducto INT IDENTITY(1,1) PRIMARY KEY,
    CodigoCategoria INT,
    Nombre VARCHAR(100),
    Descripcion TEXT,
    Precio DECIMAL(10, 2),
    Unidades INT,
    Estado VARCHAR(50),
    FOREIGN KEY (CodigoCategoria) REFERENCES Categoria(CodigoCategoria)
);

--Tabla de imagenes de productos--
CREATE TABLE ImagenProducto (
    CodigoImagen INT IDENTITY(1,1) PRIMARY KEY,
    CodigoProducto INT,
    RutaImagen VARCHAR(255),
    FOREIGN KEY (CodigoProducto) REFERENCES Producto(CodigoProducto)
);
-- Crear la tabla Carrito
CREATE TABLE Carrito (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Monto FLOAT NOT NULL,
    UsuarioId NVARCHAR(450) NULL,
    CarritoTemporalId NVARCHAR(450) NULL,
    Estado NVARCHAR(50) NULL,

    -- Relación con IdentityUser
    CONSTRAINT FK_Carrito_IdentityUser FOREIGN KEY (UsuarioId)
    REFERENCES AspNetUsers(Id) -- Asumiendo que la tabla de usuarios es AspNetUsers
);

-- Crear la tabla ItemCarrito
CREATE TABLE ItemCarrito (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Cantidad INT NOT NULL,
    ProductoId INT NOT NULL,
    CarritoId INT NOT NULL,

    -- Relación con Producto
    CONSTRAINT FK_ItemCarrito_Producto FOREIGN KEY (ProductoId)
    REFERENCES Producto(CodigoProducto), -- Asumiendo que la tabla de productos es Producto

    -- Relación con Carrito
    CONSTRAINT FK_ItemCarrito_Carrito FOREIGN KEY (CarritoId)
    REFERENCES Carrito(Id)
);



/*INSERTS*/
-- Datos para la tabla Usuario --
INSERT INTO Usuario (Rol, Nombre, PrimerApellido, SegundoApellido, Contrasena, Estado)
VALUES 
('Cliente', 'Juan', 'Pérez', 'García', 'password123', 1), 
('Cliente', 'María', 'López', 'Fernández', 'password123', 1), 
('Cliente', 'Carlos', 'Hernández', 'Martínez', 'password123', 1), 
('Cliente', 'Ana', 'Martín', 'Sánchez', 'password123', 1), 
('Cliente', 'Luis', 'Gómez', 'Rodríguez', 'password123', 1);

-- Datos para la tabla Categoria --
INSERT INTO Categoria (Nombre, Descripcion)
VALUES 
('Figuras', 'Figuras de acción y coleccionables'),
('Mangas', 'Libros de manga'),
('Cómics', 'Cómics de varios géneros'),
('Videojuegos', 'Juegos de video para varias plataformas'),
('Ropa', 'Ropa y accesorios geek');

-- Datos para la tabla Producto --
INSERT INTO Producto (CodigoCategoria, Nombre, Descripcion, Precio, Unidades, Estado)
VALUES 
(1, 'Figura de Goku', 'Figura de acción de Goku de Dragon Ball Z', 29.99, 100, 'Disponible'),
(1, 'Figura de Batman', 'Figura coleccionable de Batman', 19.99, 50, 'Disponible'),
(2, 'Manga One Piece Vol. 1', 'Primer volumen del manga One Piece', 9.99, 200, 'Disponible'),
(2, 'Manga Naruto Vol. 1', 'Primer volumen del manga Naruto', 9.99, 150, 'Disponible'),
(3, 'Cómic Spider-Man #1', 'Primer número del cómic Spider-Man', 14.99, 75, 'Disponible'),
(3, 'Cómic X-Men #1', 'Primer número del cómic X-Men', 14.99, 80, 'Disponible'),
(4, 'Videojuego The Legend of Zelda', 'Videojuego para Nintendo Switch', 59.99, 30, 'Disponible'),
(4, 'Videojuego Final Fantasy VII', 'Videojuego para PlayStation 4', 49.99, 40, 'Disponible'),
(5, 'Camiseta Star Wars', 'Camiseta con diseño de Star Wars', 19.99, 120, 'Disponible'),
(5, 'Gorra Pokémon', 'Gorra con diseño de Pokémon', 15.99, 90, 'Disponible');

-- Datos para la tabla ImagenProducto --
INSERT INTO ImagenProducto (CodigoProducto, RutaImagen)
VALUES 
(1, 'ruta/imagen_goku.jpg'),
(2, 'ruta/imagen_batman.jpg'),
(3, 'ruta/imagen_onepiece.jpg'),
(4, 'ruta/imagen_naruto.jpg'),
(5, 'ruta/imagen_spiderman.jpg'),
(6, 'ruta/imagen_xmen.jpg'),
(7, 'ruta/imagen_zelda.jpg'),
(8, 'ruta/imagen_ffvii.jpg'),
(9, 'ruta/imagen_starwars.jpg'),
(10, 'ruta/imagen_pokemon.jpg');

-- Datos para la tabla Carrito --
INSERT INTO Carrito (CodigoUsuario, CodigoProducto, TotalCompra)
VALUES 
(1, 1, 13900),
(2, 3, 15300),
(3, 5, 14095),
(4, 7, 45009),
(5, 9, 20500);

-- Datos para la tabla Orden --
INSERT INTO Orden (CodigoUsuario, CodigoCarrito, FechaOrden)
VALUES 
(1, 1, '2024-06-01'),
(2, 2, '2024-06-02'),
(3, 3, '2024-06-03'),
(4, 4, '2024-06-04'),
(5, 5, '2024-06-05');

