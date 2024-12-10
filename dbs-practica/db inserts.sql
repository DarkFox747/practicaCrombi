INSERT INTO usuarios (nombre, apellido, email) VALUES
('Juan', 'Pérez', 'juan.perez@example.com'),
('Ana', 'González', 'ana.gonzalez@example.com'),
('Luis', 'Rodríguez', 'luis.rodriguez@example.com'),
('María', 'Martínez', 'maria.martinez@example.com'),
('Pedro', 'López', 'pedro.lopez@example.com'),
('Laura', 'Sánchez', 'laura.sanchez@example.com'),
('Carlos', 'Ramírez', 'carlos.ramirez@example.com'),
('Marta', 'Torres', 'marta.torres@example.com'),
('David', 'Hernández', 'david.hernandez@example.com'),
('Patricia', 'Fernández', 'patricia.fernandez@example.com'),
('José', 'Gómez', 'jose.gomez@example.com'),
('Carmen', 'Vázquez', 'carmen.vazquez@example.com'),
('Antonio', 'Díaz', 'antonio.diaz@example.com'),
('Isabel', 'Mendoza', 'isabel.mendoza@example.com'),
('José Luis', 'Moreno', 'joseluis.moreno@example.com'),
('Lucía', 'Serrano', 'lucia.serrano@example.com'),
('Manuel', 'García', 'manuel.garcia@example.com'),
('Sara', 'Jiménez', 'sara.jimenez@example.com'),
('Javier', 'Pérez', 'javier.perez@example.com'),
('Eva', 'Ruiz', 'eva.ruiz@example.com'),
('Raúl', 'Castro', 'raul.castro@example.com'),
('Julia', 'Navarro', 'julia.navarro@example.com'),
('Fernando', 'Álvarez', 'fernando.alvarez@example.com'),
('María José', 'Gil', 'mariajose.gil@example.com'),
('Rafael', 'Salazar', 'rafael.salazar@example.com'),
('Elena', 'Ortega', 'elena.ortega@example.com'),
('Tomás', 'Vega', 'tomas.vega@example.com'),
('Beatriz', 'Castillo', 'beatriz.castillo@example.com'),
('Ricardo', 'Cordero', 'ricardo.cordero@example.com'),
('Silvia', 'Muñoz', 'silvia.munoz@example.com');


-- ejemplos publicaciones: 
INSERT INTO publicaciones (id_usuario, titulo, texto) VALUES
(1, 'Mi primer post', '¡Hoy es un gran día!'),
(2, 'SQL para principiantes', 'Me encanta aprender SQL'),
(3, 'Recomendaciones de lectura', '¿Alguien tiene recomendaciones de libros?'),
(4, 'Preparándome para la maratón', 'Me estoy preparando para una maratón. ¡Vamos!'),
(5, 'Película recomendada', 'Acabo de ver una película increíble'),
(6, 'Productividad personal', '¿Cómo mejorar mi productividad?'),
(7, 'Recetas saludables', 'Estoy buscando nuevas recetas de cocina'),
(8, 'Aprendiendo desarrollo web', 'Hoy comencé a aprender programación web'),
(9, 'Paseo en el parque', 'El clima está espectacular para un paseo'),
(10, 'Motivación diaria', 'Hoy me siento motivado para hacer ejercicio');

-- ejemplos megustas 

INSERT INTO megustas (id_usuario, id_publicacion) VALUES
(1, 1), (2, 1), (3, 2), (4, 3), (5, 4),
(6, 5), (7, 1), (8, 6), (9, 7), (10, 8),
(11, 1), (12, 2), (13, 3), (14, 4), (15, 5),
(16, 7), (17, 8), (18, 9), (19, 10), (20, 6),
(21, 9), (22, 5), (23, 2), (24, 10), (25, 4),
(26, 7), (27, 1), (28, 8), (29, 3), (30, 6);


INSERT INTO comentarios (id_publicacion, id_usuario, texto) VALUES
(1, 2, '¡Qué bueno, Juan! Yo también creo que es un gran día para empezar algo nuevo.'),
(2, 3, 'Ana, me encanta aprender SQL. ¿Tienes algún consejo para mejorar?'),
(3, 4, 'Luis, he leído muchos libros últimamente. Te recomiendo "El código Da Vinci" y "1984".'),
(4, 5, '¡Qué bien, Pedro! Yo también me estoy preparando para correr una maratón.'),
(5, 6, '¡La película que mencionas suena genial! ¿De qué trata?'),
(6, 7, 'Laura, la productividad es clave. ¿Tienes algún método que sigas?'),
(7, 8, 'Carlos, me encantan las recetas saludables. ¿Qué me recomiendas para el desayuno?'),
(8, 9, 'Marta, la programación web es fascinante. ¿Por dónde debería empezar si soy principiante?'),
(9, 10, 'David, el clima está perfecto para una caminata. ¿En qué parque estuviste?'),
(10, 11, 'Patricia, también me siento motivada hoy. ¡Vamos a hacer ejercicio juntos!');
