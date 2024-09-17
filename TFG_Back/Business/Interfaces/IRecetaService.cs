using RecetasRedondas.Models;
using System.Collections.Generic;

namespace RecetasRedondas.Business
{
    public interface IRecetaService
    {
        List<Receta> GetAll();
        Receta Get(int id);
        List<Receta> GetByCategoria(int idCategoria);
        void Add(Receta receta);
        void Update(Receta receta);
        void Delete(int id);
    }
}
