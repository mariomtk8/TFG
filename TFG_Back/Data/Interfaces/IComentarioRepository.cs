using RecetasRedondas.Models;
using System.Collections.Generic;

namespace RecetasRedondas.Data
{
    public interface IComentarioRepository
{
    void AgregarComentario(Comentario comentario);
    List<Comentario> ObtenerComentariosPorReceta(int recetaId);
}

}