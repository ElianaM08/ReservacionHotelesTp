using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ReservacionHoteles.ViewModels;

namespace ReservacionHoteles.Models
{
    [Table("Hotel")]
    public class Hotel
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }


        [Display(Name = "Nombre")]
        [StringLength(50)]
        public string? Nombre { get; set; }


        [Display(Name = "Descripción")]
        [StringLength(50)]
        public string? Descripcion { get; set; }

        [Display(Name = "Imagen")]
        public string? ImagemHotel { get; set; }

        [Display(Name = "Tipo")]
        public string? TipoRefId { get; set; }
        public virtual Tipo? Tipo { get; set; }

        [Display(Name = "Destino")]
        public string? DestinosRefId { get; set; }
        [ForeignKey("DestinoRefId")]
        public virtual Destinos? Destinos { get; set; }

        [Display(Name = "Calificacion")]
        public int? Calificacion { get; set; }

        [Display(Name = "Fecha Entrada")]
        [Column(TypeName = "smalldatetime")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime? FechaEntrada { get; set; }

        [Display(Name = "Fecha Salida")]
        [Column(TypeName = "smalldatetime")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime? FechaSalida { get; set; }

        [Display(Name = "Fecha Registro")]
        [Column(TypeName = "smalldatetime")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime? FechaRegistro { get; set; }
    }
}
