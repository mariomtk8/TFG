using RecetasRedondas.Models;
using System.Collections.Generic;

namespace RecetasRedondas.Business
{
    public interface IMenuSemanalService
    {
        List<MenuSemanal> GetAll();
        MenuSemanal Get(int id);
        void Add(MenuSemanal menuSemanal);
        void Update(MenuSemanal menuSemanal);
        void Delete(int id);
    }
}
