using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;    
using Examen.Modelos;   

namespace Examen.Modelos
{
    [Table("Proveedores")] // Mapea a la tabla 'Proveedores' en la BD
    public class Proveedor_Model
    {
        [Key]
        public int ProveedorId { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El RUC es obligatorio.")]
        [StringLength(13)]
        public string RUC { get; set; }

        [StringLength(200)]
        public string Direccion { get; set; }

        [StringLength(15)]
        public string Telefono { get; set; }

        // Propiedad de navegación: Lista de entradas asociadas a este proveedor
        public ICollection<Entrada_Model> Entradas { get; set; } = new List<Entrada_Model>();
    }
}