INSERT INTO Libros (Titulo, Autor, Disponibilidad, Cantidad) VALUES
('Libro de Matemáticas', 'Autor A', 'Disponible', 11),
('Libro de Física', 'Autor B', 'Disponible', 12),
('Libro de Historia', 'Autor C', 'No Disponible', 13),
('Libro 104', 'Autor A', 'Disponible', 14),
('Libro 105', 'Autor B', 'Disponible', 15),
('Libro 106', 'Autor C', 'No Disponible', 16),
('Libro 107', 'Autor D', 'Disponible', 17),
('Libro 108', 'Autor E', 'Disponible', 18),
('Libro 109', 'Autor F', 'No Disponible', 19),
('Libro 110', 'Autor G', 'No Disponible', 20),
('Libro 111', 'Autor H', 'Disponible', 21),
('Libro 112', 'Autor I', 'No Disponible', 22),
('Libro 113', 'Autor J', 'Disponible', 23);


INSERT INTO HistorialBiblioteca (IDUsuarios, IDLibros, Accion) VALUES
(1, 1, 'Prestar'),  -- Juan presta Libro de Matemáticas
(1, 2, 'Prestar'),  -- Juan presta Libro de Física
(2, 3, 'Prestar'),  -- Dr. Ana presta Libro de Historia
(1, 1, 'Devolver'), -- Juan devuelve Libro de Matemáticas
(5, 1, 'Devolver'), -- Usuario_5 devuelve Libro de Matemáticas
(1, 3, 'Devolver'), -- Juan devuelve Libro de Historia
(10, 3, 'Devolver'),-- Usuario_10 devuelve Libro de Historia
(4, 3, 'Devolver'), -- Usuario_4 devuelve Libro de Historia
(9, 3, 'Prestar'),  -- Usuario_9 presta Libro de Historia
(6, 3, 'Devolver'), -- Usuario_6 devuelve Libro de Historia
(12, 1, 'Devolver'),-- Usuario_12 devuelve Libro de Matemáticas
(4, 3, 'Devolver'), -- Usuario_4 devuelve Libro de Historia
(1, 1, 'Devolver'); -- Juan devuelve Libro de Matemáticas


INSERT INTO Usuarios (Nombre, TipoUsuario) VALUES
('Juan', 'Estudiante'),
('Dr. Ana', 'Profesor'),
('Usuario_3', 'Profesor'),
('Usuario_4', 'Profesor'),
('Usuario_5', 'Estudiante'),
('Usuario_6', 'Estudiante'),
('Usuario_7', 'Estudiante'),
('Usuario_8', 'Profesor'),
('Usuario_9', 'Profesor'),
('Usuario_10', 'Estudiante'),
('Usuario_11', 'Profesor'),
('Usuario_12', 'Profesor');
