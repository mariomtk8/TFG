using Microsoft.AspNetCore.Mvc;
using RecetasRedondas.Business;
using RecetasRedondas.Models;
using System.Collections.Generic;

namespace RecetasRedondas.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IngredienteController : ControllerBase
    {
        private readonly IIngredienteService _ingredienteService;

        public IngredienteController(IIngredienteService ingredienteService)
        {
            _ingredienteService = ingredienteService;
        }

        [HttpGet]
        public ActionResult<List<Ingrediente>> GetAll()
        {
            return Ok(_ingredienteService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Ingrediente> Get(int id)
        {
            var ingrediente = _ingredienteService.Get(id);
            if (ingrediente == null)
            {
                return NotFound();
            }
            return Ok(ingrediente);
        }

        [HttpPost]
        public ActionResult Add([FromBody] Ingrediente ingrediente)
        {
            _ingredienteService.Add(ingrediente);
            return CreatedAtAction(nameof(Get), new { id = ingrediente.IdIngrediente }, ingrediente);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] Ingrediente ingrediente)
        {
            if (id != ingrediente.IdIngrediente)
            {
                return BadRequest();
            }

            _ingredienteService.Update(ingrediente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _ingredienteService.Delete(id);
            return NoContent();
        }
    }
}
