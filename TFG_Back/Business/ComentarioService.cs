using RecetasRedondas.Data;
using RecetasRedondas.Models;
using System.Collections.Generic;

namespace RecetasRedondas.Business
{
    public class ComentarioService : IComentarioService
{
    private readonly IComentarioRepository _comentarioRepository;

    public ComentarioService(IComentarioRepository comentarioRepository)
    {
        _comentarioRepository = comentarioRepository;
    }

    public void AgregarComentario(int usuarioId, int recetaId, string contenido)
    {
        var comentario = new Comentario
        {
            UsuarioId = usuarioId,
            RecetaId = recetaId,
            Contenido = contenido,
            Fecha = DateTime.Now
        };
        _comentarioRepository.AgregarComentario(comentario);
    }

    public List<ComentarioDto> ObtenerComentariosPorReceta(int recetaId)
    {
        return _comentarioRepository.ObtenerComentariosPorReceta(recetaId);
    }
    public void EliminarComentarioPorId(int comentarioId)
        {
            _comentarioRepository.EliminarComentarioPorId(comentarioId);
        }

        public void EliminarComentarioPorUsuario(int comentarioId, int usuarioId)
        {
            _comentarioRepository.EliminarComentarioPorUsuario(comentarioId, usuarioId);
        }
}

}