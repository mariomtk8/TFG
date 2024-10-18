using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecetasRedondas.Models
{
    public class RecetaIngrediente
    {
        [Key]
        public int IdRecetaIngrediente {get;set;}
        public int IdReceta { get; set; }
        public int IdIngrediente { get; set; }
        public decimal Cantidad { get; set; }
        public string Notas { get; set; } 
        public DateTime FechaAñadido { get; set; } 
        public bool EsOpcional { get; set; }

        public Receta Receta { get; set; }
        public Ingrediente Ingrediente { get; set; }
    }
}
