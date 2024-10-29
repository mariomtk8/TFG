using RecetasRedondas.Data;
using RecetasRedondas.Models;
using System.Collections.Generic;

namespace RecetasRedondas.Business
{
    public class VotacionService : IVotacionService
{
    private readonly IVotacionRepository _votacionRepository;

    public VotacionService(IVotacionRepository votacionRepository)
    {
        _votacionRepository = votacionRepository;
    }

    public void Votar(int usuarioId, int recetaId, int puntuacion)
    {
        _votacionRepository.RegistrarVotacion(usuarioId, recetaId, puntuacion);
    }

    public double ObtenerPromedio(int recetaId)
    {
        return _votacionRepository.ObtenerPromedioVotos(recetaId);
    }

    public List<Receta> ObtenerRecetasPopulares()
    {
        return _votacionRepository.ObtenerRecetasMasPopulares();
    }
}

}