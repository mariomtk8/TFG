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

    [HttpPost]
    public IActionResult AgregarComentario(int usuarioId, int recetaId, string contenido)
    {
        _comentarioService.AgregarComentario(usuarioId, recetaId, contenido);
        return Ok(new { Message = "Comentario agregado exitosamente" });
    }

    [HttpGet("{recetaId}")]
    public IActionResult ObtenerComentarios(int recetaId)
    {
        var comentarios = _comentarioService.ObtenerComentarios(recetaId);
        return Ok(comentarios);
    }
}

}