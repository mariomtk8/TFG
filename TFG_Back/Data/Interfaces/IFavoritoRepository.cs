using RecetasRedondas.Models;
using System.Collections.Generic;

public interface IFavoritoRepository
{
    List<Favorito> GetFavoritosByUsuarioId(int usuarioId);
    Favorito GetFavorito(int usuarioId);
    void AddFavorito(FavoritoDTO favorito);
    void DeleteFavorito(Favorito favorito);
    bool FavoritoExists(int IdFavorito);
}
