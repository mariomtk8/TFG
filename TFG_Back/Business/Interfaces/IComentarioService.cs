using RecetasRedondas.Models;
using System.Collections.Generic;

namespace RecetasRedondas.Business
{
    public interface IComentarioService
{
    void AgregarComentario(int usuarioId, int recetaId, string contenido);
    List<Comentario> ObtenerComentarios(int recetaId);
}

}