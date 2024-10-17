using Microsoft.EntityFrameworkCore;
using RecetasRedondas.Data;
using RecetasRedondas.Models;
using System.Collections.Generic;
using System.Linq;

public class FavoritoRepository : IFavoritoRepository
{
    private readonly RecetasRedondasAppContext _context;

    public FavoritoRepository(RecetasRedondasAppContext context)
    {
        _context = context;
    }

    public List<Favorito> GetFavoritosByUsuarioId(int usuarioId)
    {
        return _context.Favoritos
            .Include(f => f.Receta)
            .Where(f => f.IdUsuario == usuarioId)
            .ToList();
    }

    public Favorito GetFavorito(int usuarioId)
    {
        return _context.Favoritos
            .FirstOrDefault(f => f.IdUsuario == usuarioId);
    }

    public void AddFavorito(FavoritoDTO favorito)
{
    // Verifica si el usuario ya tiene esta receta como favorita
    var exists = _context.Favoritos
        .Any(f => f.IdUsuario == favorito.IdUsuario && f.IdReceta == favorito.IdReceta);

    if (!exists)
    {
        var newFav = new Favorito
        {
            IdUsuario = favorito.IdUsuario,
            IdReceta = favorito.IdReceta
        };

        _context.Favoritos.Add(newFav);
        _context.SaveChanges();
    }
    else
    {
        // Si el favorito ya existe, podrías lanzar una excepción o simplemente retornar sin hacer nada
        // Esto dependerá de la lógica de negocio que desees implementar.
        throw new Exception("Este favorito ya existe.");
    }
}


    public void DeleteFavorito(int favoritoId)
    {
        var favorito = _context.Favoritos.Find(favoritoId);
            if (favorito != null)
            {
                _context.Favoritos.Remove(favorito);
                _context.SaveChanges();
            }
    }

    public bool FavoritoExists(int IdFavorito)
    {
        return _context.Favoritos.Any(f => f.IdFavorito == IdFavorito);
    }
}
