// Archivo: Modelos/Inventario_Model.cs

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Examen.Modelos;

namespace ControlInventario.Modelos
{
    [Table("Productos")] // Mapea a la tabla 'Productos' en la BD
    public class Inventario_Model
    {
        [Key]
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100)]
        public string Nombre { get; set; }

        [StringLength(500)]
        public string Descripcion { get; set; }

        // Importante: Este campo es el que actualiza el Trigger de SQL
        public int Stock { get; set; } = 0;

        [Required(ErrorMessage = "El precio es obligatorio.")]
        public decimal PrecioUnitario { get; set; }

        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        // Propiedad de navegación: Lista de entradas asociadas a este producto
        public ICollection<Entrada_Model> Entradas { get; set; } = new List<Entrada_Model>();
    }
}