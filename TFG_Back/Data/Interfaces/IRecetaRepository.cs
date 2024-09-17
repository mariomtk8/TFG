using RecetasRedondas.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecetasRedondas.Data
{
    public interface IRecetaRepository
    {
        List<Receta> GetAll();
        Receta Get(int id);
        List<Receta> GetByCategoria(int idCategoria);
        void Add(Receta receta);
        void Update(Receta receta);
        void Delete(int id);
    }

}
