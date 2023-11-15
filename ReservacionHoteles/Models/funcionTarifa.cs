using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ReservacionHoteles.Models
{
    [Table("FuncionTarifa")]
    public class funcionTarifa
    {
        public int Id { get; set; }

        [Display(Name = "Tarifa")]
        [Required(ErrorMessage = "Por favor, seleccione una tarifa.")]
        public int? TarifaRefId { get; set; }

        [ForeignKey("TarifaRefId")]
        public virtual Tarifa? Tarifa { get; set; }

        public int? FuncionId { get; set; }
        [ForeignKey("FuncionId")]

        public DateTime Created { get; set; } = DateTime.Now;
    }
}
