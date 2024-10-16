using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace RecetasRedondas.Models
{
    public class Favorito
    {
        [Key]
        public int IdFavorito { get; set; }
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; } 
        
        public int IdReceta { get; set; }
        public Receta Receta { get; set; } 
        
        public DateTime FechaFavorito { get; set; } 
    }
}