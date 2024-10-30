using Microsoft.EntityFrameworkCore;
using RecetasRedondas.Models;
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

        public List<ComentarioDto> ObtenerComentariosPorReceta(int recetaId)
        {
            return _context.Comentarios
                .Include(c => c.Usuario)
                .Where(c => c.RecetaId == recetaId)
                .Select(c => new ComentarioDto
                {
                    Id = c.Id,
                    UsuarioId = c.UsuarioId,
                    Contenido = c.Contenido,
                    Fecha = c.Fecha,
                    NombreUsuario = c.Usuario.Nombre 
                })
                .ToList();
        }


        public void EliminarComentarioPorId(int comentarioId)
        {
            var comentario = _context.Comentarios.Find(comentarioId);
            if (comentario != null)
            {
                _context.Comentarios.Remove(comentario);
                _context.SaveChanges();
            }
        }

        public void EliminarComentarioPorUsuario(int comentarioId, int usuarioId)
        {
            var comentario = _context.Comentarios
                .FirstOrDefault(c => c.Id == comentarioId && c.UsuarioId == usuarioId);

            if (comentario != null)
            {
                _context.Comentarios.Remove(comentario);
                _context.SaveChanges();
            }
        }
    }
}
