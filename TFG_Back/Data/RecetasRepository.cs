using Microsoft.EntityFrameworkCore;
using RecetasRedondas.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecetasRedondas.Data
{
    public class RecetaRepository : IRecetaRepository
    {
        private readonly RecetasRedondasAppContext _context;

        public RecetaRepository(RecetasRedondasAppContext context)
        {
            _context = context;
        }

        public List<Receta> GetAll() => _context.Recetas.Include(p => p.Pasos).ToList();

        public Receta Get(int id) => _context.Recetas.Include(p => p.Pasos).FirstOrDefault(r=> r.IdReceta == id);

        public List<Receta> GetByCategoria(int idCategoria)
        {
            return _context.Recetas
                .Where(r => r.IdCategoria == idCategoria)
                .ToList();
        }

        public void Update(Receta receta)
        {
            var existingEntity = _context.Recetas.Find(receta.IdReceta);
            if (existingEntity != null)
            {
                _context.Entry(existingEntity).State = EntityState.Detached;
            }

            _context.Entry(receta).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Add(Receta receta)
        {
            _context.Recetas.Add(receta);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var receta = _context.Recetas.Find(id);
            if (receta != null)
            {
                _context.Recetas.Remove(receta);
                _context.SaveChanges();
            }
        }
    }
}
