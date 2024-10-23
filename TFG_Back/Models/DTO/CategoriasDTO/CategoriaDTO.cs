using System.ComponentModel.DataAnnotations;

public class CategoriaDTO
    {
        [Key]
        public int IdUsuarioCategoria { get; set; }
        public int IdCategoria { get; set; }
        public int IdUsuario { get; set; }
        public string? NombreCategoria { get; set; }
    }
