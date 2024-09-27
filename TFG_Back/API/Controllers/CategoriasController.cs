using Microsoft.AspNetCore.Mvc;
using RecetasRedondas.Business;
using RecetasRedondas.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace RecetasRedondas.Controllers
{   
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }
        
        [AllowAnonymous]
        [HttpGet]
        public ActionResult<List<Categoria>> GetAll()
        {
            return Ok(_categoriaService.GetAll());
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public ActionResult<Categoria> Get(int id)
        {
            var categoria = _categoriaService.Get(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return Ok(categoria);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Add([FromBody] Categoria categoria)
        {
            _categoriaService.Add(categoria);
            return CreatedAtAction(nameof(Get), new { id = categoria.IdCategoria }, categoria);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] Categoria categoria)
        {
            if (id != categoria.IdCategoria)
            {
                return BadRequest();
            }

            _categoriaService.Update(categoria);
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _categoriaService.Delete(id);
            return NoContent();
        }
    }
}
