using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace RecetasRedondas.Models
{
    public class Ingrediente
    {
        public int IdIngrediente { get; set; }
        public string ?NombreIngrediente { get; set; }
        public decimal Calorias { get; set; }
        public bool ?ContieneAlergenos { get; set; }
        public string ?TipoAlergeno { get; set; }
        public string ?UnidadMedida { get; set; }
        public DateTime FechaExpiracion { get; set; }
        public List<RecetaIngrediente> recetaIngredientes  { get; set; } = new List<RecetaIngrediente>();
        public List<Alergeno> ?Alergenos { get; set; }
    }
}
