# RestaurantBook

Sistema de gestión de reservas para restaurantes desarrollado en ASP.NET Core MVC con Entity Framework Core y SQLite.

## Tecnologías

- ASP.NET Core 8 MVC
- Entity Framework Core 8
- SQLite (base de datos embebida, sin configuración)
- C# 12

## Módulos

- **Reservas** — CRUD completo, estados (Pendiente, Confirmada, Cancelada, Completada)
- **Mesas** — Gestión de mesas con disponibilidad y ubicación
- **Clientes** — Registro de clientes con historial de reservas
- **Panel Admin** — Dashboard con métricas y resumen general

La base de datos SQLite se crea automáticamente al iniciar la aplicación. No se necesita ninguna configuración adicional.

## Estructura del proyecto

```
RestaurantBook/
├── Controllers/
│   ├── HomeController.cs
│   ├── ReservasController.cs
│   ├── MesasController.cs
│   ├── ClientesController.cs
│   └── AdminController.cs
├── Models/
│   ├── Reserva.cs
│   ├── Mesa.cs
│   └── Cliente.cs
├── Data/
│   └── RestaurantContext.cs
├── Views/
│   ├── Home/
│   ├── Reservas/
│   ├── Mesas/
│   ├── Clientes/
│   └── Admin/
├── Migrations/
└── wwwroot/css/site.css
```

## Equipo — HCHDavos

| Integrante | Rol | Módulo |
|---|---|---|
| Dianny | Product Owner / Dev Lead | Setup + Modelos + BD |
| Reynaldo | Full-Stack Developer | Módulo Reservas |
| Gerny Arismendy | Full-Stack Developer | Módulo Mesas + Clientes |
| Jean Carlos Terrero | QA / Frontend | Admin Panel + CSS |

## Proyecto académico

Desarrollado para la asignatura de Gestión de Proyectos de Software.
Herramienta de gestión: JIRA — Organización: HCHDavos
