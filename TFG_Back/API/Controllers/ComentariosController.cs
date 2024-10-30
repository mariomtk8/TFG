using Microsoft.AspNetCore.Mvc;
using RecetasRedondas.Models;
using RecetasRedondas.Data;
using RecetasRedondas.Business;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;

namespace RecetasRedondas.Controllers
{
    [ApiController]
[Route("[controller]")]
public class ComentariosController : ControllerBase
{
    private readonly IComentarioService _comentarioService;

    public ComentariosController(IComentarioService comentarioService)
    {
        _comentarioService = comentarioService;
    }
    [AllowAnonymous]
    [HttpPost]
    public IActionResult AgregarComentario(int usuarioId, int recetaId, string contenido)
    {
        _comentarioService.AgregarComentario(usuarioId, recetaId, contenido);
        return Ok(new { Message = "Comentario agregado exitosamente" });
    }

    [AllowAnonymous]
    [HttpGet("{recetaId}")]
    public ActionResult<List<ComentarioDto>> GetComentariosPorReceta(int recetaId)
    {
        var comentarios = _comentarioService.ObtenerComentariosPorReceta(recetaId);
        return Ok(comentarios);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{comentarioId}")]
        public IActionResult EliminarComentarioPorId(int comentarioId)
        {
            _comentarioService.EliminarComentarioPorId(comentarioId);
            return Ok("Comentario eliminado por el administrador.");
        }

        [AllowAnonymous]
        [HttpDelete("{comentarioId}/usuario/{usuarioId}")]
        public IActionResult EliminarComentarioPorUsuario(int comentarioId, int usuarioId)
        {
            
            _comentarioService.EliminarComentarioPorUsuario(comentarioId, usuarioId);
            return Ok("Comentario eliminado por el usuario.");
        }
}

}