using RecetasRedondas.Models;
using System.Collections.Generic;

namespace RecetasRedondas.Business
{
    public interface IUsuarioService
    {
        // Métodos para usuarios
        List<UsuarioDTO> GetAll();
        UsuarioDTO GetUsuarioId(int id);
        Usuario LoginUsuario(LoginUsuarioDTO loginDTO);
        Usuario RegisterUsuario(RegisterUsuarioDTO user);
        void UpdateUsuario(UsuarioDTO usuario);
        void DeleteUsuario(int idUsuario);
        
        // Métodos para alérgenos
        void AddAlergenos(int idUsuario, List<AddAlergenoDTO> alergenosDTO);
        void DeleteAlergeno(int idUsuario, int idAlergeno);
        List<AlergenoDTO> GetAlergenos(int idUsuario);
        
        // Métodos para categorías
        void AddCategorias(int idUsuario, List<AddCategoriaDTO> categoriasDTO);
        List<CategoriaDTO> GetCategorias(int idUsuario);
        void DeleteCategoria(int idUsuarioCategoria);
    }
}
