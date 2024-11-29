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

        public async Task<(List<Receta> Recetas, int TotalRecetas, int TotalPaginas)> GetRecetasPaginadasAsync(int page, int pageSize)
        {
            var (recetas, totalRecetas) = await _recetaRepository.GetRecetasPaginadasAsync(page, pageSize);
            int totalPaginas = (int)Math.Ceiling(totalRecetas / (double)pageSize);

            return (recetas, totalRecetas, totalPaginas);
        }
        
        public List<Receta> SearchRecetas(string searchTerm) =>  _recetaRepository.GetBySearch(searchTerm);
        
        public RecetaDTO Get(int id) => _recetaRepository.Get(id);

        public List<Receta> GetByCategoria(int idCategoria) => _recetaRepository.GetByCategoria(idCategoria);

        public void Update(RecetaUpdateDTO receta) => _recetaRepository.Update(receta);

        public void Add(Receta receta) => _recetaRepository.Add(receta);

        public void Delete(int id) => _recetaRepository.Delete(id);
        public IEnumerable<DatosPasoDTO> GetPasosByRecetaId(int recetaId) => _recetaRepository.GetPasosByRecetaId(recetaId);

        public void AddPaso(int recetaId, DatosPasoDTO paso) => _recetaRepository.AddPaso(recetaId, paso);

        public void UpdatePaso(int recetaId, DatosPasoDTO paso) => _recetaRepository.UpdatePaso(recetaId, paso);

        public void DeletePaso( int pasoId) => _recetaRepository.DeletePaso(pasoId);
        public List<RecetasMDTO> FiltrarRecetas(int usuarioId) => _recetaRepository.FiltrarRecetas(usuarioId);
        public List<Receta> FiltrarPorNivelDificultad( bool ascendente) => _recetaRepository.FiltrarPorNivelDificultad( ascendente);
        public List<Receta> FiltrarPorTiempoPreparacion( bool ascendente) => _recetaRepository.FiltrarPorTiempoPreparacion( ascendente);
        public List<Receta> FiltrarPorTemaCocina(string temaCocina) => _recetaRepository.FiltrarPorTemaCocina(temaCocina);
      
    

    }
}
