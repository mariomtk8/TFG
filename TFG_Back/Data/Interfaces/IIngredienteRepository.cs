using RecetasRedondas.Models;
using System.Collections.Generic;

namespace RecetasRedondas.Data
{
    public interface IIngredienteRepository
    {
        List<Ingrediente> GetAll();
        Ingrediente Get(int id);
        void Add(Ingrediente ingrediente);
        void Update(Ingrediente ingrediente);
        void Delete(int id);
    }
}
