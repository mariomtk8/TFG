using Microsoft.EntityFrameworkCore;
using RecetasRedondas.Models;
using System.Text;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;

namespace RecetasRedondas.Data
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly RecetasRedondasAppContext _context;

        public UsuarioRepository(RecetasRedondasAppContext context)
        {
            _context = context;
        }
        public void AddAlergenos(int idUsuario, List<AddAlergenoDTO> alergenosDTO)
        {
            var usuario = _context.Usuarios
                .Include(u => u.Alergenos)
                .FirstOrDefault(u => u.IdUsuario == idUsuario);

            if (usuario == null)
            {
                throw new Exception($"Usuario con ID {idUsuario} no encontrado.");
            }

            // Asocia los alérgenos al usuario
            foreach (var alergenoDto in alergenosDTO)
            {
                // Crea un nuevo objeto Alergeno para asociar
                var alergeno = new Alergeno
                {
                    // El IdAlergeno se generará automáticamente en la base de datos
                    IdIngrediente = alergenoDto.IdIngrediente,
                };

                usuario.Alergenos.Add(alergeno);
            }

            SaveChanges();
        }

        // Obtiene la lista de alérgenos de un usuario
        public List<AlergenoDTO> GetAlergenos(int idUsuario)
        {
            var usuario = _context.Usuarios
                .Include(u => u.Alergenos)
                .FirstOrDefault(u => u.IdUsuario == idUsuario);

            if (usuario == null)
            {
                throw new Exception($"Usuario con ID {idUsuario} no encontrado.");
            }

            return usuario.Alergenos
                .Select(a => new AlergenoDTO
                {
                    IdIngrediente = a.IdIngrediente,
                    IdAlergeno = a.IdAlergeno // Incluye IdAlergeno en el DTO
                })
                .ToList();
        }
        // Elimina un alérgeno específico de un usuario
        public void DeleteAlergeno(int idUsuario, int idAlergeno)
        {
            var usuario = _context.Usuarios
                .Include(u => u.Alergenos)
                .FirstOrDefault(u => u.IdUsuario == idUsuario);

            if (usuario == null)
            {
                throw new Exception($"Usuario con ID {idUsuario} no encontrado.");
            }

            var alergeno = usuario.Alergenos.FirstOrDefault(a => a.IdAlergeno == idAlergeno);
            if (alergeno != null)
            {
                usuario.Alergenos.Remove(alergeno);
                SaveChanges();
            }
            else
            {
                throw new Exception($"Alérgeno con ID {idAlergeno} no encontrado para el usuario con ID {idUsuario}.");
            }
        }

        //Get 
        public List<UsuarioDTO> GetAll()
        {
            var usuarios = _context.Usuarios.ToList();

            var usuarioDTOs = usuarios.Select(usuario => new UsuarioDTO
            {
                IdUsuario = usuario.IdUsuario,
                Nombre = usuario.Nombre,
                Rol = usuario.Rol
            }).ToList();

            return usuarioDTOs;
        }

        //Get id
        public UsuarioDTO GetUsuarioId(int id)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.IdUsuario == id);


            if (usuario is null)
            {
                throw new Exception($"No hay ningun usuario con el ID: {id}");
            }

            var usuarioDTOs = new UsuarioDTO
            {
                IdUsuario = usuario.IdUsuario,
                Nombre = usuario.Nombre,
                Rol = usuario.Rol,
            };

            return usuarioDTOs;
        }

        //Login

        public Usuario LoginUsuario(LoginUsuarioDTO loginDTO)
        {
            if (string.IsNullOrWhiteSpace(loginDTO.Correo))
            {
                throw new ArgumentException("El correo electrónico no puede estar vacío", nameof(loginDTO.Correo));
            }

            if (string.IsNullOrWhiteSpace(loginDTO.Contrasena))
            {
                throw new ArgumentException("La contraseña no puede estar vacía", nameof(loginDTO.Contrasena));
            }

            var usuario = _context.Usuarios.FirstOrDefault(u => u.Correo == loginDTO.Correo && u.Contrasena == loginDTO.Contrasena);

            if (usuario is null)
            {
                throw new InvalidOperationException("Usuario o Correo Incorrecto");
            }

            return usuario;
        }

        //Register

        public Usuario RegisterUsuario(RegisterUsuarioDTO user)
        {

            if (_context.Usuarios.Any(u => u.Correo == user.Correo))
            {
                throw new ArgumentException("El correo electrónico ya está en uso.");
            }

            if (_context.Usuarios.Any(u => u.Contrasena == user.Contrasena))
            {
                throw new ArgumentException("La contraseña ya esta en uso.");
            }

            var newUser = new Usuario
            {
                Nombre = user.Nombre,
                Contrasena = user.Contrasena,
                Correo = user.Correo,
                Rol = false
            };

            _context.Usuarios.Add(newUser);
            SaveChanges();

            return newUser;
        }


        //Update

        public void UpdateUsuario(UsuarioDTO usuario)
        {
            var existingUser = _context.Usuarios.Find(usuario.IdUsuario);
            if (existingUser == null)
            {
                throw new KeyNotFoundException("No se encontró el Usuario a actualizar.");
            }

            existingUser.Nombre = usuario.Nombre;
            existingUser.Contrasena = usuario.Contrasena;
            existingUser.Correo = usuario.Correo;

            _context.Usuarios.Update(existingUser);
            SaveChanges();
        }

        //Delete

        public void DeleteUsuario(int idUsuario)
        {
            var usuario = _context.Usuarios.FirstOrDefault(r => r.IdUsuario == idUsuario);

            if (usuario is null)
            {
                throw new Exception($"No se encontro el Usuario con el ID: {idUsuario}");
            }

            _context.Usuarios.Remove(usuario);
            SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void AddCategorias(int idUsuario, List<AddCategoriaDTO> categoriasDTO)
        {
            var usuario = _context.Usuarios
                .Include(u => u.UsuarioCategorias)
                    .ThenInclude(uc => uc.Categoria)
                .FirstOrDefault(u => u.IdUsuario == idUsuario);

            if (usuario == null)
            {
                throw new Exception($"Usuario con ID {idUsuario} no encontrado.");
            }

            // Asocia las categorías al usuario
            foreach (var categoriaDto in categoriasDTO)
            {
                // Crea un nuevo objeto UsuarioCategoria para asociar
                var usuarioCategoria = new UsuarioCategoria
                {
                    IdUsuario = idUsuario,
                    IdCategoria = categoriaDto.IdCategoria
                    // No asignas IdUsuarioCategoria, ya que se genera automáticamente
                };

                // Añade la nueva asociación a la colección del usuario
                usuario.UsuarioCategorias.Add(usuarioCategoria);
            }

            // Guarda los cambios en la base de datos
            SaveChanges();
        }


        public List<CategoriaDTO> GetCategorias(int idUsuario)
        {
            var usuario = _context.Usuarios
                .Include(u => u.UsuarioCategorias)
                    .ThenInclude(uc => uc.Categoria)
                .FirstOrDefault(u => u.IdUsuario == idUsuario);

            if (usuario == null)
            {
                throw new Exception($"Usuario con ID {idUsuario} no encontrado.");
            }

            return usuario.UsuarioCategorias
                .Select(uc => new CategoriaDTO
                {
                    IdUsuarioCategoria = uc.IdUsuarioCategoria, // Asegúrate de que este ID esté disponible
                    IdCategoria = uc.Categoria.IdCategoria,
                    NombreCategoria = uc.Categoria.NombreCategoria
                })
                .ToList();
        }

        public void DeleteCategoria(int idUsuarioCategoria)
        {
            var usuarioCategoria = _context.UsuarioCategorias
                .FirstOrDefault(uc => uc.IdUsuarioCategoria == idUsuarioCategoria);

            if (usuarioCategoria == null)
            {
                throw new Exception($"UsuarioCategoria con ID {idUsuarioCategoria} no encontrado.");
            }

            _context.UsuarioCategorias.Remove(usuarioCategoria);
            SaveChanges();
        }



    }
}
