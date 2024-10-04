using RecetasRedondas.Models;
using System.Collections.Generic;

namespace RecetasRedondas.Business
{
    public interface IRecetaIngredienteService
    {
        List<RecetaIngrediente> GetAll();
        RecetaIngrediente GetById(int idRecetaIngrediente); // Cambiado
        void Add(RecetaIngrediente recetaIngrediente);
        void Update(RecetaIngrediente recetaIngrediente);
        void Delete(int idRecetaIngrediente); // Cambiado
        List<RecetaIngrediente> GetByReceta(int recetaId);
        List<RecetaIngrediente> GetByIngrediente(int ingredienteId);
    }
}
