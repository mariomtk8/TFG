using Microsoft.AspNetCore.Mvc;
using RecetasRedondas.Business;
using RecetasRedondas.Models;
using System.Collections.Generic;

namespace RecetasRedondas.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RecetaIngredientesController : ControllerBase
    {
        private readonly IRecetaIngredienteService _recetaIngredienteService;

        public RecetaIngredientesController(IRecetaIngredienteService recetaIngredienteService)
        {
            _recetaIngredienteService = recetaIngredienteService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RecetaIngrediente>> Get()
        {
            return _recetaIngredienteService.GetAll();
        }

        [HttpGet("{idReceta}/{idIngrediente}")]
        public ActionResult<RecetaIngrediente> Get(int idReceta, int idIngrediente)
        {
            return _recetaIngredienteService.Get(idReceta, idIngrediente);
        }

        [HttpGet("receta/{recetaId}")]
        public ActionResult<IEnumerable<RecetaIngrediente>> GetByReceta(int recetaId)
        {
            return _recetaIngredienteService.GetByReceta(recetaId);
        }

        [HttpGet("ingrediente/{ingredienteId}")]
        public ActionResult<IEnumerable<RecetaIngrediente>> GetByIngrediente(int ingredienteId)
        {
            return _recetaIngredienteService.GetByIngrediente(ingredienteId);
        }

        [HttpPost]
        public IActionResult Post([FromBody] RecetaIngrediente recetaIngrediente)
        {
            _recetaIngredienteService.Add(recetaIngrediente);
            return CreatedAtAction(nameof(Get), new { idReceta = recetaIngrediente.IdReceta, idIngrediente = recetaIngrediente.IdIngrediente }, recetaIngrediente);
        }

        [HttpPut("{idReceta}/{idIngrediente}")]
        public IActionResult Put(int idReceta, int idIngrediente, [FromBody] RecetaIngrediente recetaIngrediente)
        {
            if (idReceta != recetaIngrediente.IdReceta || idIngrediente != recetaIngrediente.IdIngrediente)
            {
                return BadRequest();
            }

            _recetaIngredienteService.Update(recetaIngrediente);
            return NoContent();
        }

        [HttpDelete("{idReceta}/{idIngrediente}")]
        public IActionResult Delete(int idReceta, int idIngrediente)
        {
            _recetaIngredienteService.Delete(idReceta, idIngrediente);
            return NoContent();
        }
    }
}
