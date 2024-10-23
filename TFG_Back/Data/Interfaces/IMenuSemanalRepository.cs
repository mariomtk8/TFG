using RecetasRedondas.Models;
using System.Collections.Generic;


namespace RecetasRedondas.Data
{
    public interface IMenuSemanalRepository
    {
        List<MenuSemanal> GenerarMenuSemana(int usuarioId);
        void CrearMenuSemanal(List<MenuSemanal> menuSemanal);
        List<MenuSemanal> GetMenuSemanalByUsuario(int usuarioId);
        void RegenerarMenuSemanal(int usuarioId);
        void DeleteMenuSemanal(int idMenuSemanal);
    }
}
