using System.ComponentModel.DataAnnotations;

public class CategoriasDTO
{
    public int CategoriaID { get; set; }
    public string NombreCategoria { get; set; }
    public string Descripcion { get; set; }
    public bool Visible { get; set; }
}