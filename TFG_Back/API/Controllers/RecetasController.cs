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

        [AllowAnonymous]
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
        public ActionResult Update(int id, [FromBody] Receta receta)
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
    }
}
