using RecetasRedondas.Data;
using RecetasRedondas.Models;
using System.Collections.Generic;

namespace RecetasRedondas.Business
{
    public class RecetaIngredienteService : IRecetaIngredienteService
    {
        private readonly IRecetaIngredienteRepository _recetaIngredienteRepository;

        public RecetaIngredienteService(IRecetaIngredienteRepository recetaIngredienteRepository)
        {
            _recetaIngredienteRepository = recetaIngredienteRepository;
        }

        public List<RecetaIngrediente> GetAll() => _recetaIngredienteRepository.GetAll();

        public RecetaIngrediente GetById(int idRecetaIngrediente) => _recetaIngredienteRepository.GetById(idRecetaIngrediente);

        public void Add(RecetaIngrediente recetaIngrediente) => _recetaIngredienteRepository.Add(recetaIngrediente);

        public void Update(RecetaIngrediente recetaIngrediente) => _recetaIngredienteRepository.Update(recetaIngrediente);

        public void Delete(int idRecetaIngrediente) => _recetaIngredienteRepository.Delete(idRecetaIngrediente);

        public List<RecetaIngrediente> GetByReceta(int recetaId) => _recetaIngredienteRepository.GetByReceta(recetaId);

        public List<RecetaIngrediente> GetByIngrediente(int ingredienteId) => _recetaIngredienteRepository.GetByIngrediente(ingredienteId);
    }
}
