DROP DATABASE IF EXISTS db_campuslove; -- Esto ELIMINARÁ la base de datos si existe
CREATE DATABASE IF NOT EXISTS db_campuslove;
USE db_campuslove;

-- =======================
-- TABLA USUARIOS
-- =======================
CREATE TABLE usuarios (
    id INT PRIMARY KEY AUTO_INCREMENT,
    nombre VARCHAR(50) NOT NULL,
    apellido VARCHAR(50) NOT NULL,
    email VARCHAR(100) UNIQUE NOT NULL,
    passworduser VARCHAR(255) NOT NULL,
    edad INT NOT NULL,
    genero VARCHAR(10),
    carrera VARCHAR(120),
    frase VARCHAR(150)
) ENGINE=InnoDB;

-- =======================
-- TABLA INTERESES (catálogo)
-- =======================
CREATE TABLE intereses (
    id INT PRIMARY KEY AUTO_INCREMENT,
    nombre VARCHAR(100) UNIQUE NOT NULL
) ENGINE=InnoDB;

-- =======================
-- TABLA RELACIONAL: interesusuario
-- =======================
-- ¡Asegúrate de que esta tabla se crea con usuario_id y interes_id!
CREATE TABLE IF NOT EXISTS interesusuario (
    usuario_id INT NOT NULL,
    interes_id INT NOT NULL,
    PRIMARY KEY (usuario_id, interes_id),
    CONSTRAINT fk_usuario FOREIGN KEY (usuario_id) REFERENCES usuarios(id) ON DELETE CASCADE,
    CONSTRAINT fk_interes FOREIGN KEY (interes_id) REFERENCES intereses(id) ON DELETE CASCADE
);

-- =======================
-- TABLA LIKES
-- =======================
CREATE TABLE likes (
    id INT PRIMARY KEY AUTO_INCREMENT,
    usuario_id INT NOT NULL,         -- quien da el like
    usuario_liked_id INT NOT NULL,   -- a quien le da like
    fecha TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (usuario_id) REFERENCES usuarios(id) ON DELETE CASCADE,
    FOREIGN KEY (usuario_liked_id) REFERENCES usuarios(id) ON DELETE CASCADE
) ENGINE=InnoDB;

-- =======================
-- TABLA MATCHES
-- =======================
CREATE TABLE matches (
    id INT PRIMARY KEY AUTO_INCREMENT,
    usuario1_id INT NOT NULL,
    usuario2_id INT NOT NULL,
    fecha TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (usuario1_id) REFERENCES usuarios(id) ON DELETE CASCADE,
    FOREIGN KEY (usuario2_id) REFERENCES usuarios(id) ON DELETE CASCADE
) ENGINE=InnoDB;