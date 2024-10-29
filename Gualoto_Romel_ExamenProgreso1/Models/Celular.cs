using System.ComponentModel.DataAnnotations;

namespace Gualoto_Romel_ExamenProgreso1.Models
{
    public class Celular
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El modelo es obligatorio.")]
        [StringLength(50, ErrorMessage = "El modelo no puede superar los 50 caracteres.")]
        public string Modelo { get; set; }

        [Range(2000, 2024, ErrorMessage = "El año debe estar entre 2000 y 2024.")]
        public int Año { get; set; }

        [DataType(DataType.Currency)]
        public decimal Precio { get; set; }
    }
}
