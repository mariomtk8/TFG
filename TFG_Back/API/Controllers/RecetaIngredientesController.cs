using Microsoft.AspNetCore.Mvc;
using RecetasRedondas.Business;
using RecetasRedondas.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

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

        [AllowAnonymous]
        [HttpGet]
        public ActionResult<IEnumerable<RecetaIngrediente>> Get()
        {
            return _recetaIngredienteService.GetAll();
        }

        [AllowAnonymous]
        [HttpGet("{idReceta}/{idIngrediente}")]
        public ActionResult<RecetaIngrediente> Get(int idReceta, int idIngrediente)
        {
            return _recetaIngredienteService.Get(idReceta, idIngrediente);
        }

        [AllowAnonymous]
        [HttpGet("receta/{recetaId}")]
        public ActionResult<IEnumerable<RecetaIngrediente>> GetByReceta(int recetaId)
        {
            return _recetaIngredienteService.GetByReceta(recetaId);
        }

        [AllowAnonymous]
        [HttpGet("ingrediente/{ingredienteId}")]
        public ActionResult<IEnumerable<RecetaIngrediente>> GetByIngrediente(int ingredienteId)
        {
            return _recetaIngredienteService.GetByIngrediente(ingredienteId);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Post([FromBody] RecetaIngrediente recetaIngrediente)
        {
            _recetaIngredienteService.Add(recetaIngrediente);
            return CreatedAtAction(nameof(Get), new { idReceta = recetaIngrediente.IdReceta, idIngrediente = recetaIngrediente.IdIngrediente }, recetaIngrediente);
        }

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        [HttpDelete("{idReceta}/{idIngrediente}")]
        public IActionResult Delete(int idReceta, int idIngrediente)
        {
            _recetaIngredienteService.Delete(idReceta, idIngrediente);
            return NoContent();
        }
    }
}
