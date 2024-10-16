using System;
using System.Text.Json.Serialization;

namespace RecetasRedondas.Models
{
    public class DatosPasoDTO
    {
        public int IdPaso { get; set; }          
        public int IdReceta { get; set; }       
        public int Numero { get; set; }          
        public string Descripcion { get; set; }   
        public string ImagenUrl { get; set; }   

    }
}
