-- =====================================
-- BORRAR Y CREAR BASE DE DATOS
-- =====================================
DROP DATABASE IF EXISTS db_campuslove;
CREATE DATABASE IF NOT EXISTS db_campuslove;
USE db_campuslove;

-- =====================================
-- TABLA USUARIOS
-- =====================================
CREATE TABLE usuarios (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Nombre VARCHAR(50) NOT NULL,
    Apellido VARCHAR(50) NOT NULL,
    Email VARCHAR(100) UNIQUE NOT NULL,
    PasswordUser VARCHAR(255) NOT NULL,
    Edad INT NOT NULL,
    Genero VARCHAR(10),
    Carrera VARCHAR(120),
    Frase VARCHAR(150)
) ENGINE=InnoDB;

-- =====================================
-- TABLA INTERESES
-- =====================================
CREATE TABLE intereses (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Nombre VARCHAR(100) UNIQUE NOT NULL
) ENGINE=InnoDB;

-- =====================================
-- TABLA RELACIONAL USUARIO-INTERES
-- =====================================
CREATE TABLE IF NOT EXISTS interesusuario (
    UsuarioId INT NOT NULL,
    InteresId INT NOT NULL,
    PRIMARY KEY (UsuarioId, InteresId),
    CONSTRAINT fk_usuario FOREIGN KEY (UsuarioId) REFERENCES usuarios(Id) ON DELETE CASCADE,
    CONSTRAINT fk_interes FOREIGN KEY (InteresId) REFERENCES intereses(Id) ON DELETE CASCADE
) ENGINE=InnoDB;

-- =====================================
-- TABLA LIKES
-- =====================================
CREATE TABLE likes (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    UsuarioDadorId INT NOT NULL,       -- quien da el like
    UsuarioId INT NOT NULL, -- Puse esto simplemente para quitarme los errores de encima (Mala practica..)
    UsuarioReceptorId INT NOT NULL,    -- a quien le da like
    FechaLike TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (UsuarioDadorId) REFERENCES usuarios(Id) ON DELETE CASCADE,
    FOREIGN KEY (UsuarioReceptorId) REFERENCES usuarios(Id) ON DELETE CASCADE
) ENGINE=InnoDB;

-- =====================================
-- TABLA MATCHES
-- =====================================
CREATE TABLE matches (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    UsuarioId INT,
    Usuario1Id INT NOT NULL,
    Usuario2Id INT NOT NULL,
    FechaMatch TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (UsuarioId) REFERENCES usuarios(Id) ON DELETE CASCADE,
    FOREIGN KEY (Usuario1Id) REFERENCES usuarios(Id) ON DELETE CASCADE
) ENGINE=InnoDB;