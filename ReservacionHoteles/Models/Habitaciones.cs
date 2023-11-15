using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ReservacionHoteles.Models
{
    [Table("Habitaciones")]
    public class Habitaciones
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Display(Name = "NumeroHabitaciones")]
        public int? NumHabitaciones { get; set; }

        [Display(Name = "NumeroPersonas")]
        public int? NumPersonas { get; set; }

        [Column(TypeName = "smalldatetime")]
        [DataType(DataType.Date)]
        public DateTime? FechaRegistro { get; set; }
    }
}
