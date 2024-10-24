using System.ComponentModel.DataAnnotations;

namespace RecetasRedondas.Models
{
    public class AlergenoDTO
    {
        [Key]
        public int IdAlergeno { get; set; }
        public int IdUsuario { get; set; }
        public int IdIngrediente { get; set; }
        public string? NombreIngrediente { get; set; }
    }
}
