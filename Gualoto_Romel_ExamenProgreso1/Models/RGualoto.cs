using System.ComponentModel.DataAnnotations;

namespace Gualoto_Romel_ExamenProgreso1.Models
{
    public class RGualoto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [StringLength(50, ErrorMessage = "El nombre no puede superar los 50 caracteres.")]
        public string Nombre { get; set; }

        [Range(0, 100, ErrorMessage = "La edad debe estar entre 0 y 100 anios.")]
        public int Edad { get; set; }

        [DataType(DataType.Currency)]
        public decimal IngresoMensual { get; set; }

        public bool Activo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-mm-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaNacimiento { get; set; }

        public int CelularId { get; set; }

        public Celular Celular { get; set; }

    }
}
