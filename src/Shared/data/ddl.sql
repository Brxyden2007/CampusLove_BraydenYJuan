DROP DATABASE IF EXISTS db_campuslove;
CREATE DATABASE IF NOT EXISTS db_campuslove;
USE db_campuslove;

CREATE TABLE IF NOT EXISTS usuarios(
    id INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
    nombre VARCHAR(50),
    edad INT NOT NULL,
    genero VARCHAR(2),
    carrera VARCHAR(120),
    intereses VARCHAR(100),
    frase VARCHAR(150)
)ENGINE=INNODB;