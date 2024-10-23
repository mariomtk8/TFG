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

        // Métodos para alérgenos
        public void AddAlergenos(int idUsuario, List<AddAlergenoDTO> alergenosDTO)
        {
            _usuarioRepository.AddAlergenos(idUsuario, alergenosDTO);
        }

        public void DeleteAlergeno(int idUsuario, int idAlergeno)
        {
            _usuarioRepository.DeleteAlergeno(idUsuario, idAlergeno);
        }

        public List<AlergenoDTO> GetAlergenos(int idUsuario)
        {
            return _usuarioRepository.GetAlergenos(idUsuario);
        }

        // Métodos para usuarios
        public List<UsuarioDTO> GetAll() => _usuarioRepository.GetAll();

        public UsuarioDTO GetUsuarioId(int id)
        {
            return _usuarioRepository.GetUsuarioId(id);
        }

        public Usuario LoginUsuario(LoginUsuarioDTO loginDTO)
        {
            return _usuarioRepository.LoginUsuario(loginDTO);
        }

        public Usuario RegisterUsuario(RegisterUsuarioDTO user)
        {
            return _usuarioRepository.RegisterUsuario(user);
        }

        public void UpdateUsuario(UsuarioDTO usuario)
        {
            _usuarioRepository.UpdateUsuario(usuario);
        }

        public void DeleteUsuario(int idUsuario)
        {
            _usuarioRepository.DeleteUsuario(idUsuario);
        }

        // Métodos para categorías
        public void AddCategorias(int idUsuario, List<AddCategoriaDTO> categoriasDTO)
        {
            _usuarioRepository.AddCategorias(idUsuario, categoriasDTO);
        }

        public List<CategoriaDTO> GetCategorias(int idUsuario)
        {
            return _usuarioRepository.GetCategorias(idUsuario);
        }

        public void DeleteCategoria(int idUsuarioCategoria)
        {
            _usuarioRepository.DeleteCategoria(idUsuarioCategoria);
        }
    }
}
