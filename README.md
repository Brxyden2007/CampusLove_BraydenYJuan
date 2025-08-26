# Campus Love - Sistema de Emparejamiento

- Campus Love es una aplicación de consola en C# que simula un completo sistema de emparejamiento entre usuarios, inspirada en plataformas como Tinder. El proyecto se enfoca en la implementación de una arquitectura limpia, aplicando los principios SOLID y diversos patrones de diseño para garantizar un código modular, mantenible y escalable.

- El sistema permite a los usuarios registrarse, explorar perfiles, interactuar con otros a través de "likes" y "dislikes", y descubrir coincidencias mutuas. Además, incorpora un sistema de economía de "créditos" que limita las interacciones diarias, ofreciendo una experiencia de uso realista y controlada.

### Contexto y Especificaciones

- Esta aplicación de consola ha sido diseñada para ser una simulación interactiva que pone en práctica conocimientos de programación avanzados, como la gestión de datos, la interacción con el usuario y la aplicación de buenas prácticas de ingeniería de software.

## El sistema soporta las siguientes funcionalidades:

### Registro de Usuarios: 

- Permite la creación de perfiles con atributos como nombre, edad, género, intereses, carrera y una frase de perfil.

### Gestión de Interacciones: 
- Los usuarios pueden ver perfiles disponibles uno por uno y elegir entre "Like" y "Dislike".

### Sistema de Emparejamiento: 
- Si dos usuarios se dan "Like" mutuamente, se crea una coincidencia (match).

### Listado de Coincidencias: 
- Cada usuario puede visualizar un listado de todos sus matches.

### Control de Interacciones:
- Se ha implementado un sistema de "créditos de interacción" que limita la cantidad de likes que un usuario puede dar por día.

### Estadísticas del Sistema: 
- Muestra información relevante sobre la interacción de los usuarios, como el usuario con más likes recibidos, usando consultas LINQ.

### Formato de Datos: 
- El uso de CultureInfo y NumberFormat garantiza una presentación de datos clara y adaptada culturalmente.

## Requisitos Funcionales

- Menú Interactivo: Interfaz de consola que guía al usuario a través de las diferentes opciones disponibles.

- Almacenamiento de Datos: Los usuarios e interacciones se guardan en colecciones de C# como listas o diccionarios, lo que permite una simulación en memoria.

- Simulación de Multiusuario: El diseño del sistema permite simular interacciones entre múltiples usuarios, emulando un entorno multicliente.

- Patrones de Diseño: Implementación del patrón Factory para la creación de usuarios y/o interacciones, asegurando una separación clara de responsabilidades.

- Principios de Diseño: Adherencia a los principios SOLID y una clara separación de la lógica de negocio, validación y presentación.

## Requisitos No Funcionales
- Experiencia de Usuario: Interacción con la consola fluida y amigable.

- Estructura del Código: Código bien organizado en clases separadas, como Usuario, Interaccion, MatchService, etc.

- Validación de Datos: Validación robusta de la entrada del usuario, incluyendo tipos de datos y rangos de valores.

- Manejo de Excepciones: Uso de int.TryParse y otras técnicas para un manejo seguro de la entrada de datos.

### Diagrama de Clases
El diagrama de clases ilustra las principales entidades y sus relaciones dentro del sistema, mostrando la estructura del proyecto basada en la arquitectura limpia y la separación de responsabilidades.

## Tecnologías

- Lenguaje: C#

- Plataforma: .NET 8.0

- IDE: Visual Studio Code (sugerido)

# Hecho Por:

- Brayden Poveda (Brxyden2007)
- Juan Romero (JuanRomer0)

### Gracias por su visita!