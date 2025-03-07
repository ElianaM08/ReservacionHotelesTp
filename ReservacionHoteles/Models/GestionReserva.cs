using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ReservacionHoteles.Models
{
    [Table("GestionReserva")]
    public class GestionReserva
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Display(Name = "Fecha/Hora Entrada")]
        [Column(TypeName = "smalldatetime")]
        [DataType(DataType.DateTime)]
        public DateTime? FechaHoraEntrada { get; set; }

        [Display(Name = "Fecha/Hora Salida")]
        [Column(TypeName = "smalldatetime")]
        [DataType(DataType.DateTime)]
        public DateTime? FechaHoraSalida { get; set; }

        [Display(Name = "Hotel")]
        public int? HotelRefId { get; set; }
        [ForeignKey("HotelRefId")]
        public virtual Hotel? Hotel { get; set; }

        [Display(Name = "Destinos")]
        public int? DestinosRefId { get; set; }
        [ForeignKey("DestinosRefId")]
        public virtual Destinos? Destinos{ get; set; }
        [Display(Name = "Habitaciones")]
        public int? HabitacionesRefId { get; set; }
        [ForeignKey("HabitacionesRefId")]
        public virtual Habitaciones? Habitaciones { get; set; }

        [Display(Name = "Tarifa 1")]
        public int? Tarifa1RefId { get; set; }
        [ForeignKey("Tarifa1RefId")]
        public virtual Tarifa? Tarifa1 { get; set; }

        //[Display(Name = "Tarifa 2")]
        //public int? Tarifa2RefId { get; set; }
        //[ForeignKey("Tarifa2RefId")]
        //public virtual Tarifa? Tarifa2 { get; set; }

        //[Display(Name = "Tarifa 3")]
        //public int? Tarifa3RefId { get; set; }
        //[ForeignKey("Tarifa3RefId")]
        //public virtual Tarifa? Tarifa3 { get; set; }

        //[Display(Name = "Tarifa 4")]
        //public int? Tarifa4RefId { get; set; }
        //[ForeignKey("Tarifa4RefId")]
        //public virtual Tarifa? Tarifa4 { get; set; }

        //[Display(Name = "Tarifa 5")]
        //public int? Tarifa5RefId { get; set; }
        //[ForeignKey("Tarifa5RefId")]
        //public virtual Tarifa? Tarifa5 { get; set; }

        //[Display(Name = "Tarifa 6")]
        //public int? Tarifa6RefId { get; set; }
        //[ForeignKey("Tarifa6RefId")]
        //public virtual Tarifa? Tarifa6 { get; set; }

        [Display(Name = "Fecha Registro")]
        [Column(TypeName = "smalldatetime")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime? FechaRegistro { get; set; }

        [NotMapped]
        public string? ValidationError { get; set; }
    }
}
