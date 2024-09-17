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

        public List<MenuSemanal> GetAll() => _context.MenusSemanales.ToList();

        public MenuSemanal Get(int id) => _context.MenusSemanales.Find(id);

        public void Update(MenuSemanal menuSemanal)
        {
            var existingEntity = _context.MenusSemanales.Find(menuSemanal.IdMenuSemanal);
            if (existingEntity != null)
            {
                _context.Entry(existingEntity).State = EntityState.Detached;
            }

            _context.Entry(menuSemanal).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Add(MenuSemanal menuSemanal)
        {
            _context.MenusSemanales.Add(menuSemanal);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var menuSemanal = _context.MenusSemanales.Find(id);
            if (menuSemanal != null)
            {
                _context.MenusSemanales.Remove(menuSemanal);
                _context.SaveChanges();
            }
        }
    }
}
