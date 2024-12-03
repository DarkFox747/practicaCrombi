-- Verificar si la base de datos existe, y crearla si no
IF DB_ID('biblioteca') IS NULL
BEGIN
    CREATE DATABASE biblioteca;
    PRINT 'Base de datos biblioteca creada';
END
ELSE
BEGIN
    PRINT 'La base de datos biblioteca ya existe';
END;

-- Seleccionar la base de datos
USE biblioteca;

-- Crear la tabla Usuarios
IF OBJECT_ID('Usuarios', 'U') IS NULL
BEGIN
    CREATE TABLE Usuarios (
        IDUsuarios INT IDENTITY(1,1) PRIMARY KEY, -- ID autoincremental
        Nombre VARCHAR(80) NOT NULL,             -- Nombre del usuario
        Tipo VARCHAR(50)                         -- Tipo de usuario (ej. Administrador, Usuario)
    );
    PRINT 'Tabla Usuarios creada';
END
ELSE
BEGIN
    PRINT 'La tabla Usuarios ya existe';
END;

-- Crear la tabla Libros
IF OBJECT_ID('Libros', 'U') IS NULL
BEGIN
    CREATE TABLE Libros (
        IDLibros INT IDENTITY(1,1) PRIMARY KEY, -- ID autoincremental
        Titulo VARCHAR(100) NOT NULL,           -- Título del libro
        Autor VARCHAR(80),                      -- Autor del libro
        Cantidad INT NOT NULL CHECK (Cantidad >= 0), -- Cantidad de libros disponibles (mínimo 0)
        Disponibilidad AS CASE                  -- Disponibilidad calculada automáticamente
            WHEN Cantidad > 0 THEN 1
            ELSE 0
        END
    );
    PRINT 'Tabla Libros creada';
END
ELSE
BEGIN
    PRINT 'La tabla Libros ya existe';
END;

-- Crear la tabla LibrosPrestados
IF OBJECT_ID('LibrosPrestados', 'U') IS NULL
BEGIN
    CREATE TABLE LibrosPrestados (
        IDPrestamo INT IDENTITY(1,1) PRIMARY KEY, -- ID del préstamo
        IDUsuarios INT NOT NULL,                  -- ID del usuario (FK)
        IDLibros INT NOT NULL,                    -- ID del libro (FK)
        FechaPrestamo DATE NOT NULL DEFAULT GETDATE(), -- Fecha de préstamo
        FechaDevolucion DATE NULL,                -- Fecha de devolución (opcional)
        FOREIGN KEY (IDUsuarios) REFERENCES Usuarios(IDUsuarios), -- Relación con Usuarios
        FOREIGN KEY (IDLibros) REFERENCES Libros(IDLibros)        -- Relación con Libros
    );
    PRINT 'Tabla LibrosPrestados creada';
END
ELSE
BEGIN
    PRINT 'La tabla LibrosPrestados ya existe';
END;
