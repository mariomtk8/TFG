using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace RecetasRedondas.Models
{
    public class MenuSemanal
    {
        [Key]
        public int IdMenuSemanal { get; set; }
        public string ?Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public bool TipoComida { get; set; } //Comida= "True" Cena= "False"

        public int IdUsuario { get; set; }
        public Usuario ?Usuario { get; set; }

        public int IdReceta { get; set; }
        public Receta ?Receta { get; set; }

    }

}