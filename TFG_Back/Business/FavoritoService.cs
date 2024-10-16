using RecetasRedondas.Models;
using System.Collections.Generic;

public class FavoritoService : IFavoritoService
{
    private readonly IFavoritoRepository _favoritoRepository;

    public FavoritoService(IFavoritoRepository favoritoRepository)
    {
        _favoritoRepository = favoritoRepository;
    }

    public List<Favorito> GetFavoritosByUsuarioId(int usuarioId)
    {
        return _favoritoRepository.GetFavoritosByUsuarioId(usuarioId);
    }

    public void AddFavorito(FavoritoDTO favorito)
    {
        if (!_favoritoRepository.FavoritoExists(favorito.IdUsuario))
        {
            _favoritoRepository.AddFavorito(favorito);
        }
    }

    public void DeleteFavorito(int favoritoId)
    {
        var favorito = _favoritoRepository.GetFavorito(favoritoId);
        if (favorito != null)
        {
            _favoritoRepository.DeleteFavorito(favorito);
        }
    }
}
