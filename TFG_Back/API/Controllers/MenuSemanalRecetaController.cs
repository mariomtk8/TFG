using Microsoft.AspNetCore.Mvc;
using RecetasRedondas.Business;
using RecetasRedondas.Models;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

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

        [AllowAnonymous]
        [HttpGet]
        public ActionResult<List<MenuSemanalReceta>> GetAll()
        {
            return Ok(_menuSemanalRecetaService.GetAll());
        }

        [AllowAnonymous]
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

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Add([FromBody] MenuSemanalReceta menuSemanalReceta)
        {
            _menuSemanalRecetaService.Add(menuSemanalReceta);
            return CreatedAtAction(nameof(Get), new { idMenuSemanal = menuSemanalReceta.IdMenuSemanal, idReceta = menuSemanalReceta.IdReceta, fecha = menuSemanalReceta.Fecha }, menuSemanalReceta);
        }

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        [HttpDelete("{idMenuSemanal}/{idReceta}/{fecha}")]
        public ActionResult Delete(int idMenuSemanal, int idReceta, DateTime fecha)
        {
            _menuSemanalRecetaService.Delete(idMenuSemanal, idReceta, fecha);
            return NoContent();
        }
    }
}
