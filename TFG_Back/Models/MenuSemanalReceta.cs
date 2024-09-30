using System;
using System.Collections.Generic;

namespace RecetasRedondas.Models
{
    public class MenuSemanalReceta
    {
        public int IdMenuSemanal { get; set; }
        public int IdReceta { get; set; }
        public DateTime Fecha { get; set; }
    }
}