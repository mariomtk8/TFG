using RecetasRedondas.Models;
using System.Collections.Generic;

namespace RecetasRedondas.Data
{
    public interface ICategoriaRepository
    {
        List<Categoria> GetAll();
        Categoria Get(int id);
        void Add(Categoria categoria);
        void Update(Categoria categoria);
        void Delete(int id);
        List<Categoria> Search(string query);
    }
}
