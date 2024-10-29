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
public class VotacionesController : ControllerBase
{
    private readonly IVotacionService _votacionService;

    public VotacionesController(IVotacionService votacionService)
    {
        _votacionService = votacionService;
    }

    [HttpPost]
    public IActionResult Votar(int usuarioId, int recetaId, int puntuacion)
    {
        _votacionService.Votar(usuarioId, recetaId, puntuacion);
        return Ok(new { Message = "Votación registrada exitosamente" });
    }

    [HttpGet("promedio/{recetaId}")]
    public IActionResult ObtenerPromedio(int recetaId)
    {
        var promedio = _votacionService.ObtenerPromedio(recetaId);
        return Ok(promedio);
    }

    [HttpGet("populares")]
    public IActionResult ObtenerRecetasPopulares()
    {
        var populares = _votacionService.ObtenerRecetasPopulares();
        return Ok(populares);
    }
}

}