# 🍽 RestaurantBook

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

## Instalación y ejecución

```bash
# 1. Clonar el repositorio
git clone https://HCHDavos@dev.azure.com/HCHDavos/RestaurantBook/_git/RestaurantBook

# 2. Restaurar dependencias
cd RestaurantBook
dotnet restore

# 3. Ejecutar (las migraciones se aplican automáticamente)
dotnet run

# 4. Abrir en el navegador
# http://localhost:5000
```

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
| Integrante 1 | Product Owner / Dev Lead | Setup + Modelos + BD |
| Integrante 2 | Full-Stack Developer | Módulo Reservas |
| Integrante 3 | Full-Stack Developer | Módulo Mesas + Clientes |
| Integrante 4 | QA / Frontend | Admin Panel + CSS |

## Proyecto académico

Desarrollado para la asignatura de Gestión de Proyectos de Software.
Herramienta de gestión: Azure DevOps — Organización: HCHDavos
