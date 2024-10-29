using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RecetasRedondas.Models
{
    public class VotacionDto
{
    public int UsuarioId { get; set; }
    public int RecetaId { get; set; }
    public int Puntuacion { get; set; }
}

}