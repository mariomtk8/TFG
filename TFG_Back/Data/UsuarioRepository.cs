using Microsoft.EntityFrameworkCore;
using RecetasRedondas.Models;
using System.Collections.Generic;
using System.Linq;

namespace RecetasRedondas.Data
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly RecetasRedondasAppContext _context;

        public UsuarioRepository(RecetasRedondasAppContext context)
        {
            _context = context;
        }

        public List<Usuario> GetAll() => _context.Usuarios.ToList();

        public Usuario Get(int id) => _context.Usuarios.Find(id);

        public void Update(Usuario usuario)
        {
            var existingEntity = _context.Usuarios.Find(usuario.IdUsuario);
            if (existingEntity != null)
            {
                _context.Entry(existingEntity).State = EntityState.Detached;
            }

            _context.Entry(usuario).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Add(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                _context.SaveChanges();
            }
        }
    }
}
