using RecetasRedondas.Models;
using System.Collections.Generic;

namespace RecetasRedondas.Data
{
    public interface IVotacionRepository
{
    void RegistrarVotacion(int usuarioId, int recetaId, int puntuacion);
    double ObtenerPromedioVotos(int recetaId);
    List<Receta> ObtenerRecetasMasPopulares();
}

}