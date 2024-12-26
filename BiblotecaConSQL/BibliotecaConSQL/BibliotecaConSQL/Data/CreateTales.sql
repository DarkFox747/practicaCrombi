CREATE TABLE Usuarios (
    IDUsuarios INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    TipoUsuario VARCHAR(50) NOT NULL,
    FechaInactivacion DATE NULL
);


CREATE TABLE Libros (
    IDLibros INT IDENTITY(1,1) PRIMARY KEY,
    Titulo VARCHAR(200) NOT NULL,
    Autor VARCHAR(100) NOT NULL,
    Disponibilidad VARCHAR(20) CHECK (Disponibilidad IN ('Disponible', 'No Disponible')) NOT NULL,
    Cantidad INT CHECK (Cantidad >= 0) NOT NULL,
    FechaInactivacion DATE NULL
);


CREATE TABLE HistorialBiblioteca (
    IdHistorial INT IDENTITY(1,1) PRIMARY KEY,
    IDUsuarios INT NOT NULL,
    IDLibros INT NOT NULL,
    Accion VARCHAR(20) CHECK (Accion IN ('Prestar', 'Devolver')) NOT NULL,
    FechaAccion DATETIME DEFAULT GETDATE() NOT NULL,
    FOREIGN KEY (IDUsuarios) REFERENCES Usuarios(IDUsuarios),
    FOREIGN KEY (IDLibros) REFERENCES Libros(IDLibros)
);


