using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RecetasRedondas.Models
{
    public class ComentarioDto
{
    public int UsuarioId { get; set; }
    public int RecetaId { get; set; }
    public string Contenido { get; set; }
}

}