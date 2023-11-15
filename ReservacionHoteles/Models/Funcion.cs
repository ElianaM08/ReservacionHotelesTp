using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ReservacionHoteles.Models
{
    [Table("Funcion")]
    public class Funcion
    {
        public int Id { get; set; }

        [Display(Name = "Fecha/Hora Entrada")]
        [Column(TypeName = "smalldatetime")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Por favor, ingrese fecha y hora para la entrada")]
        public DateTime? FechaHoraEntrada { get; set; }

        [Display(Name = "Fecha/Hora Salida")]
        [Column(TypeName = "smalldatetime")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Por favor, ingrese fecha y hora para la salida")]
        public DateTime? FechaHoraSalida { get; set; }

        [Display(Name = "Hotel")]
        [Required(ErrorMessage = "Por favor, seleccione un hotel.")]
        public int? HotelRefId { get; set; }

        [ForeignKey("HotelRefId")]
        public virtual Hotel? Hotel { get; set; }

        [Display(Name = "Destinos")]
        [Required(ErrorMessage = "Por favor, seleccione un destino.")]
        public int? DestinoRefId { get; set; }

        [ForeignKey("DestinoRefId")]
        public virtual Destinos? Destinos { get; set; }


        [Display(Name = "Habitaciones")]
        [Required(ErrorMessage = "Por favor, seleccione una habitacion.")]
        public int? HabitacionesRefId { get; set; }

        [ForeignKey("HabitacionesRefId")]
        public virtual Habitaciones? Habitaciones { get; set; }
        public virtual List<funcionTarifa> Tarifas { get; set; }

        public DateTime? FechaRegistro { get; set; } = DateTime.Now;

        [NotMapped]
        public string? ValidationError { get; set; }

        public int NumberOfTarifas
        {
            get => Tarifas.Count;
        }

        public Funcion()
        {
            Tarifas = new List<funcionTarifa>();
        }
    }
}
