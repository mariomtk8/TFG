using Microsoft.EntityFrameworkCore;
using RecetasRedondas.Models;
using System.Collections.Generic;
using System.Linq;

namespace RecetasRedondas.Data
{
    public class MenuSemanalRepository : IMenuSemanalRepository
    {
        private readonly RecetasRedondasAppContext _context;
        private readonly IRecetaRepository _recetaRepository;

        public MenuSemanalRepository(RecetasRedondasAppContext context, IRecetaRepository recetaRepository)
        {
            _context = context;
            _recetaRepository = recetaRepository;
        }

        // Generar menú semanal con 14 recetas (7 días, 2 recetas por día: comida y cena)
        public List<MenuSemanal> GenerarMenuSemana(int usuarioId)
        {
            var recetasFiltradas = _recetaRepository.FiltrarRecetasPorAlergenos(usuarioId);
            var random = new Random();
            var menuSemana = new List<MenuSemanal>();

            if (recetasFiltradas.Count > 0)
            {
                var recetasUsadas = new HashSet<int>();

                for (int dia = 0; dia < 7; dia++) // Generar 7 días de menús
                {
                    // Generar receta para la comida (TipoComida = true)
                    var recetaComida = recetasFiltradas[random.Next(recetasFiltradas.Count)];
                    while (recetasUsadas.Contains(recetaComida.IdReceta))
                    {
                        recetaComida = recetasFiltradas[random.Next(recetasFiltradas.Count)];
                    }
                    recetasUsadas.Add(recetaComida.IdReceta);
                    menuSemana.Add(new MenuSemanal
                    {
                        FechaInicio = DateTime.Now.AddDays(dia), // Fecha correspondiente al día del menú
                        IdReceta = recetaComida.IdReceta,
                        IdUsuario = usuarioId,
                        TipoComida = true, // Comida
                    });

                    // Generar receta para la cena (TipoComida = false)
                    var recetaCena = recetasFiltradas[random.Next(recetasFiltradas.Count)];
                    while (recetasUsadas.Contains(recetaCena.IdReceta) || recetaCena.IdReceta == recetaComida.IdReceta)
                    {
                        recetaCena = recetasFiltradas[random.Next(recetasFiltradas.Count)];
                    }
                    recetasUsadas.Add(recetaCena.IdReceta);
                    menuSemana.Add(new MenuSemanal
                    {
                        FechaInicio = DateTime.Now.AddDays(dia), // Fecha correspondiente al día del menú
                        IdReceta = recetaCena.IdReceta,
                        IdUsuario = usuarioId,
                        TipoComida = false, // Cena
                    });
                }
            }

            return menuSemana;
        }

        // Crear menú semanal
        public void CrearMenuSemanal(List<MenuSemanal> menuSemanal)
        {
            _context.MenusSemanales.AddRange(menuSemanal);
            _context.SaveChanges();
        }

        // Obtener menús semanales por IdUsuario
        public List<MenuSemanal> GetMenuSemanalByUsuario(int usuarioId)
        {
            return _context.MenusSemanales
                .Where(m => m.IdUsuario == usuarioId)
                .Include(m => m.Receta) // Carga la receta asociada
                .ToList();
        }

        // Regenerar menú semanal (PUT) por IdUsuario
        public void RegenerarMenuSemanal(int usuarioId)
        {
            var menusExistentes = _context.MenusSemanales
                .Where(m => m.IdUsuario == usuarioId)
                .ToList();

            _context.MenusSemanales.RemoveRange(menusExistentes);
            _context.SaveChanges();

            var nuevoMenu = GenerarMenuSemana(usuarioId);
            CrearMenuSemanal(nuevoMenu);
        }

        // Eliminar menú semanal por IdMenuSemanal
        public void DeleteMenuSemanal(int idMenuSemanal)
        {
            var menuSemanal = _context.MenusSemanales.Find(idMenuSemanal);
            if (menuSemanal != null)
            {
                _context.MenusSemanales.Remove(menuSemanal);
                _context.SaveChanges();
            }
        }
    }
}
