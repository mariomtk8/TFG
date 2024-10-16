using System;
using System.Text.Json.Serialization;

namespace RecetasRedondas.Models
{
    public class RecetasPaso
    {

        public int IdRecetasPaso { get; set; }   
        public int IdPaso { get; set; }          
        public int IdReceta { get; set; }  
         public Paso Paso { get; set; }      
        public Receta Receta { get; set; }
    }
}
