using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RecetasRedondas.Models
{
    public class Comentario
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public int RecetaId { get; set; }
    public string ?Contenido { get; set; }
    public DateTime Fecha { get; set; } = DateTime.UtcNow;

    // Relaciones
    [JsonIgnore]
    public Usuario ?Usuario { get; set; }
    public Receta ?Receta { get; set; }
}

}