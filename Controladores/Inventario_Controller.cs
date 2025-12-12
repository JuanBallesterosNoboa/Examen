// Archivo: Controladores/Inventario_Controller.cs

using ControlInventario.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ControlInventario.Controladores
{
    // Hereda las operaciones CRUD para el modelo Inventario_Model (Productos)
    public class Inventario_Controller : BaseRepository<Inventario_Model>
    {
        // Lógica específica y Reportes

        // Reporte de Stock Bajo: Retorna productos con stock igual o menor al umbral.
        public async Task<List<Inventario_Model>> GetProductosStockBajoAsync(int umbral)
        {
            return await _context.Productos
                .Where(p => p.Stock <= umbral)
                .OrderBy(p => p.Stock)
                .ToListAsync();
        }

        public async Task<List<Inventario_Model>> BuscarProducto(string termino)
        {
            // Búsqueda simple por Nombre
            return await _context.Productos
                .Where(p => p.Nombre.Contains(termino))
                .ToListAsync();
        }
    }
}