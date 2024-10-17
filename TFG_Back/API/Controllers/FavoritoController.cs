using Microsoft.AspNetCore.Mvc;
using RecetasRedondas.Models;
using System.Collections.Generic;

[Route("[controller]")]
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
    try
    {
        _favoritoService.AddFavorito(favorito);
        return Ok();
    }
    catch (Exception ex)
    {
        return BadRequest(new { message = ex.Message });
    }
}

    [HttpDelete("/Favorito/{favoritoId}")]
    public ActionResult DeleteFavorito(int favoritoId)
        {
            _favoritoService.DeleteFavorito(favoritoId);
            return NoContent();
        }
}
