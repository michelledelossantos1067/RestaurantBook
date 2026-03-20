using Microsoft.EntityFrameworkCore;
using RestaurantBook.Models;

namespace RestaurantBook.Data
{
    public class RestaurantContext : DbContext
    {
        public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options) { }

        public DbSet<Mesa> Mesas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Reserva> Reservas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Mesa>().HasData(
                new Mesa { Id = 1, Numero = 1, Capacidad = 2, Disponible = true, Ubicacion = "Interior" },
                new Mesa { Id = 2, Numero = 2, Capacidad = 4, Disponible = true, Ubicacion = "Interior" },
                new Mesa { Id = 3, Numero = 3, Capacidad = 4, Disponible = true, Ubicacion = "Terraza" },
                new Mesa { Id = 4, Numero = 4, Capacidad = 6, Disponible = true, Ubicacion = "Terraza" },
                new Mesa { Id = 5, Numero = 5, Capacidad = 8, Disponible = true, Ubicacion = "Salón Privado" },
                new Mesa { Id = 6, Numero = 6, Capacidad = 2, Disponible = true, Ubicacion = "Interior" }
            );

            modelBuilder.Entity<Cliente>().HasData(
                new Cliente { Id = 1, Nombre = "María García", Email = "maria@email.com", Telefono = "809-555-0101", FechaRegistro = new DateTime(2024, 1, 10) },
                new Cliente { Id = 2, Nombre = "Carlos Martínez", Email = "carlos@email.com", Telefono = "809-555-0102", FechaRegistro = new DateTime(2024, 1, 15) }
            );

            modelBuilder.Entity<Reserva>().HasData(
                new Reserva { Id = 1, FechaHora = DateTime.Now.AddDays(1).Date.AddHours(20), NumeroPersonas = 2, Estado = "Confirmada", ClienteId = 1, MesaId = 1, FechaCreacion = DateTime.Now },
                new Reserva { Id = 2, FechaHora = DateTime.Now.AddDays(2).Date.AddHours(19), NumeroPersonas = 4, Estado = "Pendiente", ClienteId = 2, MesaId = 2, FechaCreacion = DateTime.Now }
            );
        }
    }
}
