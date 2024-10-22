using RecetasRedondas.Data;
using RecetasRedondas.Models;
using System.Collections.Generic;

namespace RecetasRedondas.Business
{
    public class MenuSemanalService : IMenuSemanalService
{
    private readonly IMenuSemanalRepository _menuSemanalRepository;

    public MenuSemanalService(IMenuSemanalRepository menuSemanalRepository)
    {
        _menuSemanalRepository = menuSemanalRepository;
    }

    public void CrearMenuSemanal(MenuSemanal menuSemanal)
    {
        _menuSemanalRepository.CrearMenuSemanal(menuSemanal);
    }

    public MenuSemanal ObtenerMenuSemanalPorUsuario(int usuarioId)
    {
        return _menuSemanalRepository.ObtenerMenuSemanalPorUsuario(usuarioId);
    }

    public void ActualizarMenuSemanal(MenuSemanal menuSemanal)
    {
        _menuSemanalRepository.ActualizarMenuSemanal(menuSemanal);
    }
}
    
    }