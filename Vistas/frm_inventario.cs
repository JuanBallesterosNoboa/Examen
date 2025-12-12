
using Examen.Modelos;
using Examen.Controladores;
using System.Windows.Forms;
using System;

namespace Examen.Vistas
{
    public partial class frm_inventario : Form
    {
        private readonly Inventario_Controller _controller = new Inventario_Controller();
        private int _productoSeleccionadoId = 0;

        public frm_inventario()
        {
            InitializeComponent();
            CargarProductos();
            // Asignación de eventos
            dgvProductos.CellClick += dgvProductos_CellClick;
            btnGuardarProducto.Click += btnGuardarProducto_Click;
            btnActualizarProducto.Click += btnActualizarProducto_Click;
            btnEliminarProducto.Click += btnEliminarProducto_Click;
            btnNuevoProducto.Click += (s, e) => LimpiarCampos();
        }

        private async void CargarProductos()
        {
            dgvProductos.DataSource = await _controller.GetAllAsync();
        }

        private void LimpiarCampos()
        {
            txtNombreProducto.Text = "";
            txtDescripcion.Text = "";
            txtPrecioUnitario.Text = "0.00";
            _productoSeleccionadoId = 0;
            btnActualizarProducto.Enabled = false;
            btnEliminarProducto.Enabled = false;
            btnGuardarProducto.Enabled = true;
        }

        private async void btnGuardarProducto_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtPrecioUnitario.Text, out decimal precio) || string.IsNullOrWhiteSpace(txtNombreProducto.Text))
            {
                MessageBox.Show("Ingrese un Nombre válido y un Precio Unitario numérico.", "Advertencia");
                return;
            }

            Inventario_Model nuevoProducto = new Inventario_Model
            {
                Nombre = txtNombreProducto.Text,
                Descripcion = txtDescripcion.Text,
                PrecioUnitario = precio,
                Stock = 0 // El Stock empieza en 0 y se actualiza con entradas
            };

            if (await _controller.AddAsync(nuevoProducto))
            {
                MessageBox.Show("Producto guardado exitosamente.");
                CargarProductos();
                LimpiarCampos();
            }
        }

        private async void btnActualizarProducto_Click(object sender, EventArgs e)
        {
            if (_productoSeleccionadoId > 0 && decimal.TryParse(txtPrecioUnitario.Text, out decimal precio))
            {
                Inventario_Model productoAActualizar = await _controller.GetByIdAsync(_productoSeleccionadoId);
                if (productoAActualizar != null)
                {
                    productoAActualizar.Nombre = txtNombreProducto.Text;
                    productoAActualizar.Descripcion = txtDescripcion.Text;
                    productoAActualizar.PrecioUnitario = precio;

                    if (await _controller.UpdateAsync(productoAActualizar))
                    {
                        MessageBox.Show("Producto actualizado exitosamente.");
                        CargarProductos();
                        LimpiarCampos();
                    }
                }
            }
        }

        private async void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            if (_productoSeleccionadoId > 0 && MessageBox.Show("¿Está seguro de eliminar este producto?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (await _controller.DeleteAsync(_productoSeleccionadoId))
                {
                    MessageBox.Show("Producto eliminado.");
                    CargarProductos();
                    LimpiarCampos();
                }
            }
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProductos.Rows[e.RowIndex];

                if (row.Cells["ProductoId"].Value != null)
                {
                    _productoSeleccionadoId = Convert.ToInt32(row.Cells["ProductoId"].Value);
                    txtNombreProducto.Text = row.Cells["Nombre"].Value?.ToString();
                    txtDescripcion.Text = row.Cells["Descripcion"].Value?.ToString();
                    txtPrecioUnitario.Text = row.Cells["PrecioUnitario"].Value?.ToString();

                    btnGuardarProducto.Enabled = false;
                    btnActualizarProducto.Enabled = true;
                    btnEliminarProducto.Enabled = true;
                }
            }
        }
    }
}