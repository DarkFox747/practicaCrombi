-- Crear la tabla usuarios con el nuevo campo email y created_at
CREATE TABLE usuarios (
  id INT AUTO_INCREMENT PRIMARY KEY,
  nombre VARCHAR(100) NOT NULL,
  apellido VARCHAR(100) NOT NULL,
  email VARCHAR(100) NOT NULL,
  created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Crear la tabla publicaciones con el nuevo campo titulo
CREATE TABLE publicaciones (
  id INT AUTO_INCREMENT PRIMARY KEY,
  id_usuario INT NOT NULL,
  titulo VARCHAR(100) NOT NULL,
  texto TEXT NOT NULL,
  created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
  updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  FOREIGN KEY (id_usuario) REFERENCES usuarios(id)
);

-- Crear la tabla megustas
CREATE TABLE megustas (
  id INT AUTO_INCREMENT PRIMARY KEY,
  id_usuario INT NOT NULL,
  id_publicacion INT NOT NULL,
  created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
  FOREIGN KEY (id_usuario) REFERENCES usuarios(id),
  FOREIGN KEY (id_publicacion) REFERENCES publicaciones(id),
  INDEX (id_usuario, id_publicacion)
);

-- Crear la tabla comentarios
CREATE TABLE comentarios (
  id INT AUTO_INCREMENT PRIMARY KEY,
  id_publicacion INT NOT NULL,
  id_usuario INT NOT NULL,
  texto TEXT NOT NULL,
  created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
  FOREIGN KEY (id_publicacion) REFERENCES publicaciones(id),
  FOREIGN KEY (id_usuario) REFERENCES usuarios(id),
  INDEX (id_publicacion, id_usuario)
);

