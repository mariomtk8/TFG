using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RecetasRedondas.Models
{
    public class Votacion
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public int RecetaId { get; set; }
    public int Puntuacion { get; set; } 

    // Relaciones
    public Usuario Usuario { get; set; }
    public Receta Receta { get; set; }
}

}