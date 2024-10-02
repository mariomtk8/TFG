using System;
using System.Text.Json.Serialization;

namespace RecetasRedondas.Models
{
    public class RecetasPaso
    {

        public int IdRecetasPaso { get; set; }   
        public int IdPaso { get; set; }          // ID del paso (clave primaria)
        public int IdReceta { get; set; }  
         public Paso Paso { get; set; }      // ID de la receta (clave foránea)
        public Receta Receta { get; set; }
    }
}
