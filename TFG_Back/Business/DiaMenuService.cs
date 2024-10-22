using System.Collections.Generic;
using RecetasRedondas.Data;
using RecetasRedondas.Models;

namespace RecetasRedondas.Services
{
    public class DiaMenuService : IDiaMenuService
    {
        private readonly IDiaMenuRepository _diaMenuRepository;

        public DiaMenuService(IDiaMenuRepository diaMenuRepository)
        {
            _diaMenuRepository = diaMenuRepository;
        }

        public void CrearMenuDiario(int usuarioId)
        {
            var menuDia = _diaMenuRepository.GenerarMenuDia(usuarioId);
            foreach (var diaMenu in menuDia)
            {
                _diaMenuRepository.CrearMenuDiario(diaMenu); // Asegúrate de que este método está implementado en el repositorio
            }
        }

        public List<DiaMenu> ObtenerMenuDiario()
        {
            return _diaMenuRepository.GetAll(); // Método para obtener todos los menús diarios
        }
    }
}
