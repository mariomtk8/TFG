using RecetasRedondas.Models;
using System.Collections.Generic;

namespace RecetasRedondas.Business
{
    public interface IIngredienteService
    {
        List<Ingrediente> GetAll();
        Ingrediente Get(int id);
        void Add(Ingrediente ingrediente);
        void Update(Ingrediente ingrediente);
        void Delete(int id);
    }
}
