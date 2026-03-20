using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestaurantBook.Data;
using RestaurantBook.Models;

namespace RestaurantBook.Controllers
{
    public class ReservasController : Controller
    {
        private readonly RestaurantContext _context;

        public ReservasController(RestaurantContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var reservas = await _context.Reservas
                .Include(r => r.Cliente)
                .Include(r => r.Mesa)
                .OrderByDescending(r => r.FechaHora)
                .ToListAsync();
            return View(reservas);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Clientes = new SelectList(await _context.Clientes.ToListAsync(), "Id", "Nombre");
            ViewBag.Mesas = new SelectList(await _context.Mesas.Where(m => m.Disponible).ToListAsync(), "Id", "Numero");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FechaHora,NumeroPersonas,ClienteId,MesaId,Notas")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                reserva.Estado = "Pendiente";
                reserva.FechaCreacion = DateTime.Now;
                _context.Add(reserva);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Reserva creada correctamente.";
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Clientes = new SelectList(await _context.Clientes.ToListAsync(), "Id", "Nombre");
            ViewBag.Mesas = new SelectList(await _context.Mesas.Where(m => m.Disponible).ToListAsync(), "Id", "Numero");
            return View(reserva);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva == null) return NotFound();
            ViewBag.Clientes = new SelectList(await _context.Clientes.ToListAsync(), "Id", "Nombre", reserva.ClienteId);
            ViewBag.Mesas = new SelectList(await _context.Mesas.ToListAsync(), "Id", "Numero", reserva.MesaId);
            ViewBag.Estados = new SelectList(new[] { "Pendiente", "Confirmada", "Cancelada", "Completada" }, reserva.Estado);
            return View(reserva);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FechaHora,NumeroPersonas,Estado,ClienteId,MesaId,Notas,FechaCreacion")] Reserva reserva)
        {
            if (id != reserva.Id) return NotFound();
            if (ModelState.IsValid)
            {
                _context.Update(reserva);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Reserva actualizada correctamente.";
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Clientes = new SelectList(await _context.Clientes.ToListAsync(), "Id", "Nombre", reserva.ClienteId);
            ViewBag.Mesas = new SelectList(await _context.Mesas.ToListAsync(), "Id", "Numero", reserva.MesaId);
            ViewBag.Estados = new SelectList(new[] { "Pendiente", "Confirmada", "Cancelada", "Completada" }, reserva.Estado);
            return View(reserva);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var reserva = await _context.Reservas
                .Include(r => r.Cliente)
                .Include(r => r.Mesa)
                .FirstOrDefaultAsync(r => r.Id == id);
            if (reserva == null) return NotFound();
            return View(reserva);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var reserva = await _context.Reservas
                .Include(r => r.Cliente)
                .Include(r => r.Mesa)
                .FirstOrDefaultAsync(r => r.Id == id);
            if (reserva == null) return NotFound();
            return View(reserva);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva != null)
            {
                _context.Reservas.Remove(reserva);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Reserva eliminada correctamente.";
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> CambiarEstado(int id, string estado)
        {
            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva != null)
            {
                reserva.Estado = estado;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
