using Microsoft.AspNetCore.Mvc;
using RecetasRedondas.Business;
using RecetasRedondas.Models;
using System.Collections.Generic;

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

        [HttpGet]
        public ActionResult<List<Receta>> GetAll()
        {
            try
            {
                return Ok(_recetaService.GetAll());
            }
            catch (Exception er)
            {
                
                return StatusCode(500, new {message = er});
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Receta> Get(int id)
        {
            var receta = _recetaService.Get(id);
            if (receta == null)
            {
                return NotFound();
            }
            return Ok(receta);
        }

        // Nuevo endpoint para obtener recetas por idCategoria
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

        [HttpPost]
        public ActionResult Add([FromBody] Receta receta)
        {
            _recetaService.Add(receta);
            return CreatedAtAction(nameof(Get), new { id = receta.IdReceta }, receta);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] Receta receta)
        {
            if (id != receta.IdReceta)
            {
                return BadRequest();
            }

            _recetaService.Update(receta);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _recetaService.Delete(id);
            return NoContent();
        }
    }
}
