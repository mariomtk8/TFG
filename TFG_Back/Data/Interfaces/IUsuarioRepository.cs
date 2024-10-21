using RecetasRedondas.Models;
using System.Collections.Generic;

namespace RecetasRedondas.Data
{
    public interface IUsuarioRepository
    {
        List<UsuarioDTO> GetAll();
        public UsuarioDTO GetUsuarioId(int id);
        public Usuario LoginUsuario(LoginUsuarioDTO loginDTO);
        public Usuario RegisterUsuario(RegisterUsuarioDTO user);
        void UpdateUsuario(UsuarioDTO usuario);
        void DeleteUsuario(int idUsuario);
        void AddAlergenos(int idUsuario, List<AddAlergenoDTO> alergenosDTO);
        void DeleteAlergeno(int idUsuario, int idAlergeno);
        List<AlergenoDTO> GetAlergenos(int idUsuario);
    }
}
