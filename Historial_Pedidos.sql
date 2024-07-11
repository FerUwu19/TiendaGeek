USE TiendaGeek;

CREATE TABLE Historial_Pedidos (
    id INT IDENTITY(1,1) PRIMARY KEY,
	id_orden int,
    fecha_de_creacion DATETIME DEFAULT GETDATE()
);