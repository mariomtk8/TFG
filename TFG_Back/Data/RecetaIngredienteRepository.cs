using Microsoft.EntityFrameworkCore;
using RecetasRedondas.Models;
using System.Collections.Generic;
using System.Linq;

namespace RecetasRedondas.Data
{
    public class RecetaIngredienteRepository : IRecetaIngredienteRepository
    {
        private readonly RecetasRedondasAppContext _context;

        public RecetaIngredienteRepository(RecetasRedondasAppContext context)
        {
            _context = context;
        }

        public List<RecetaIngrediente> GetAll() => _context.RecetaIngredientes.ToList();

        public RecetaIngrediente GetById(int idRecetaIngrediente)
            => _context.RecetaIngredientes.Find(idRecetaIngrediente);

        public void Update(RecetaIngrediente recetaIngrediente)
        {
            var existingEntity = _context.RecetaIngredientes.Find(recetaIngrediente.IdRecetaIngrediente);
            if (existingEntity != null)
            {
                _context.Entry(existingEntity).State = EntityState.Detached;
            }

            _context.Entry(recetaIngrediente).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Add(RecetaIngrediente recetaIngrediente)
        {
            _context.RecetaIngredientes.Add(recetaIngrediente);
            _context.SaveChanges();
        }

        public void Delete(int idRecetaIngrediente)
        {
            var recetaIngrediente = _context.RecetaIngredientes.Find(idRecetaIngrediente);
            if (recetaIngrediente != null)
            {
                _context.RecetaIngredientes.Remove(recetaIngrediente);
                _context.SaveChanges();
            }
        }

        public List<RecetaIngrediente> GetByReceta(int recetaId)
        {
            return _context.RecetaIngredientes.Where(ri => ri.IdReceta == recetaId).ToList();
        }

        public List<RecetaIngrediente> GetByIngrediente(int ingredienteId)
        {
            return _context.RecetaIngredientes.Where(ri => ri.IdIngrediente == ingredienteId).ToList();
        }
    }
}
