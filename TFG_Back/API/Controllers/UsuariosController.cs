    using Microsoft.AspNetCore.Mvc;
    using RecetasRedondas.Models;
    using RecetasRedondas.Data;
    using RecetasRedondas.Business;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Authorization;
    using System.IdentityModel.Tokens.Jwt;

    namespace RecetasRedondas.Controllers
    {   
        [Authorize]
        [ApiController]
        [Route("[controller]")]
        public class UsuarioController : ControllerBase
        {
            private readonly IUsuarioService _usuarioService;
            private readonly IAuthService _authService;

            private readonly ILogger<UsuarioController> _logger;

            public UsuarioController(IUsuarioService usuarioService, IAuthService authService, ILogger<UsuarioController> logger)
            {
                _usuarioService = usuarioService;
                _authService = authService;
                _logger = logger;
            }

            // Get
            [Authorize(Roles = "Admin")]
            [HttpGet]
            public ActionResult<List<UsuarioDTO>> GetAll()
            {
                try
                {
                    _logger.LogInformation("Se ha solicitado obtener todos los usuarios.");
                    var usuarios = _usuarioService.GetAll();
                    return Ok(usuarios);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error al intentar obtener todos los usuarios: {ex.Message}");
                    return StatusCode(500, new { message = ex.Message });
                }
            }

            [HttpGet("{idUsuario}", Name = "GetUsuarioId")]

            public ActionResult<UsuarioDTO> GetUsuarioId([FromRoute] int idUsuario)
            {
                try
                {
                    // Verificar si el usuario tiene acceso al recurso
                    var currentUser = HttpContext.User;
                    if (!_authService.HasAccessToResource(currentUser, idUsuario))
                    {
                        _logger.LogWarning($"Acceso denegado para el usuario con ID: {idUsuario}");
                        return Forbid();
                    }

                    var usuario = _usuarioService.GetUsuarioId(idUsuario);
                    _logger.LogInformation($"Usuario con ID {idUsuario} obtenido exitosamente.");
                    return Ok(usuario);

                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error al intentar obtener el usuario con ID {idUsuario}: {ex.Message}");
                    return StatusCode(500, new { message = ex.Message });
                }
            }

            //Post
            [AllowAnonymous]
            [HttpPost("login", Name = "LoginUsuario")]
            public ActionResult<Usuario> LoginUsuario([FromBody] LoginUsuarioDTO loginUsuario)
            {

                try
                {
                    _logger.LogInformation($"Se solicita iniciar sesion.");
                    var usuario = _usuarioService.LoginUsuario(loginUsuario);
                    var token = _authService.GenerateJwtToken(usuario);

                    return Ok(new { token });
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error al intentar iniciar sesion: {ex.Message}");
                    return StatusCode(500, new { message = ex.Message });
                }
            }

            [AllowAnonymous]
            [HttpPost("register",Name = "RegisterUsuario")]

            public ActionResult RegisterUsuario([FromBody] RegisterUsuarioDTO user)
            {

                try
                {
                    _logger.LogInformation($"Se solicita registrar un usuario.");
                    var usuario = _usuarioService.RegisterUsuario(user);
                    var token = _authService.GenerateJwtToken(usuario);
                    _logger.LogInformation($"Usuario registrado exitosamente: {user.Nombre}");
                    
                    return Ok(new { token });
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error al intentar registrar usuario: {ex.Message}");
                    return StatusCode(500, new { message = ex.Message });
                }
            }

            //Update

            [HttpPut(Name = "UpdateUsuario")]

            public ActionResult UpdateUsuario([FromBody] UsuarioDTO usuario)
            {

                try
                {

                    _logger.LogInformation($"Se solicita modificar al usuario con Id: {usuario.IdUsuario}.");

                    // Obtener el usuario autenticado
                    var currentUser = HttpContext.User;

                    // Verificar si el usuario tiene acceso al recurso
                    if (!_authService.HasAccessToResource(currentUser, usuario.IdUsuario))
                    {
                        _logger.LogWarning($"El usuario con ID: {currentUser.FindFirst(JwtRegisteredClaimNames.Sub)?.Value} no tiene acceso para modificar el usuario con ID: {usuario.IdUsuario}.");
                        return Forbid();
                    }

                    _usuarioService.UpdateUsuario(usuario);
                    return Ok(usuario);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error al intentar modificar al usuario: {ex.Message}");
                    return StatusCode(500, new { message = ex.Message });
                }
            }

            //Delete
            [HttpDelete("{idUsuario}", Name = "DeleteUsuario")]

            public ActionResult DeleteUsuario([FromRoute] int idUsuario)
            {

                try
                {
                    _logger.LogInformation($"Se solicita eliminar al usuario con Id: {idUsuario}.");

                    // Obtener el usuario autenticado
                    var currentUser = HttpContext.User;

                    if (!_authService.HasAccessToResource(currentUser, idUsuario))
                    {
                        _logger.LogWarning($"El usuario con ID: {currentUser.FindFirst(JwtRegisteredClaimNames.Sub)?.Value} no tiene acceso para eliminar el usuario con ID: {idUsuario}.");
                        return Forbid();
                    }

                    _usuarioService.DeleteUsuario(idUsuario);
                    return Ok();
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error al intentar eliminar usuario: {ex.Message}");
                    return StatusCode(500, new { message = ex.Message });
                }
            }
            // GET: /usuarios/{idUsuario}/alergenos
        [HttpGet("{idUsuario}/alergenos")]
        public ActionResult<List<AlergenoDTO>> GetAlergenos([FromRoute] int idUsuario)
        {
            try
            {
                var alergenos = _usuarioService.GetAlergenos(idUsuario);
                return Ok(alergenos);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener los alérgenos del usuario: {ex.Message}");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        // POST: /usuarios/{idUsuario}/alergenos
        [HttpPost("{idUsuario}/alergenos")]
        public ActionResult AddAlergenos([FromRoute] int idUsuario, List<AddAlergenoDTO> alergenosDTO)
        {
            try
            {
                _usuarioService.AddAlergenos(idUsuario, alergenosDTO);
                return Ok(new { message = "Alérgenos añadidos correctamente." });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al añadir alérgenos al usuario: {ex.Message}");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        // Delete: /usuarios/{idUsuario}/alergenos
        [HttpDelete("{idUsuario}/{idAlergeno}")]
        public ActionResult DeleteAlergeno(int idUsuario, int idAlergeno)
        {
            try
            {
                _usuarioService.DeleteAlergeno(idUsuario, idAlergeno);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar los alérgenos del usuario: {ex.Message}");
                return StatusCode(500, new { message = ex.Message });
            }
        }
        }
    }