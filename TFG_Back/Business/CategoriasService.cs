using RecetasRedondas.Data;
using RecetasRedondas.Models;
using System.Collections.Generic;

namespace RecetasRedondas.Business
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public List<Categoria> GetAll() => _categoriaRepository.GetAll();

        public Categoria Get(int id) => _categoriaRepository.Get(id);

        public void Update(Categoria categoria) => _categoriaRepository.Update(categoria);

        public void Add(Categoria categoria) => _categoriaRepository.Add(categoria);

        public void Delete(int id) => _categoriaRepository.Delete(id);
    }
}
