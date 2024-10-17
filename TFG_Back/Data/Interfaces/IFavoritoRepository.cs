using RecetasRedondas.Models;
using System.Collections.Generic;

public interface IFavoritoRepository
{
    List<Favorito> GetFavoritosByUsuarioId(int usuarioId);
    Favorito GetFavorito(int usuarioId);
    void AddFavorito(FavoritoDTO favorito);
    void DeleteFavorito(int IdFavorito);
    bool FavoritoExists(int IdFavorito);
}
