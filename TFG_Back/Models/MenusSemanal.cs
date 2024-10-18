using System;
using System.Collections.Generic;

namespace RecetasRedondas.Models
{
    public class MenuSemanal
{
    public int IdMenuSemanal { get; set; }
    public int IdUsuario { get; set; }
    public int NumSemana { get; set; }
    public Usuario Usuario { get; set; }
    public string Descripcion { get; set; }

    public DateTime FechaInicio { get; set; }

    public List<DiaMenu> DiasMenu { get; set; }
}

}   