 -- obtener todos los usuarios
Select * from usuarios;

-- mostrar correos creados en el ultimo mes
 SELECT nombres, email FROM usuarios WHERE created_at >= CURDATE() - INTERVAL 1 MONTH;
  -- lista de publicaciones
  SELECT * FROM publicaciones;
  -- todos los comentarios de una publicacion
  Select * from comentarios where id_publicacion = 3;
  -- crear una nueva publicacion para un usuario especifico:
  INSERT INTO publicaciones (id_usuario, titulo, texto) VALUES (10, 'comida de hoy', 'papitas');
  
  
  