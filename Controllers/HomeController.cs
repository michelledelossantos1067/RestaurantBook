using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantBook.Data;

namespace RestaurantBook.Controllers
{
    public class HomeController : Controller
    {
        private readonly RestaurantContext _context;

        public HomeController(RestaurantContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.TotalReservas = await _context.Reservas.CountAsync();
            ViewBag.ReservasHoy = await _context.Reservas
                .Where(r => r.FechaHora.Date == DateTime.Today)
                .CountAsync();
            ViewBag.MesasDisponibles = await _context.Mesas
                .Where(m => m.Disponible)
                .CountAsync();
            ViewBag.TotalClientes = await _context.Clientes.CountAsync();
            return View();
        }
    }
}
