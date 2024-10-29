using RecetasRedondas.Models;
using System.Collections.Generic;

namespace RecetasRedondas.Business
{
    public interface IVotacionService
{
    void Votar(int usuarioId, int recetaId, int puntuacion);
    double ObtenerPromedio(int recetaId);
    List<Receta> ObtenerRecetasPopulares();
}

}