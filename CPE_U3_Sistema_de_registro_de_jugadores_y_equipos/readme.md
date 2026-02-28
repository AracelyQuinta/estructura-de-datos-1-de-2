# Sistema de Registro de Jugadores y Equipos 
## Descripción
Este proyecto corresponde a la Unidad 3 de Estructura de Datos y consiste en la implementación de un sistema de registro para un torneo de fútbol.
El sistema fue desarrollado en C# (.NET 10) utilizando las estructuras de datos Conjunto (HashSet) y Mapa (Dictionary), garantizando la unicidad de jugadores y equipos, y permitiendo la asociación ordenada entre ellos.
## Objetivos
- Aplicar los conceptos de conjuntos y mapas en un problema real.
- Garantizar que no existan duplicados en jugadores ni equipos.
- Permitir la asignación clara de jugadores a equipos.
- Implementar reportería para visualizar el estado del torneo en tiempo real.
## Estructura del Proyecto
El sistema está organizado en clases siguiendo los principios de la Programación Orientada a Objetos (POO):
- Program.cs → Punto de entrada del sistema.
- Menu.cs → Interfaz de usuario por consola.
- Torneo.cs → Gestión de equipos y jugadores mediante Dictionary.
- Equipo.cs → Representa un equipo con un conjunto (HashSet) de jugadores.
- Jugador.cs → Entidad que representa a un jugador.
- DatosBase.cs → Precarga de equipos y jugadores de ejemplo.
## Funcionalidades
- Registrar nuevos equipos.
- Registrar jugadores en equipos existentes.
- Mostrar todos los equipos registrados.
- Mostrar todos los jugadores inscritos.
- Mostrar jugadores agrupados por equipo.
- Validar entradas para evitar valores nulos o vacíos.
- Evitar duplicados en equipos y jugadores.
- Control opcional de capacidad máxima de jugadores por equipo.
# Ejemplo de Uso
Al ejecutar el programa, se despliega un menú interactivo:

<img width="358" height="321" alt="image" src="https://github.com/user-attachments/assets/9742fdfc-1eb0-4f40-8eea-78adcdc13117" />

## Tecnologías Utilizadas
- Lenguaje: C#
- Plataforma: .NET 10
- IDE: Visual Studio Code
- Control de versiones: Git/GitHub
- Sistema operativo: Windows 11
