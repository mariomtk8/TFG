using RecetasRedondas.Models;
using System.Collections.Generic;

namespace RecetasRedondas.Business
{
    public interface IRecetaIngredienteService
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
