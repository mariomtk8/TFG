using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace RecetasRedondas.Models
{
    public class RecetaIngrediente
    {
        public int IdReceta { get; set; }
        public int IdIngrediente { get; set; }
        public decimal Cantidad { get; set; }
        public string Notas { get; set; } 
        public DateTime FechaAñadido { get; set; } 
        public bool EsOpcional { get; set; }
    }
}
