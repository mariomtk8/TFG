using RecetasRedondas.Data;
using RecetasRedondas.Models;
using System.Collections.Generic;

namespace RecetasRedondas.Business
{
    public class MenuSemanalService : IMenuSemanalService
    {
        private readonly IMenuSemanalRepository _menuSemanalRepository;

        public MenuSemanalService(IMenuSemanalRepository menuSemanalRepository)
        {
            _menuSemanalRepository = menuSemanalRepository;
        }

        public List<MenuSemanal> GetAll() => _menuSemanalRepository.GetAll();

        public MenuSemanal Get(int id) => _menuSemanalRepository.Get(id);

        public void Update(MenuSemanal menuSemanal) => _menuSemanalRepository.Update(menuSemanal);

        public void Add(MenuSemanal menuSemanal) => _menuSemanalRepository.Add(menuSemanal);

        public void Delete(int id) => _menuSemanalRepository.Delete(id);
    }
}
