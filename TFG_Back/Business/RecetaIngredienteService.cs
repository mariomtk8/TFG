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

        public RecetaIngrediente Get(int idReceta, int idIngrediente) => _recetaIngredienteRepository.Get(idReceta, idIngrediente);

        public void Add(RecetaIngrediente recetaIngrediente) => _recetaIngredienteRepository.Add(recetaIngrediente);

        public void Update(RecetaIngrediente recetaIngrediente) => _recetaIngredienteRepository.Update(recetaIngrediente);

        public void Delete(int idReceta, int idIngrediente) => _recetaIngredienteRepository.Delete(idReceta, idIngrediente);

        public List<RecetaIngrediente> GetByReceta(int recetaId) => _recetaIngredienteRepository.GetByReceta(recetaId);

        public List<RecetaIngrediente> GetByIngrediente(int ingredienteId) => _recetaIngredienteRepository.GetByIngrediente(ingredienteId);
    }
}
