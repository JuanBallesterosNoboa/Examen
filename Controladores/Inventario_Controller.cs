// Archivo: Controladores/Inventario_Controller.cs

using Examen.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Examen.Controladores
{
    public class Inventario_Controller : BaseRepository<Inventario_Model>
    {
        public async Task<List<Inventario_Model>> GetProductosStockBajoAsync(int umbral)
        {
            return await _context.Productos
                .Where(p => p.Stock <= umbral)
                .OrderBy(p => p.Stock)
                .ToListAsync();
        }

        public async Task<List<Inventario_Model>> BuscarProducto(string termino)
        {
            return await _context.Productos
                .Where(p => p.Nombre.Contains(termino))
                .ToListAsync();
        }
    }
}