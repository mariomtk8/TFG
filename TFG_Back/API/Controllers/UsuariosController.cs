using Microsoft.AspNetCore.Mvc;
using RecetasRedondas.Business;
using RecetasRedondas.Models;
using System.Collections.Generic;

namespace RecetasRedondas.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public ActionResult<List<Usuario>> GetAll()
        {
            return Ok(_usuarioService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Usuario> Get(int id)
        {
            var usuario = _usuarioService.Get(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpPost]
        public ActionResult Add([FromBody] Usuario usuario)
        {
            _usuarioService.Add(usuario);
            return CreatedAtAction(nameof(Get), new { id = usuario.IdUsuario }, usuario);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] Usuario usuario)
        {
            if (id != usuario.IdUsuario)
            {
                return BadRequest();
            }

            _usuarioService.Update(usuario);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _usuarioService.Delete(id);
            return NoContent();
        }
    }
}
