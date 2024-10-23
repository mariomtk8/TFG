using RecetasRedondas.Models;
using System.Collections.Generic;
using RecetasRedondas.Data;


namespace RecetasRedondas.Services
{
    public class MenuSemanalService : IMenuSemanalService
    {
        private readonly IMenuSemanalRepository _menuSemanalRepository;

        public MenuSemanalService(IMenuSemanalRepository menuSemanalRepository)
        {
            _menuSemanalRepository = menuSemanalRepository;
        }

        public List<MenuSemanal> GenerarMenuSemana(int usuarioId)
        {
            return _menuSemanalRepository.GenerarMenuSemana(usuarioId);
        }

        public void CrearMenuSemanal(List<MenuSemanal> menuSemanal)
        {
            _menuSemanalRepository.CrearMenuSemanal(menuSemanal);
        }

        public List<MenuSemanal> GetMenuSemanalByUsuario(int usuarioId)
        {
            return _menuSemanalRepository.GetMenuSemanalByUsuario(usuarioId);
        }

        public void RegenerarMenuSemanal(int usuarioId)
        {
            _menuSemanalRepository.RegenerarMenuSemanal(usuarioId);
        }

        public void DeleteMenuSemanal(int idMenuSemanal)
        {
            _menuSemanalRepository.DeleteMenuSemanal(idMenuSemanal);
        }
    }
}
