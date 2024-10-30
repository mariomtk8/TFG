using RecetasRedondas.Models;
using System.Collections.Generic;

namespace RecetasRedondas.Business
{
    public interface IComentarioService
{
    void AgregarComentario(int usuarioId, int recetaId, string contenido);
    List<ComentarioDto> ObtenerComentariosPorReceta(int recetaId);
    void EliminarComentarioPorId(int comentarioId);
    void EliminarComentarioPorUsuario(int comentarioId, int usuarioId);
}

}