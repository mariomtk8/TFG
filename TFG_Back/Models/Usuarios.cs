using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecetasRedondas.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        [Required]
        public string ?Nombre { get; set; }
        [Required]
        public string ?Correo { get; set; }
        [Required]
        public string ?Contrasena { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool Rol { get; set; }
        public List<Favorito> ?Favoritos { get; set; }
        public List<MenuSemanal> ?MenusSemanales { get; set; }
        public List<Alergeno> ?Alergenos { get; set; } = new List<Alergeno>();
        public List<UsuarioCategoria> ?UsuarioCategorias { get; set; } = new List<UsuarioCategoria>();
    }
}
