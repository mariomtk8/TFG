using System.ComponentModel.DataAnnotations;

namespace RecetasRedondas.Models
{
    public class AddCategoriaDTO
    {
        [Required]
        [Key]
        public int IdUsuarioCategoria { get; set; }
        [Required]
        public int IdCategoria { get; set; }
    }
}