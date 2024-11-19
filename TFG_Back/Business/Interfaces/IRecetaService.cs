using RecetasRedondas.Models;
using System.Collections.Generic;

namespace RecetasRedondas.Business
{
    public interface IRecetaService
    {
        List<RecetaDTO> GetAll();
        List<Receta> SearchRecetas(string searchTerm);
        RecetaDTO Get(int id);
        List<Receta> GetByCategoria(int idCategoria);
        void Add(Receta receta);
        void Update(RecetaUpdateDTO receta);
        void Delete(int id);
        IEnumerable<DatosPasoDTO> GetPasosByRecetaId(int recetaId);
        void AddPaso(int recetaId, DatosPasoDTO paso);
        void UpdatePaso(int recetaId, DatosPasoDTO paso);
        void DeletePaso( int pasoId);
        List<RecetasMDTO> FiltrarRecetas(int usuarioId);
        List<Receta> FiltrarPorNivelDificultad( bool ascendente);
        List<Receta> FiltrarPorTiempoPreparacion( bool ascendente);
        List<Receta> FiltrarPorTemaCocina(string temaCocina);

    }
}
