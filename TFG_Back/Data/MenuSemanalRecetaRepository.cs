using Microsoft.EntityFrameworkCore;
using RecetasRedondas.Models;
using System.Collections.Generic;
using System.Linq;

namespace RecetasRedondas.Data
{
    public class MenuSemanalRecetaRepository : IMenuSemanalRecetaRepository
    {
        private readonly RecetasRedondasAppContext _context;

        public MenuSemanalRecetaRepository(RecetasRedondasAppContext context)
        {
            _context = context;
        }

        public List<MenuSemanalReceta> GetAll() => _context.MenuSemanalRecetas.ToList();

        public MenuSemanalReceta Get(int idMenuSemanal, int idReceta, DateTime fecha) =>
            _context.MenuSemanalRecetas.Find(idMenuSemanal, idReceta, fecha);

        public void Update(MenuSemanalReceta menuSemanalReceta)
        {
            var existingEntity = _context.MenuSemanalRecetas.Find(
                menuSemanalReceta.IdMenuSemanal, 
                menuSemanalReceta.IdReceta, 
                menuSemanalReceta.Fecha);
            if (existingEntity != null)
            {
                _context.Entry(existingEntity).State = EntityState.Detached;
            }

            _context.Entry(menuSemanalReceta).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Add(MenuSemanalReceta menuSemanalReceta)
        {
            _context.MenuSemanalRecetas.Add(menuSemanalReceta);
            _context.SaveChanges();
        }

        public void Delete(int idMenuSemanal, int idReceta, DateTime fecha)
        {
            var menuSemanalReceta = _context.MenuSemanalRecetas.Find(idMenuSemanal, idReceta, fecha);
            if (menuSemanalReceta != null)
            {
                _context.MenuSemanalRecetas.Remove(menuSemanalReceta);
                _context.SaveChanges();
            }
        }
    }
}
