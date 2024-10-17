using RecetasRedondas.Models;
using System.Collections.Generic;

public interface IFavoritoService
{
    List<Favorito> GetFavoritosByUsuarioId(int usuarioId);
    void AddFavorito(FavoritoDTO favorito);
    void DeleteFavorito(int IdFavorito);
}
