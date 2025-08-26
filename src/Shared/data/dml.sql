INSERT INTO usuarios (nombre, apellido, email, passworduser, edad, genero, carrera, frase) VALUES
("María", "Zambrano", "mariazambrano@gmail.com", "maria1234", 22, "F", "Ingenieria de Sistemas", "Buscando bugs en codigos"),
("Juan", "Romero", "juanr@gmail.com", "juanromero1234", 24, "M", "Diseño Gráfico", "Un match y te diseño la vida que necesitas conmigo"),
("Laura", "Castellanos", "lauracas@gmail.com", "lauracas1234", 21, "F", "Psicologia", "Te escucho con el cafe de mis mañanas"),
("Carlos", "De la Cruz", "carloscruz@gmail.com", "carloscruz1234", 23, "M", "Medicina", "El mejor remedio: una dosis de ejercicio"),
("Andrea", "Alfonso", "andrealfo@gmail.com", "andrealfonso1234", 22, "F", "Derecho", "Argumenta tu amor"),
("Luis", "Fonsi", "luisfonsi@gmail.com", "luisfonsi1234", 25, "M", "Administración", "Invertir en amor, la nueva y mejor jugada");

INSERT INTO intereses (nombre) VALUES
("Videojuegos"),
("Musica"),
("Arte"),
("Cine"),
("Lectura"),
("Café"),
("Deporte"),
("Series"),
("Debates"),
("Viajes"),
("Finanzas"),
("Ajedrez");


-- María (id 1)
INSERT INTO interesusuario VALUES (1, 1), (1, 2);

-- Juan (id 2)
INSERT INTO interesusuario VALUES (2, 3), (2, 4);

-- Laura (id 3)
INSERT INTO interesusuario VALUES (3, 5), (3, 6);

-- Carlos (id 4)
INSERT INTO interesusuario VALUES (4, 7), (4, 8);

-- Andrea (id 5)
INSERT INTO interesusuario VALUES (5, 9), (5, 10);

-- Luis (id 6)
INSERT INTO interesusuario VALUES (6, 11), (6, 12);


INSERT INTO matches (Usuario1Id, Usuario2Id) VALUES -- Esta dañado al parecer, en si me enrede con la base de datos...
(1, 2); -- María y Juan son match
