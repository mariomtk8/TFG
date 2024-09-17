using RecetasRedondas.Models;
using System;
using System.Collections.Generic;

namespace RecetasRedondas.Business
{
    public interface IMenuSemanalRecetaService
    {
        List<MenuSemanalReceta> GetAll();
        MenuSemanalReceta Get(int idMenuSemanal, int idReceta, DateTime fecha);
        void Add(MenuSemanalReceta menuSemanalReceta);
        void Update(MenuSemanalReceta menuSemanalReceta);
        void Delete(int idMenuSemanal, int idReceta, DateTime fecha);
    }
}