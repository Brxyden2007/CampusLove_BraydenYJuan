DROP DATABASE IF EXISTS db_campuslove;
CREATE DATABASE IF NOT EXISTS db_campuslove;
USE db_campuslove;

CREATE TABLE IF NOT EXISTS usuarios(
    id INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
    nombre VARCHAR(50),
    apellido VARCHAR(50),
    email VARCHAR(100) UNIQUE NOT NULL,
    password VARCHAR(255) NOT NULL,
    edad INT NOT NULL,
    genero VARCHAR(2),
    carrera VARCHAR(120),
    intereses VARCHAR(100),
    frase VARCHAR(150)
)ENGINE=INNODB;