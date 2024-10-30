using RecetasRedondas.Models;
using System.Collections.Generic;

namespace RecetasRedondas.Data
{
    public interface IComentarioRepository
{
    void AgregarComentario(Comentario comentario);
    List<ComentarioDto> ObtenerComentariosPorReceta(int recetaId);
    void EliminarComentarioPorId(int comentarioId);
    void EliminarComentarioPorUsuario(int comentarioId, int usuarioId);
}

}