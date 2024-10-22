using RecetasRedondas.Models;
using System.Collections.Generic;

namespace RecetasRedondas.Data
{
    public interface IMenuSemanalRepository
{
    void CrearMenuSemanal(MenuSemanal menuSemanal);
    MenuSemanal ObtenerMenuSemanalPorUsuario(int usuarioId);
    void ActualizarMenuSemanal(MenuSemanal menuSemanal);
}

}