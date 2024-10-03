using RecetasRedondas.Data;
using RecetasRedondas.Models;
using System.Collections.Generic;

namespace RecetasRedondas.Business
{
    public class RecetaService : IRecetaService
    {
        private readonly IRecetaRepository _recetaRepository;

        public RecetaService(IRecetaRepository recetaRepository)
        {
            _recetaRepository = recetaRepository;
        }

        public List<RecetaDTO> GetAll() => _recetaRepository.GetAll();

        public RecetaDTO Get(int id) => _recetaRepository.Get(id);

        public List<Receta> GetByCategoria(int idCategoria) => _recetaRepository.GetByCategoria(idCategoria);

        public void Update(Receta receta) => _recetaRepository.Update(receta);

        public void Add(Receta receta) => _recetaRepository.Add(receta);

        public void Delete(int id) => _recetaRepository.Delete(id);
        public IEnumerable<DatosPasoDTO> GetPasosByRecetaId(int recetaId) => _recetaRepository.GetPasosByRecetaId(recetaId);

        public void AddPaso(int recetaId, DatosPasoDTO paso) => _recetaRepository.AddPaso(recetaId, paso);

        public void UpdatePaso(int recetaId, DatosPasoDTO paso) => _recetaRepository.UpdatePaso(recetaId, paso);

        public void DeletePaso( int pasoId) => _recetaRepository.DeletePaso(pasoId);
    }
}
