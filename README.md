# Sistema de Mueblería

Este proyecto es un sistema de gestión para una mueblería, desarrollado en C# (.NET Framework 4.8) como parte de mi cuarto semestre universitario. El sistema implementa conceptos de programación orientada a objetos y originalmente integraba acceso a bases de datos SQL/MySQL.

> **Nota importante:**  
> El proyecto ha sido **editado para funcionar completamente sin base de datos**.  
> Todos los datos (usuarios, productos, pedidos, etc.) se gestionan en memoria, permitiendo ejecutar y revisar el sistema fácilmente sin requerir configuración de MySQL ni ningún motor de base de datos.

## Características principales

- Gestión de usuarios (administrador, trabajador, cliente)
- Autenticación y control de acceso por roles
- Catálogo de productos y categorías
- Gestión de inventario y stock
- Registro y autenticación de clientes
- Simulación de pedidos y lista de deseos
- Interfaz gráfica desarrollada con WPF

## Tecnologías utilizadas

- **Lenguaje:** C#
- **Framework:** .NET Framework 4.8
- **Interfaz:** WPF (Windows Presentation Foundation)
- **Paradigma:** Programación orientada a objetos
- **Base de datos:** (Versión original) MySQL/SQL  
  (Actualmente, **no requiere base de datos**)

## Instalación y ejecución

1. **Clona el repositorio:**
2. **Abre la solución en Visual Studio 2022** (o compatible).
3. **Restaura los paquetes NuGet** si es necesario.
4. **Compila y ejecuta** el proyecto.

> **No es necesario tener una base de datos configurada para ejecutar la versión actual.**

## Estructura del proyecto

- `/Modelos` — Clases de dominio (Producto, Usuario, Categoria, etc.)
- `/Servicios` — Lógica de negocio y servicios de autenticación, reportes, etc.
- `/Vistas` — Interfaz de usuario (ventanas y páginas WPF)
- `/VistaModelo` — Lógica de presentación (MVVM)

## Créditos

Desarrollado por [Gabriand](https://github.com/Gabriand) y su equipo de compañeros durante el cuarto semestre de la carrera universitaria.

## Licencia

Este proyecto es de uso académico y personal. Puedes modificarlo y adaptarlo según tus necesidades educativas.

---

¿Tienes dudas o sugerencias? ¡No dudes en abrir un issue o contactarme!