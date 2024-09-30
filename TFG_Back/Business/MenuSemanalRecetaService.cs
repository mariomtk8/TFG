using RecetasRedondas.Data;
using RecetasRedondas.Models;
using System;
using System.Collections.Generic;

namespace RecetasRedondas.Business
{
    public class MenuSemanalRecetaService : IMenuSemanalRecetaService
    {
        private readonly IMenuSemanalRecetaRepository _menuSemanalRecetaRepository;

        public MenuSemanalRecetaService(IMenuSemanalRecetaRepository menuSemanalRecetaRepository)
        {
            _menuSemanalRecetaRepository = menuSemanalRecetaRepository;
        }

        public List<MenuSemanalReceta> GetAll() => _menuSemanalRecetaRepository.GetAll();

        public MenuSemanalReceta Get(int idMenuSemanal, int idReceta, DateTime fecha) =>
            _menuSemanalRecetaRepository.Get(idMenuSemanal, idReceta, fecha);

        public void Update(MenuSemanalReceta menuSemanalReceta) => _menuSemanalRecetaRepository.Update(menuSemanalReceta);

        public void Add(MenuSemanalReceta menuSemanalReceta) => _menuSemanalRecetaRepository.Add(menuSemanalReceta);

        public void Delete(int idMenuSemanal, int idReceta, DateTime fecha) =>
            _menuSemanalRecetaRepository.Delete(idMenuSemanal, idReceta, fecha);
    }
}
