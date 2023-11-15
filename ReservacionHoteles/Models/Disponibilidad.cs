using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ReservacionHoteles.Models
{
    [Table("Disponibilidad")]
    public class Disponibilidad
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Display(Name = "Tipo")]
        public int? TipoRefId { get; set; }
        [ForeignKey("TipoRefId")]
        public virtual Tipo? Tipo { get; set; }

        [Display(Name = "Hotel")]
        public int? HotelRefId { get; set; }
        [ForeignKey("HotelRefId")]
        public virtual Hotel? Hotel { get; set; }

        [Column(TypeName = "smalldatetime")]
        [DataType(DataType.Date)]
        public DateTime? FechaRegistro { get; set; }
    }
}
