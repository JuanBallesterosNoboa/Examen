
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Examen.Modelos;

namespace Examen.Modelos
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

        public int Stock { get; set; } = 0;

        [Required(ErrorMessage = "El precio es obligatorio.")]
        public decimal PrecioUnitario { get; set; }

        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        public ICollection<Entrada_Model> Entradas { get; set; } = new List<Entrada_Model>();
    }
}