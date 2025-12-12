
using Examen.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Examen.Controladores
{
    public class Entrada_Controller : BaseRepository<Entrada_Model>
    {
        public async Task<List<Entrada_Model>> GetEntradasConDetalleAsync()
        {
            return await _context.Entradas
                .Include(e => e.Producto)
                .Include(e => e.Proveedor)
                .ToListAsync();
        }
    }
}