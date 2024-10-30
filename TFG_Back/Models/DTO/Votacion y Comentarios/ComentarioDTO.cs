using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RecetasRedondas.Models
{
    public class ComentarioDto
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public string? Contenido { get; set; }
    public DateTime Fecha { get; set; }
    public string? NombreUsuario { get; set; } 
}

}