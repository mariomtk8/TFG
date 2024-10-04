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
        [HttpGet("{idRecetaIngrediente}")]
        public ActionResult<RecetaIngrediente> Get(int idRecetaIngrediente)
        {
            return _recetaIngredienteService.GetById(idRecetaIngrediente);
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
            return CreatedAtAction(nameof(Get), new { idRecetaIngrediente = recetaIngrediente.IdRecetaIngrediente }, recetaIngrediente);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{idRecetaIngrediente}")]
        public IActionResult Put(int idRecetaIngrediente, [FromBody] RecetaIngrediente recetaIngrediente)
        {
            if (idRecetaIngrediente != recetaIngrediente.IdRecetaIngrediente)
            {
                return BadRequest();
            }

            _recetaIngredienteService.Update(recetaIngrediente);
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{idRecetaIngrediente}")]
        public IActionResult Delete(int idRecetaIngrediente)
        {
            _recetaIngredienteService.Delete(idRecetaIngrediente);
            return NoContent();
        }
    }
}
