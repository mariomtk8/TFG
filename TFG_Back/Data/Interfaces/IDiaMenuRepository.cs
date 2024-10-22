using System.Collections.Generic;
using RecetasRedondas.Models;

namespace RecetasRedondas.Data
{
    public interface IDiaMenuRepository
    {
        List<DiaMenu> GenerarMenuDia(int usuarioId);
        void CrearMenuDiario(DiaMenu diaMenu); // Método para agregar un menú diario
        List<DiaMenu> GetAll(); // Método para obtener todos los menús diarios
    }
}
