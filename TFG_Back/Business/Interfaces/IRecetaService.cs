using RecetasRedondas.Models;
using System.Collections.Generic;

namespace RecetasRedondas.Business
{
    public interface IRecetaService
    {
        List<RecetaDTO> GetAll();
        RecetaDTO Get(int id);
        List<Receta> GetByCategoria(int idCategoria);
        void Add(Receta receta);
        void Update(Receta receta);
        void Delete(int id);
        IEnumerable<DatosPasoDTO> GetPasosByRecetaId(int recetaId);
        void AddPaso(int recetaId, DatosPasoDTO paso);
        void UpdatePaso(int recetaId, DatosPasoDTO paso);
        void DeletePaso( int pasoId);
    }
}
