using Microsoft.AspNetCore.Mvc;
using RecetasRedondas.Business;
using RecetasRedondas.Models;
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

        [HttpGet]
        public ActionResult<List<MenuSemanal>> GetAll()
        {
            return Ok(_menuSemanalService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<MenuSemanal> Get(int id)
        {
            var menuSemanal = _menuSemanalService.Get(id);
            if (menuSemanal == null)
            {
                return NotFound();
            }
            return Ok(menuSemanal);
        }

        [HttpPost]
        public ActionResult Add([FromBody] MenuSemanal menuSemanal)
        {
            _menuSemanalService.Add(menuSemanal);
            return CreatedAtAction(nameof(Get), new { id = menuSemanal.IdMenuSemanal }, menuSemanal);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] MenuSemanal menuSemanal)
        {
            if (id != menuSemanal.IdMenuSemanal)
            {
                return BadRequest();
            }

            _menuSemanalService.Update(menuSemanal);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _menuSemanalService.Delete(id);
            return NoContent();
        }
    }
}
