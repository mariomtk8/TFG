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
        var newFav = new Favorito
        {
            IdUsuario = favorito.IdUsuario,
            IdReceta = favorito.IdReceta
        };


        _context.Favoritos.Add(newFav);
        _context.SaveChanges();
    }

    public void DeleteFavorito(Favorito favorito)
    {
        _context.Favoritos.Remove(favorito);
        _context.SaveChanges();
    }

    public bool FavoritoExists(int IdFavorito)
    {
        return _context.Favoritos.Any(f => f.IdFavorito == IdFavorito);
    }
}
