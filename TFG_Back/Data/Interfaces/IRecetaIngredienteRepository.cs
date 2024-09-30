using RecetasRedondas.Models;
using System.Collections.Generic;

namespace RecetasRedondas.Data
{
    public interface IRecetaIngredienteRepository
    {
        List<RecetaIngrediente> GetAll();
        RecetaIngrediente Get(int idReceta, int idIngrediente);
        void Add(RecetaIngrediente recetaIngrediente);
        void Update(RecetaIngrediente recetaIngrediente);
        void Delete(int idReceta, int idIngrediente);
        List<RecetaIngrediente> GetByReceta(int recetaId);
        List<RecetaIngrediente> GetByIngrediente(int ingredienteId);
    }
}
