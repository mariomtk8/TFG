using Microsoft.EntityFrameworkCore;
using RecetasRedondas.Models;
using System.Collections.Generic;
using System.Linq;

namespace RecetasRedondas.Data
{
    public class DiaMenuRepository : IDiaMenuRepository
    {
        private readonly RecetasRedondasAppContext _context;
        private readonly IRecetaRepository _recetaRepository;

        public DiaMenuRepository(RecetasRedondasAppContext context, IRecetaRepository recetaRepository)
        {
            _context = context;
            _recetaRepository = recetaRepository;
        }

        public List<DiaMenu> GenerarMenuDia(int usuarioId)
        {
            var recetasFiltradas = _recetaRepository.FiltrarRecetasPorAlergenos(usuarioId);
            var random = new Random();
            var menuDia = new List<DiaMenu>();

            if (recetasFiltradas.Count > 0)
            {
                var recetaComida = recetasFiltradas[random.Next(recetasFiltradas.Count)];
                menuDia.Add(new DiaMenu
                {
                    Fecha = DateTime.Now,
                    IdReceta = recetaComida.IdReceta,
                    TipoComida = true,
                });

                var recetaCena = recetasFiltradas[random.Next(recetasFiltradas.Count)];
                while (recetaCena.IdReceta == recetaComida.IdReceta)
                {
                    recetaCena = recetasFiltradas[random.Next(recetasFiltradas.Count)];
                }
                menuDia.Add(new DiaMenu
                {
                    Fecha = DateTime.Now,
                    IdReceta = recetaCena.IdReceta,
                    TipoComida = false,
                });
            }

            return menuDia;
        }

        public void CrearMenuDiario(DiaMenu diaMenu)
        {
            _context.DiasMenu.Add(diaMenu);
            _context.SaveChanges();
        }

        public List<DiaMenu> GetAll()
        {
            return _context.DiasMenu.ToList();
        }
    }
}
