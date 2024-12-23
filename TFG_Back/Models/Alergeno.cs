using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace RecetasRedondas.Models
{
    public class Alergeno
    {
        [Key]
        public int IdAlergeno { get; set; }

        public int IdUsuario { get; set; }
        public Usuario? Usuarios { get; set; }

        public int IdIngrediente { get; set; }
        public Ingrediente? Ingredientes { get; set; }


    }

}