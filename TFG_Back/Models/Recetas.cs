using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RecetasRedondas.Models
{
    public class Receta
    {
    public int IdReceta { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public string Imagen { get; set; }
     [JsonIgnore]
    public List<Paso> Pasos { get; set; } = new List<Paso>();
    public bool EsVegano { get; set; }
    public DateTime FechaCreacion { get; set; }
    public decimal NivelDificultad { get; set; }
    public int TiempoPreparacion { get; set; }
    public int IdCategoria { get; set; }
    }
}
