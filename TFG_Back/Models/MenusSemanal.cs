using System;
using System.Collections.Generic;

namespace RecetasRedondas.Models
{
    public class MenuSemanal
{
    public int IdMenuSemanal { get; set; }
    public int IdUsuario { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public String Descripcion { get; set; }

}
}   