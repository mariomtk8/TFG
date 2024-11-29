using Microsoft.AspNetCore.Mvc;
using RecetasRedondas.Business;
using RecetasRedondas.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace RecetasRedondas.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RecetaController : ControllerBase
    {
        private readonly IRecetaService _recetaService;

        public RecetaController(IRecetaService recetaService)
        {
            _recetaService = recetaService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetRecetas(int page = 1, int pageSize = 10)
        {
            var (recetas, totalRecetas, totalPaginas) = await _recetaService.GetRecetasPaginadasAsync(page, pageSize);

            var response = new
            {
                TotalRecetas = totalRecetas,
                PaginaActual = page,
                TotalPaginas = totalPaginas,
                Recetas = recetas
            };

            return Ok(response);
        }
        
        [AllowAnonymous]
        [HttpGet("search")]
        public ActionResult<List<Receta>> SearchRecetas(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return BadRequest("El término de búsqueda no puede estar vacío.");
            }

            var recetas = _recetaService.SearchRecetas(searchTerm);
            return Ok(recetas);
        }


        [AllowAnonymous]
        [HttpGet("{id}")]
        public ActionResult<RecetaDTO> Get(int id)
        {
            var receta = _recetaService.Get(id);
            if (receta == null)
            {
                return NotFound();
            }
            return Ok(receta);
        }

        [AllowAnonymous]
        [HttpGet("categoria/{idCategoria}")]
        public ActionResult<List<Receta>> GetByCategoria(int idCategoria)
        {
            var recetas = _recetaService.GetByCategoria(idCategoria);
            if (recetas == null || recetas.Count == 0)
            {
                return NotFound();
            }
            return Ok(recetas);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Add([FromBody] Receta receta)
        {
            _recetaService.Add(receta);
            return CreatedAtAction(nameof(Get), new { id = receta.IdReceta }, receta);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] RecetaUpdateDTO receta)
        {
            if (id != receta.IdReceta)
            {
                return BadRequest();
            }

            _recetaService.Update(receta);
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _recetaService.Delete(id);
            return NoContent();
        }

        [HttpGet("{recetaId}/Pasos")]
        public IActionResult GetPasosByRecetaId(int recetaId)
        {
            var pasos = _recetaService.GetPasosByRecetaId(recetaId);
            return Ok(pasos);
        }

        // Obtener un paso específico por ID

        [HttpPost("{recetaId}/paso")]
        public IActionResult AddPaso(int recetaId, [FromBody] DatosPasoDTO paso)
        {
            if (paso == null)
            {
                return BadRequest("Paso cannot be null.");
            }

            _recetaService.AddPaso(recetaId, paso);
            return Ok(paso);
        }

        [HttpPut("{recetaId}/paso")]
        public IActionResult UpdatePaso(int recetaId, [FromBody] DatosPasoDTO paso)
        {
            if (paso == null)
            {
                return BadRequest("Paso cannot be null.");
            }

            _recetaService.UpdatePaso(recetaId, paso);
            return NoContent();
        }

        [HttpDelete("/Paso/{pasoId}")]
        public IActionResult DeletePaso(int pasoId)
        {
            _recetaService.DeletePaso(pasoId);
            return NoContent();
        }

        [HttpGet("FiltrarRecetas/{usuarioId}")]
    public async Task<ActionResult<List<RecetasMDTO>>> FiltrarRecetas(int usuarioId)
    {
        try
        {
            var recetas = _recetaService.FiltrarRecetas(usuarioId);
            return Ok(recetas);
        }
        catch (Exception ex)
        {
            return BadRequest($"Error al filtrar las recetas: {ex.Message}");
        }
    }

        [HttpGet("filtrarPorNivelDificultad")]
        public ActionResult<List<Receta>> FiltrarPorNivelDificultad( [FromQuery] bool ascendente = true)
        {
            var recetas = _recetaService.FiltrarPorNivelDificultad( ascendente);
            return Ok(recetas);
        }

        [HttpGet("filtrarPorTiempoPreparacion")]
        public ActionResult<List<Receta>> FiltrarPorTiempoPreparacion( [FromQuery] bool ascendente = true)
        {
            var recetas = _recetaService.FiltrarPorTiempoPreparacion( ascendente);
            return Ok(recetas);
        }
        [HttpGet("filtrarPorTemaCocina")]
        public ActionResult<List<Receta>> FiltrarPorTemaCocina([FromQuery] string temaCocina)
        {
            var recetas = _recetaService.FiltrarPorTemaCocina(temaCocina);
            return Ok(recetas);
        }

    }
}
