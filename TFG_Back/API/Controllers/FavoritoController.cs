using Microsoft.AspNetCore.Mvc;
using RecetasRedondas.Models;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class FavoritoController : ControllerBase
{
    private readonly IFavoritoService _favoritoService;

    public FavoritoController(IFavoritoService favoritoService)
    {
        _favoritoService = favoritoService;
    }

    [HttpGet("usuario/{usuarioId}")]
    public ActionResult<List<Favorito>> GetFavoritosByUsuarioId(int usuarioId)
    {
        var favoritos = _favoritoService.GetFavoritosByUsuarioId(usuarioId);
        return Ok(favoritos);
    }

    
    [HttpPost]
    public ActionResult AddFavorito([FromBody] FavoritoDTO favorito)
    {
        _favoritoService.AddFavorito(favorito);
        return Ok();
    }

    [HttpDelete]
    public ActionResult DeleteFavorito(int favorito)
    {
        _favoritoService.DeleteFavorito(favorito);
        return NoContent();
    }
}
