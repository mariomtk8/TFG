using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RecetasRedondas.Models
{
    public class RecetasMDTO
    {
    public int IdReceta { get; set; }
    public string Nombre { get; set; }
    public string Imagen { get; set; }
    
    }
}
