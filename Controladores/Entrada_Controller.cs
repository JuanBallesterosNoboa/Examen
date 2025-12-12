// Archivo: Controladores/Entrada_Controller.cs

using ControlInventario.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ControlInventario.Controladores
{
    // Hereda las operaciones CRUD para el modelo Entrada_Model
    public class Entrada_Controller : BaseRepository<Entrada_Model>
    {
        // Lógica para obtener el historial de entradas con detalles (Producto y Proveedor)
        public async Task<List<Entrada_Model>> GetEntradasConDetalleAsync()
        {
            // Usamos .Include() para cargar los objetos de navegación (Eager Loading)
            return await _context.Entradas
                .Include(e => e.Producto)
                .Include(e => e.Proveedor)
                .ToListAsync();
        }
    }
}