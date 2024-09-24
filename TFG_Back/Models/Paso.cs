using System;
using System.Text.Json.Serialization;

namespace RecetasRedondas.Models
{
    public class Paso
    {
        public int IdPaso { get; set; }          // ID del paso (clave primaria)
        public int IdReceta { get; set; }        // ID de la receta (clave foránea)
        public int Numero { get; set; }           // Número del paso
        public string Descripcion { get; set; }   // Descripción del paso
        public string ImagenUrl { get; set; }      // URL de la imagen para el paso

        // Propiedad de navegación (opcional, no siempre necesaria)
        [JsonIgnore]
        public Receta Receta { get; set; }
    }
}
