using RecetasRedondas.Models;
using System.Collections.Generic;

namespace RecetasRedondas.Data
{
    public interface IMenuSemanalRepository
    {
        List<MenuSemanal> GetAll();
        MenuSemanal Get(int id);
        void Add(MenuSemanal menuSemanal);
        void Update(MenuSemanal menuSemanal);
        void Delete(int id);
    }
}
