using Microsoft.AspNetCore.Mvc;
using RecetasRedondas.Business;
using RecetasRedondas.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

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

        [AllowAnonymous]
        [HttpGet]
        public ActionResult<List<MenuSemanal>> GetAll()
        {
            return Ok(_menuSemanalService.GetAll());
        }

        [AllowAnonymous]
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

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Add([FromBody] MenuSemanal menuSemanal)
        {
            _menuSemanalService.Add(menuSemanal);
            return CreatedAtAction(nameof(Get), new { id = menuSemanal.IdMenuSemanal }, menuSemanal);
        }

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _menuSemanalService.Delete(id);
            return NoContent();
        }
    }
}
