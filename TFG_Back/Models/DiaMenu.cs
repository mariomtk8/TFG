using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace RecetasRedondas.Models
{
    public class DiaMenu
    {
        [Key]
        public int IdDiaMenu { get; set; }
        public DateTime Fecha { get; set; }

        public int IdReceta { get; set; }
        public Receta Receta { get; set; }

        public bool TipoComida { get; set; } //Comida= "True" Cena= "False"

        public int? IdMenuSemanal { get; set; } // Clave foránea para MenuSemanal
        public MenuSemanal? MenuSemanal { get; set; }

    }

}