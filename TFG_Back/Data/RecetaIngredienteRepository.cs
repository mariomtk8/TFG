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

        public RecetaIngrediente Get(int idReceta, int idIngrediente) 
            => _context.RecetaIngredientes.Find(idReceta, idIngrediente);

        public void Update(RecetaIngrediente recetaIngrediente)
        {
            var existingEntity = _context.RecetaIngredientes.Find(recetaIngrediente.IdReceta, recetaIngrediente.IdIngrediente);
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

        public void Delete(int idReceta, int idIngrediente)
        {
            var recetaIngrediente = _context.RecetaIngredientes.Find(idReceta, idIngrediente);
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
