using RecetasRedondas.Data;
using RecetasRedondas.Models;
using System.Collections.Generic;

namespace RecetasRedondas.Business
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        // Asociación de alérgenos al usuario
        public void AddAlergenos(int idUsuario, List<AddAlergenoDTO> alergenosDTO)
        {
            _usuarioRepository.AddAlergenos(idUsuario, alergenosDTO);
        }

        // Modificación de alérgenos del usuario
        public void DeleteAlergeno(int idUsuario, int idAlergeno)
        {
            _usuarioRepository.DeleteAlergeno(idUsuario, idAlergeno);
        }

        // Obtiene los alérgenos de un usuario
        public List<AlergenoDTO> GetAlergenos(int idUsuario)
        {
            return _usuarioRepository.GetAlergenos(idUsuario);
        }


        //Get
        public List<UsuarioDTO> GetAll() => _usuarioRepository.GetAll();
        public UsuarioDTO GetUsuarioId(int id)
        {
            return _usuarioRepository.GetUsuarioId(id);
        }

        public Usuario LoginUsuario(LoginUsuarioDTO loginDTO)
        {
            return _usuarioRepository.LoginUsuario(loginDTO);
        }

        //Create
        public Usuario RegisterUsuario(RegisterUsuarioDTO user)
        {
            return _usuarioRepository.RegisterUsuario(user);
        }

        //Update
        public void UpdateUsuario(UsuarioDTO usuario)
        {
            _usuarioRepository.UpdateUsuario(usuario);
        }


        //Delete
        public void DeleteUsuario(int idUsuario)
        {
            _usuarioRepository.DeleteUsuario(idUsuario);
        }
    }
}
