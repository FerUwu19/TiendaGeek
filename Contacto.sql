/*Usar la BD*/
USE TiendaGeek;

--Tabla de contacto--
CREATE TABLE Contacto (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    IdUser INT NOT NULL,
    Name VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    Message TEXT NOT NULL
);
