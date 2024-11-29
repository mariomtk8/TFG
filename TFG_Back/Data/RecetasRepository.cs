using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;
using RecetasRedondas.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RecetasRedondas.Data
{
    public class RecetaRepository : IRecetaRepository
    {
        private readonly RecetasRedondasAppContext _context;

        public RecetaRepository(RecetasRedondasAppContext context)
        {
            _context = context;
        }

        public async Task<(List<Receta> Recetas, int TotalRecetas)> GetRecetasPaginadasAsync(int page, int pageSize)
        {
            int skip = (page - 1) * pageSize;

            var totalRecetas = await _context.Recetas.CountAsync();
            var recetas = await _context.Recetas
                .OrderBy(r => r.IdReceta) // Ordenar de forma predecible
                .Skip(skip)               // Saltar las recetas de las páginas anteriores
                .Take(pageSize)           // Tomar solo las recetas necesarias para la página actual
                .ToListAsync();

            return (recetas, totalRecetas);
        }
        public List<Receta> GetBySearch(string searchTerm)
        {
            return _context.Recetas
                .Where(r => r.Nombre.Contains(searchTerm))
                .ToList();
        }


        public RecetaDTO Get(int id)
        {
            var recetas = _context.Recetas.Include(p => p.Pasos).FirstOrDefault(r => r.IdReceta == id);

            if (recetas is null)
            {
                throw new Exception($"No hay ninguna receta con el ID: {id}");
            }

            var newRecetas = new RecetaDTO
            {
                IdReceta = recetas.IdReceta,
                Nombre = recetas.Nombre,
                Descripcion = recetas.Descripcion,
                Imagen = recetas.Imagen,
                Pasos = recetas.Pasos.Select(paso => new DatosPasoDTO
                {
                    IdPaso = paso.IdPaso,
                    IdReceta = paso.IdReceta,
                    Numero = paso.Numero,
                    Descripcion = paso.Descripcion,
                    ImagenUrl = paso.ImagenUrl
                }).ToList(),
                EsVegano = recetas.EsVegano ?? false, // valor predeterminado false si es null
                FechaCreacion = recetas.FechaCreacion ?? DateTime.Now, // valor predeterminado de la fecha actual si es null
                NivelDificultad = recetas.NivelDificultad ?? 0m, // valor predeterminado de 0 si es null
                PromedioVotos = recetas.PromedioVotos,
                TiempoPreparacion = recetas.TiempoPreparacion ?? 0,
                TemaCocina = recetas.TemaCocina,
                IdCategoria = recetas.IdCategoria,
            };

            return newRecetas;
        }

        public List<Receta> GetByCategoria(int idCategoria)
        {
            return _context.Recetas
                .Where(r => r.IdCategoria == idCategoria)
                .ToList();
        }

        public void Update(RecetaUpdateDTO receta)
        {
            var existingEntity = _context.Recetas.Include(r => r.Pasos).FirstOrDefault(r => r.IdReceta == receta.IdReceta);
            if (existingEntity is null)
            {
                throw new Exception("No se encontró la receta a actualizar");
            }

            existingEntity.Nombre = receta.Nombre;
            existingEntity.Descripcion = receta.Descripcion;
            existingEntity.Imagen = receta.Imagen;
            existingEntity.EsVegano = receta.EsVegano;
            existingEntity.FechaCreacion = receta.FechaCreacion;
            existingEntity.NivelDificultad = receta.NivelDificultad;
            existingEntity.TiempoPreparacion = receta.TiempoPreparacion;
            existingEntity.IdCategoria = receta.IdCategoria;



            _context.SaveChanges();
        }

        public void Add(Receta receta)
        {
            _context.Recetas.Add(receta);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var receta = _context.Recetas.Include(r => r.Pasos).FirstOrDefault(r => r.IdReceta == id);
            if (receta != null)
            {
                _context.Pasos.RemoveRange(receta.Pasos); // Eliminar pasos relacionados
                _context.Recetas.Remove(receta);
                _context.SaveChanges();
            }
        }

        //métodos para gestionar pasos

        public IEnumerable<DatosPasoDTO> GetPasosByRecetaId(int recetaId)
        {
            var receta = _context.Recetas.Include(r => r.Pasos).FirstOrDefault(r => r.IdReceta == recetaId);

            if (receta != null)
            {
                return receta.Pasos.Select(p => new DatosPasoDTO
                {
                    IdPaso = p.IdPaso,
                    IdReceta = p.IdReceta,
                    Numero = p.Numero,
                    Descripcion = p.Descripcion,
                    ImagenUrl = p.ImagenUrl
                }).ToList();
            }

            return new List<DatosPasoDTO>();
        }

        public void AddPaso(int recetaId, DatosPasoDTO paso)
        {
            var receta = _context.Recetas.Include(r => r.Pasos).FirstOrDefault(r => r.IdReceta == recetaId);
            if (receta != null)
            {
                var DatosPaso = new Paso
                {
                    IdReceta = paso.IdReceta,
                    Numero = paso.Numero,
                    Descripcion = paso.Descripcion,
                    ImagenUrl = paso.ImagenUrl
                };
                receta.Pasos.Add(DatosPaso);
                _context.SaveChanges();
            }
        }

        public void UpdatePaso(int recetaId, DatosPasoDTO paso)
        {
            var existingPaso = _context.Pasos.FirstOrDefault(p => p.IdPaso == paso.IdPaso && p.IdReceta == recetaId);
            if (existingPaso != null)
            {
                existingPaso.Numero = paso.Numero;
                existingPaso.Descripcion = paso.Descripcion;
                existingPaso.ImagenUrl = paso.ImagenUrl;

                _context.Pasos.Update(existingPaso);
                _context.SaveChanges();
            }
        }

        public void DeletePaso(int pasoId)
        {
            var paso = _context.Pasos.FirstOrDefault(p => p.IdPaso == pasoId);
            if (paso != null)
            {
                _context.Pasos.Remove(paso);
                _context.SaveChanges();
            }
        }

        public List<RecetasMDTO> FiltrarRecetas(int usuarioId)
{
    
    var alergenosUsuario = _context.Alergenos
        .Where(au => au.IdUsuario == usuarioId)
        .Select(au => au.IdIngrediente)
        .ToList();

    var categoriasUsuario = _context.UsuarioCategorias
        .Where(uc => uc.IdUsuario == usuarioId)
        .Select(uc => uc.IdCategoria)
        .ToList();
        
    var recetasFiltradas = _context.Recetas
        .Where(receta => !receta.recetaIngredientes
            .Any(ri => alergenosUsuario.Contains(ri.IdIngrediente)) && 
            categoriasUsuario.Contains(receta.IdCategoria)) 
        .Include(r => r.Pasos) 
        .ToList();

    // Mapear las recetas a RecetasMDTO
    var newRecetas = recetasFiltradas.Select(receta => new RecetasMDTO
    {
        IdReceta = receta.IdReceta,
        Nombre = receta.Nombre,
    }).ToList();

    return newRecetas;
}



        public List<Receta> FiltrarPorNivelDificultad(bool ascendente)
        {
            var query = _context.Recetas.AsQueryable();

            return ascendente ? 
                query.OrderBy(r => r.NivelDificultad).ToList() : 
                query.OrderByDescending(r => r.NivelDificultad).ToList();
        }

        public List<Receta> FiltrarPorTiempoPreparacion(bool ascendente)
        {
            var query = _context.Recetas.AsQueryable();

            return ascendente ? 
                query.OrderBy(r => r.TiempoPreparacion).ToList() : 
                query.OrderByDescending(r => r.TiempoPreparacion).ToList();
        }
        public List<Receta> FiltrarPorTemaCocina(string temaCocina)
        {
            return _context.Recetas
                .Where(r => r.TemaCocina != null && r.TemaCocina.Contains(temaCocina))
                .ToList();
        }

    }
}
