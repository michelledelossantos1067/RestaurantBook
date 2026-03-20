using System.ComponentModel.DataAnnotations;

namespace RestaurantBook.Models
{
    public class Reserva
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La fecha es requerida")]
        [Display(Name = "Fecha y Hora")]
        public DateTime FechaHora { get; set; }

        [Required(ErrorMessage = "El número de personas es requerido")]
        [Range(1, 20, ErrorMessage = "Debe ser entre 1 y 20 personas")]
        [Display(Name = "Número de Personas")]
        public int NumeroPersonas { get; set; }

        [Display(Name = "Estado")]
        public string Estado { get; set; } = "Pendiente";

        [Display(Name = "Notas")]
        [StringLength(500)]
        public string? Notas { get; set; }

        [Display(Name = "Fecha de Creación")]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        [Required]
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        [Required]
        public int MesaId { get; set; }
        public Mesa? Mesa { get; set; }
    }
}
