using System.Collections.Generic;
using RecetasRedondas.Models;

namespace RecetasRedondas.Services
{
    public interface IDiaMenuService
    {
        void CrearMenuDiario(int usuarioId);
        List<DiaMenu> ObtenerMenuDiario();
    }
}
