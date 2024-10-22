using Microsoft.AspNetCore.Mvc;
using RecetasRedondas.Models;
using RecetasRedondas.Services;
using System.Collections.Generic;

namespace RecetasRedondas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DiaMenuController : ControllerBase
    {
        private readonly IDiaMenuService _diaMenuService;

        public DiaMenuController(IDiaMenuService diaMenuService)
        {
            _diaMenuService = diaMenuService;
        }

        [HttpPost("CrearMenuDiario/{usuarioId}")]
        public IActionResult CrearMenuDiario(int usuarioId)
        {
            _diaMenuService.CrearMenuDiario(usuarioId);
            return Ok("Menú diario creado con éxito.");
        }

        [HttpGet]
        public ActionResult<List<DiaMenu>> ObtenerMenuDiario()
        {
            var menuDiario = _diaMenuService.ObtenerMenuDiario();
            return Ok(menuDiario);
        }
    }
}
