using Microsoft.AspNetCore.Mvc;
using RecetasRedondas.Models;
using RecetasRedondas.Services;
using System.Collections.Generic;

namespace RecetasRedondas.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MenuSemanalController : ControllerBase
    {
        private readonly IMenuSemanalService _menuSemanalService;

        public MenuSemanalController(IMenuSemanalService menuSemanalService)
        {
            _menuSemanalService = menuSemanalService;
        }

        // POST: MenuSemanal
        [HttpPost("{usuarioId}")]
        public IActionResult CrearMenuSemanal(int usuarioId)
        {
            var menu = _menuSemanalService.GenerarMenuSemana(usuarioId);
            _menuSemanalService.CrearMenuSemanal(menu);
            return Ok(menu);
        }

        // GET: api/MenuSemanal/usuario/{usuarioId}
        [HttpGet("usuario/{usuarioId}")]
        public IActionResult GetMenuSemanalByUsuario(int usuarioId)
        {
            var menuSemanal = _menuSemanalService.GetMenuSemanalByUsuario(usuarioId);
            if (menuSemanal == null || menuSemanal.Count == 0)
            {
                return NotFound("No se encontraron menús para el usuario.");
            }
            return Ok(menuSemanal);
        }

        // PUT: /MenuSemanal/usuario/{usuarioId}
        [HttpPut("usuario/{usuarioId}")]
        public IActionResult RegenerarMenuSemanal(int usuarioId)
        {
            _menuSemanalService.RegenerarMenuSemanal(usuarioId);
            return Ok("Menú semanal regenerado correctamente.");
        }

        // DELETE: MenuSemanal/{idMenuSemanal}
        [HttpDelete("{idMenuSemanal}")]
        public IActionResult DeleteMenuSemanal(int idMenuSemanal)
        {
            _menuSemanalService.DeleteMenuSemanal(idMenuSemanal);
            return Ok("Menú semanal eliminado correctamente.");
        }
    }
}
