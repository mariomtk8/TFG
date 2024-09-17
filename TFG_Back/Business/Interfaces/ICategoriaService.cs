using RecetasRedondas.Models;
using System.Collections.Generic;

namespace RecetasRedondas.Business
{
    public interface ICategoriaService
    {
        List<Categoria> GetAll();
        Categoria Get(int id);
        void Add(Categoria categoria);
        void Update(Categoria categoria);
        void Delete(int id);
    }
}
