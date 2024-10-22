using Microsoft.AspNetCore.Mvc;
using RecetasRedondas.Data;
using RecetasRedondas.Models;
using RecetasRedondas.Services;
using System.Collections.Generic;

namespace RecetasRedondas.Controllers
{
    [ApiController]
[Route("[controller]")]
public class MenuSemanalController : ControllerBase
{
    private readonly IMenuSemanalService _menuSemanalService;

    public MenuSemanalController(IMenuSemanalService menuSemanalService)
    {
        _menuSemanalService = menuSemanalService;
    }

    [HttpPost]
    public IActionResult CrearMenuSemanal([FromBody] MenuSemanal menuSemanal)
    {
        _menuSemanalService.CrearMenuSemanal(menuSemanal);
        return CreatedAtAction(nameof(ObtenerMenuSemanalPorUsuario), new { usuarioId = menuSemanal.IdUsuario }, menuSemanal);
    }

    [HttpGet("{usuarioId}")]
    public IActionResult ObtenerMenuSemanalPorUsuario(int usuarioId)
    {
        var menuSemanal = _menuSemanalService.ObtenerMenuSemanalPorUsuario(usuarioId);
        if (menuSemanal == null)
        {
            return NotFound();
        }
        return Ok(menuSemanal);
    }

    [HttpPut("{id}")]
    public IActionResult ActualizarMenuSemanal(int id, [FromBody] MenuSemanal menuSemanal)
    {
        if (menuSemanal.IdMenuSemanal != id)
        {
            return BadRequest("El ID del menú semanal no coincide.");
        }

        _menuSemanalService.ActualizarMenuSemanal(menuSemanal);
        return NoContent(); // Devuelve 204 No Content para la actualización exitosa.
    }
}

}