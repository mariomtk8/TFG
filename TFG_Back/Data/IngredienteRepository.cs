using Microsoft.EntityFrameworkCore;
using RecetasRedondas.Models;
using System.Collections.Generic;
using System.Linq;

namespace RecetasRedondas.Data
{
    public class IngredienteRepository : IIngredienteRepository
    {
        private readonly RecetasRedondasAppContext _context;

        public IngredienteRepository(RecetasRedondasAppContext context)
        {
            _context = context;
        }

        public List<Ingrediente> GetAll() => _context.Ingredientes.ToList();

        public Ingrediente Get(int id) => _context.Ingredientes.Find(id);

        public void Update(Ingrediente ingrediente)
        {
            var existingEntity = _context.Ingredientes.Find(ingrediente.IdIngrediente);
            if (existingEntity != null)
            {
                _context.Entry(existingEntity).State = EntityState.Detached;
            }

            _context.Entry(ingrediente).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Add(Ingrediente ingrediente)
        {
            _context.Ingredientes.Add(ingrediente);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var ingrediente = _context.Ingredientes.Find(id);
            if (ingrediente != null)
            {
                _context.Ingredientes.Remove(ingrediente);
                _context.SaveChanges();
            }
        }
    }
}
