namespace RecetasRedondas.Models;
using System.ComponentModel.DataAnnotations;
public class UsuarioDTO

{
    [Key]
    public int IdUsuario { get; set; }
    [Required]
    public string? Nombre { get; set; }
    [Required]
    public string? Contrasena { get; set; }
    [Required]
    public string? Correo { get; set; }
    public bool Rol { get; set; }
}
