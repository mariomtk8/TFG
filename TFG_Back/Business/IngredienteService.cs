using RecetasRedondas.Data;
using RecetasRedondas.Models;
using System.Collections.Generic;

namespace RecetasRedondas.Business
{
    public class IngredienteService : IIngredienteService
    {
        private readonly IIngredienteRepository _ingredienteRepository;

        public IngredienteService(IIngredienteRepository ingredienteRepository)
        {
            _ingredienteRepository = ingredienteRepository;
        }

        public List<Ingrediente> GetAll() => _ingredienteRepository.GetAll();

        public Ingrediente Get(int id) => _ingredienteRepository.Get(id);

        public void Update(Ingrediente ingrediente) => _ingredienteRepository.Update(ingrediente);

        public void Add(Ingrediente ingrediente) => _ingredienteRepository.Add(ingrediente);

        public void Delete(int id) => _ingredienteRepository.Delete(id);
        public List<Ingrediente> Search(string query) => _ingredienteRepository.Search(query); // Método de búsqueda

        
    }
}
