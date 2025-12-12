
using Examen.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Examen.Controladores
{
    public class Proveedor_Controller : BaseRepository<Proveedor_Model>
    {

        public async Task<List<Proveedor_Model>> BuscarProveedor(string termino)
        {
            return await _context.Proveedores
                .Where(p => p.Nombre.Contains(termino) || p.RUC.Contains(termino))
                .ToListAsync();
        }
    }
}