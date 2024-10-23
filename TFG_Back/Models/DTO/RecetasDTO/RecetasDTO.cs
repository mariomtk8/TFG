using System.ComponentModel.DataAnnotations;

namespace RecetasRedondas.Models
{
    public class RecetaDTO
    {
    public int IdReceta { get; set; }
    public string ?Nombre { get; set; }
    public string ?Descripcion { get; set; }
    public string ?Imagen { get; set; }
    public List<DatosPasoDTO> ?Pasos { get; set; } = new List<DatosPasoDTO>();
    public bool EsVegano { get; set; }
    public DateTime FechaCreacion { get; set; }
    public decimal NivelDificultad { get; set; }
    public int TiempoPreparacion { get; set; }
    public int IdCategoria { get; set; }
    }
}

