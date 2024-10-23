using System.ComponentModel.DataAnnotations;

public class UsuariosDTO
{
    public int UsuarioID { get; set; }
    public string Nombre { get; set; }
    public string Email { get; set; }
    public DateTime FechaRegistro { get; set; }
    public bool EsAdmin { get; set; }
}
