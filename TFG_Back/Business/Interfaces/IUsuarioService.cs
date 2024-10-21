using RecetasRedondas.Models;
using System.Collections.Generic;

namespace RecetasRedondas.Business
{
    public interface IUsuarioService
    {
        //Get
        public List<UsuarioDTO> GetAll();
        public UsuarioDTO GetUsuarioId(int id);
        public Usuario LoginUsuario(LoginUsuarioDTO loginDTO);
        //Register
        public Usuario RegisterUsuario(RegisterUsuarioDTO user);
        //Update
        void UpdateUsuario(UsuarioDTO usuario);
        //Delete
        void DeleteUsuario(int idUsuario);
        void AddAlergenos(int idUsuario, List<AddAlergenoDTO> alergenosDTO);
        void DeleteAlergeno(int idUsuario, int idAlergeno);
        List<AlergenoDTO> GetAlergenos(int idUsuario);
    }
}
