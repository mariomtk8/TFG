using System;

namespace RecetasRedondas.Models
{
    public class Categoria
    {
        public int IdCategoria { get; set; }
        public string NombreCategoria { get; set; }
        public string Descripcion { get; set; }
        public bool Visible { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Icono { get; set; }
        public decimal PuntuacionPromedio { get; set; }
    }
}
