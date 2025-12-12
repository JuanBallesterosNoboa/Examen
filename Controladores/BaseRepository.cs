// Archivo: BaseRepository.cs

using ControlInventario.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlInventario.Controladores
{
    public abstract class BaseRepository<T> where T : class
    {
        protected readonly AppDbContext _context;

        public BaseRepository()
        {
            // Crea una nueva instancia de DbContext para cada operación (simple para Windows Forms)
            _context = new AppDbContext(new DbContextOptions<AppDbContext>());
        }

        // Obtener todos
        public virtual async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        // Obtener por ID
        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        // Agregar
        public virtual async Task<bool> AddAsync(T entity)
        {
            try
            {
                await _context.Set<T>().AddAsync(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Manejo de errores simple
                Console.WriteLine($"Error al agregar: {ex.Message}");
                return false;
            }
        }

        // Actualizar
        public virtual async Task<bool> UpdateAsync(T entity)
        {
            try
            {
                _context.Set<T>().Update(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar: {ex.Message}");
                return false;
            }
        }

        // Eliminar
        public virtual async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var entity = await GetByIdAsync(id);
                if (entity == null) return false;

                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar: {ex.Message}");
                return false;
            }
        }
    }
}