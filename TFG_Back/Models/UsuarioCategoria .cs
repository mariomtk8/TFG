using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecetasRedondas.Models
{
    public class UsuarioCategoria
    {
        [Key]
        public int IdUsuarioCategoria { get; set; }

        public int IdUsuario { get; set; }
        public Usuario ?Usuario { get; set; }

        public int IdCategoria { get; set; }
        public Categoria ?Categoria { get; set; }
    }
}
