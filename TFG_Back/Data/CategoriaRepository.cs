using Microsoft.EntityFrameworkCore;
using RecetasRedondas.Models;
using System.Collections.Generic;
using System.Linq;

namespace RecetasRedondas.Data
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly RecetasRedondasAppContext _context;

        public CategoriaRepository(RecetasRedondasAppContext context)
        {
            _context = context;
        }

        public List<Categoria> GetAll() => _context.Categorias.ToList();

        public Categoria Get(int id) => _context.Categorias.Find(id);

        public void Update(Categoria categoria)
        {
            var existingEntity = _context.Categorias.Find(categoria.IdCategoria);
            if (existingEntity != null)
            {
                _context.Entry(existingEntity).State = EntityState.Detached;
            }

            _context.Entry(categoria).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Add(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var categoria = _context.Categorias.Find(id);
            if (categoria != null)
            {
                _context.Categorias.Remove(categoria);
                _context.SaveChanges();
            }
        }

        public List<Categoria> Search(string query) // Método de búsqueda
        {
            return _context.Categorias
                .Where(c => c.NombreCategoria.Contains(query))
                .ToList();
        }
    }
}
