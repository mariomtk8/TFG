using Microsoft.EntityFrameworkCore;
using RecetasRedondas.Models;
using System.Collections.Generic;
using System.Linq;

namespace RecetasRedondas.Data
{
    public class MenuSemanalRepository : IMenuSemanalRepository
{
    private readonly RecetasRedondasAppContext _context;

        public MenuSemanalRepository(RecetasRedondasAppContext context)
        {
            _context = context;
            
        }

   public void CrearMenuSemanal(MenuSemanal menuSemanal)
    {
        _context.MenusSemanales.Add(menuSemanal);
        foreach (var dia in menuSemanal.DiasMenu)
        {
            dia.IdMenuSemanal = menuSemanal.IdMenuSemanal; // Asignar el IdMenuSemanal
            _context.DiasMenu.Add(dia);
        }
        _context.SaveChanges(); // Guardar todos los cambios en la base de datos
    }

    public MenuSemanal ObtenerMenuSemanalPorUsuario(int usuarioId)
    {
        return _context.MenusSemanales
            .Include(ms => ms.DiasMenu)
            .FirstOrDefault(ms => ms.IdUsuario == usuarioId);
    }

    public void ActualizarMenuSemanal(MenuSemanal menuSemanal)
    {
        _context.MenusSemanales.Update(menuSemanal);
        _context.SaveChanges(); // Guardar los cambios
    }
}}