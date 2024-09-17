using System.ComponentModel.DataAnnotations;

public class RecetasDTO
{
    public int RecetaID { get; set; }
    public string Titulo { get; set; }
    public string Descripcion { get; set; }
    public int TiempoPreparacion { get; set; }
    public DateTime FechaCreacion { get; set; }
    public string NombreCategoria { get; set; } // Simplificación para evitar enviar el objeto Categoría completo
}
