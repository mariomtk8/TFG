using Microsoft.AspNetCore.Mvc;
using RecetasRedondas.Business;
using RecetasRedondas.Models;
using System;
using System.Collections.Generic;

namespace RecetasRedondas.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MenuSemanalRecetaController : ControllerBase
    {
        private readonly IMenuSemanalRecetaService _menuSemanalRecetaService;

        public MenuSemanalRecetaController(IMenuSemanalRecetaService menuSemanalRecetaService)
        {
            _menuSemanalRecetaService = menuSemanalRecetaService;
        }

        [HttpGet]
        public ActionResult<List<MenuSemanalReceta>> GetAll()
        {
            return Ok(_menuSemanalRecetaService.GetAll());
        }

        [HttpGet("{idMenuSemanal}/{idReceta}/{fecha}")]
        public ActionResult<MenuSemanalReceta> Get(int idMenuSemanal, int idReceta, DateTime fecha)
        {
            var menuSemanalReceta = _menuSemanalRecetaService.Get(idMenuSemanal, idReceta, fecha);
            if (menuSemanalReceta == null)
            {
                return NotFound();
            }
            return Ok(menuSemanalReceta);
        }

        [HttpPost]
        public ActionResult Add([FromBody] MenuSemanalReceta menuSemanalReceta)
        {
            _menuSemanalRecetaService.Add(menuSemanalReceta);
            return CreatedAtAction(nameof(Get), new { idMenuSemanal = menuSemanalReceta.IdMenuSemanal, idReceta = menuSemanalReceta.IdReceta, fecha = menuSemanalReceta.Fecha }, menuSemanalReceta);
        }

        [HttpPut("{idMenuSemanal}/{idReceta}/{fecha}")]
        public ActionResult Update(int idMenuSemanal, int idReceta, DateTime fecha, [FromBody] MenuSemanalReceta menuSemanalReceta)
        {
            if (idMenuSemanal != menuSemanalReceta.IdMenuSemanal || idReceta != menuSemanalReceta.IdReceta || fecha != menuSemanalReceta.Fecha)
            {
                return BadRequest();
            }

            _menuSemanalRecetaService.Update(menuSemanalReceta);
            return NoContent();
        }

        [HttpDelete("{idMenuSemanal}/{idReceta}/{fecha}")]
        public ActionResult Delete(int idMenuSemanal, int idReceta, DateTime fecha)
        {
            _menuSemanalRecetaService.Delete(idMenuSemanal, idReceta, fecha);
            return NoContent();
        }
    }
}
