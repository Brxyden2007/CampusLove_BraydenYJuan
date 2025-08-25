DROP DATABASE IF EXISTS db_campuslove;
CREATE DATABASE IF NOT EXISTS db_campuslove;
USE db_campuslove;

CREATE TABLE IF NOT EXISTS usuarios(
    id INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
    nombre VARCHAR(50),
    apellido VARCHAR(50),
    email VARCHAR(100) UNIQUE NOT NULL,
    passworduser VARCHAR(255) NOT NULL,
    edad INT NOT NULL,
    genero VARCHAR(2),
    carrera VARCHAR(120),
    intereses VARCHAR(100),
    frase VARCHAR(150)
)ENGINE=INNODB;

CREATE TABLE IF NOT EXISTS matches (
    id INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
    usuario1_id INT NOT NULL,
    usuario2_id INT NOT NULL,
    fecha_match DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (usuario1_id) REFERENCES usuarios(id) ON DELETE CASCADE,
    FOREIGN KEY (usuario2_id) REFERENCES usuarios(id) ON DELETE CASCADE,
    UNIQUE(usuario1_id, usuario2_id)
) ENGINE=INNODB;

CREATE TABLE IF NOT EXISTS likes (
    id INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
    usuario_id INT NOT NULL,
    usuario_liked_id INT NOT NULL,
    fecha DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (usuario_id) REFERENCES usuarios(id) ON DELETE CASCADE,
    FOREIGN KEY (usuario_liked_id) REFERENCES usuarios(id) ON DELETE CASCADE,
    UNIQUE(usuario_id, usuario_liked_id)
) ENGINE=INNODB;

CREATE TABLE IF NOT EXISTS dislikes (
    id INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
    usuario_id INT NOT NULL,
    usuario_disliked_id INT NOT NULL,
    fecha DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (usuario_id) REFERENCES usuarios(id) ON DELETE CASCADE,
    FOREIGN KEY (usuario_disliked_id) REFERENCES usuarios(id) ON DELETE CASCADE,
    UNIQUE(usuario_id, usuario_disliked_id)
) ENGINE=INNODB;

CREATE TABLE IF NOT EXISTS intereses (
    id INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
    nombre VARCHAR(50) UNIQUE NOT NULL
) ENGINE=INNODB;

CREATE TABLE IF NOT EXISTS usuario_intereses (
    usuario_id INT NOT NULL,
    interes_id INT NOT NULL,
    PRIMARY KEY (usuario_id, interes_id),
    FOREIGN KEY (usuario_id) REFERENCES usuarios(id) ON DELETE CASCADE,
    FOREIGN KEY (interes_id) REFERENCES intereses(id) ON DELETE CASCADE
) ENGINE=INNODB;

CREATE TABLE IF NOT EXISTS creditos (
    usuario_id INT PRIMARY KEY,
    creditos_disponibles INT NOT NULL DEFAULT 50,
    ultima_actualizacion DATE NOT NULL,
    FOREIGN KEY (usuario_id) REFERENCES usuarios(id) ON DELETE CASCADE
) ENGINE=INNODB;

