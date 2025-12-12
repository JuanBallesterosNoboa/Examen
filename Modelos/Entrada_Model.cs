// Archivo: Modelos/Entrada_Model.cs

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examen.Modelos
{
    [Table("Entradas")] // Mapea a la tabla 'Entradas' en la BD
    public class Entrada_Model
    {
        [Key]
        public int EntradaId { get; set; }

        [Required]
        public int ProductoId { get; set; } // FK

        [Required]
        public int ProveedorId { get; set; } // FK

        [Required(ErrorMessage = "La cantidad es obligatoria.")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "El costo es obligatorio.")]
        public decimal Costo { get; set; }

        public DateTime FechaEntrada { get; set; } = DateTime.Now;

        // Propiedades de navegación para las relaciones
        [ForeignKey("ProductoId")]
        public Inventario_Model Producto { get; set; } 

        [ForeignKey("ProveedorId")]
        public Proveedor_Model Proveedor { get; set; } 
    }
}
