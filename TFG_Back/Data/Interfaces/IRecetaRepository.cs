using RecetasRedondas.Models;
using System.Collections.Generic;

namespace RecetasRedondas.Data
{
    public interface IRecetaRepository
    {
        List<RecetaDTO> GetAll();
        List<Receta> GetBySearch(string searchTerm);
        RecetaDTO Get(int id);
        List<Receta> GetByCategoria(int idCategoria);
        void Add(Receta receta);
        void Update(RecetaUpdateDTO receta);
        void Delete(int id);
        IEnumerable<DatosPasoDTO> GetPasosByRecetaId(int recetaId);
        void AddPaso(int recetaId, DatosPasoDTO paso);
        void UpdatePaso(int recetaId, DatosPasoDTO paso);
        void DeletePaso( int pasoId);
        List<RecetasMDTO> FiltrarRecetasPorAlergenos(int usuarioId);
        List<RecetasMDTO> FiltrarRecetasPorCategorias(int usuarioId);




    }
}
