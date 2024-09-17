using RecetasRedondas.Data;
using RecetasRedondas.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecetasRedondas.Business
{
    public class RecetaService : IRecetaService
    {
        private readonly IRecetaRepository _recetaRepository;

        public RecetaService(IRecetaRepository recetaRepository)
        {
            _recetaRepository = recetaRepository;
        }

        public List<Receta> GetAll() => _recetaRepository.GetAll();

        public Receta Get(int id) => _recetaRepository.Get(id);

        public List<Receta> GetByCategoria(int idCategoria) => _recetaRepository.GetByCategoria(idCategoria);

        public void Update(Receta receta) => _recetaRepository.Update(receta);

        public void Add(Receta receta) => _recetaRepository.Add(receta);

        public void Delete(int id) => _recetaRepository.Delete(id);
    }
}
