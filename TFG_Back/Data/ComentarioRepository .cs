using Microsoft.EntityFrameworkCore;
using RecetasRedondas.Models;
using System.Text;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;

namespace RecetasRedondas.Data
{
    public class ComentarioRepository : IComentarioRepository
{
    private readonly RecetasRedondasAppContext _context;

    public ComentarioRepository(RecetasRedondasAppContext context)
    {
        _context = context;
    }

    public void AgregarComentario(Comentario comentario)
    {
        _context.Comentarios.Add(comentario);
        _context.SaveChanges();
    }

    public List<Comentario> ObtenerComentariosPorReceta(int recetaId)
    {
        return _context.Comentarios
            .Where(c => c.RecetaId == recetaId)
            .ToList();
    }
}

}