// Archivo: Controladores/Proveedor_Controller.cs

using Examen.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Examen.Controladores
{
    // Hereda las operaciones CRUD para el modelo Proveedor_Model
    public class Proveedor_Controller : BaseRepository<Proveedor_Model>
    {
        // Lógica específica para Proveedores

        public async Task<List<Proveedor_Model>> BuscarProveedor(string termino)
        {
            // Búsqueda simple por Nombre o RUC
            return await _context.Proveedores
                .Where(p => p.Nombre.Contains(termino) || p.RUC.Contains(termino))
                .ToListAsync();
        }
    }
}