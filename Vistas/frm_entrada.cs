// Archivo: Vistas/frm_entrada.cs

using ControlInventario.Modelos;
using ControlInventario.Controladores;
using System.Windows.Forms;
using System;
using System.Linq;

namespace ControlInventario.Vistas
{
    public partial class frm_entrada : Form
    {
        private readonly Entrada_Controller _entradaController = new Entrada_Controller();
        private readonly Inventario_Controller _productoController = new Inventario_Controller();
        private readonly Proveedor_Controller _proveedorController = new Proveedor_Controller();

        public frm_entrada()
        {
            InitializeComponent();
            CargarCombos();
            CargarEntradas();
            btnRegistrarEntrada.Click += btnRegistrarEntrada_Click;
        }

        private async void CargarCombos()
        {
            // Productos
            var productos = await _productoController.GetAllAsync();
            cmbProducto.DataSource = productos;
            cmbProducto.DisplayMember = "Nombre";
            cmbProducto.ValueMember = "ProductoId";

            // Proveedores
            var proveedores = await _proveedorController.GetAllAsync();
            cmbProveedor.DataSource = proveedores;
            cmbProveedor.DisplayMember = "Nombre";
            cmbProveedor.ValueMember = "ProveedorId";
        }

        private async void CargarEntradas()
        {
            var lista = await _entradaController.GetEntradasConDetalleAsync();
            // Proyectar el resultado para mostrar los nombres del Producto y Proveedor
            dgvEntradas.DataSource = lista.Select(e => new
            {
                e.EntradaId,
                Producto = e.Producto.Nombre,
                Proveedor = e.Proveedor.Nombre,
                e.Cantidad,
                e.Costo,
                e.FechaEntrada
            }).ToList();
        }

        private async void btnRegistrarEntrada_Click(object sender, EventArgs e)
        {
            if (cmbProducto.SelectedValue == null || cmbProveedor.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un producto y un proveedor.", "Advertencia");
                return;
            }

            // Validación de cantidades y costos
            if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0 ||
                !decimal.TryParse(txtCosto.Text, out decimal costo) || costo < 0)
            {
                MessageBox.Show("Cantidad debe ser un entero positivo y Costo debe ser un valor monetario válido.", "Advertencia");
                return;
            }

            Entrada_Model nuevaEntrada = new Entrada_Model
            {
                ProductoId = (int)cmbProducto.SelectedValue,
                ProveedorId = (int)cmbProveedor.SelectedValue,
                Cantidad = cantidad,
                Costo = costo
            };

            if (await _entradaController.AddAsync(nuevaEntrada))
            {
                MessageBox.Show("Entrada registrada y Stock actualizado.");
                CargarEntradas();
                // Limpiar campos
                txtCantidad.Text = "1";
                txtCosto.Text = "0.00";
            }
        }
    }
}