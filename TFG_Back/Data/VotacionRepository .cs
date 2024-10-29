using Microsoft.EntityFrameworkCore;
using RecetasRedondas.Models;
using System.Text;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;

namespace RecetasRedondas.Data
{
    public class VotacionRepository : IVotacionRepository
{
    private readonly RecetasRedondasAppContext _context;

    public VotacionRepository(RecetasRedondasAppContext context)
    {
        _context = context;
    }

    public void RegistrarVotacion(int usuarioId, int recetaId, int puntuacion)
{
    var votacionExistente = _context.Votaciones
        .FirstOrDefault(v => v.UsuarioId == usuarioId && v.RecetaId == recetaId);

    if (votacionExistente != null)
    {
        votacionExistente.Puntuacion = puntuacion;
    }
    else
    {
        var nuevaVotacion = new Votacion
        {
            UsuarioId = usuarioId,
            RecetaId = recetaId,
            Puntuacion = puntuacion
        };
        _context.Votaciones.Add(nuevaVotacion);
    }

    // Guardar los cambios para que la nueva votación esté en la base de datos
    _context.SaveChanges();

    // Ahora actualizar el promedio de votos
    var promedio = ObtenerPromedioVotos(recetaId);
    var receta = _context.Recetas.First(r => r.IdReceta == recetaId);
    receta.PromedioVotos = (decimal)promedio;

    // Guardar los cambios de la receta actualizada
    _context.SaveChanges();
}

    public double ObtenerPromedioVotos(int recetaId)
    {
        var votos = _context.Votaciones
            .Where(v => v.RecetaId == recetaId)
            .Select(v => v.Puntuacion);

        if (votos.Any())
        {
            return votos.Average();
        }
        return 0;
    }

    public List<Receta> ObtenerRecetasMasPopulares()
    {
        return _context.Recetas
            .OrderByDescending(r => r.PromedioVotos)
            .Take(10)
            .ToList();
    }
}

}