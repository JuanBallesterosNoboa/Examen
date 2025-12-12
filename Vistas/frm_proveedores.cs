// Archivo: Vistas/frm_proveedor.cs

using ControlInventario.Modelos;
using ControlInventario.Controladores;
using System.Windows.Forms;
using System;

namespace ControlInventario.Vistas
{
    public partial class frm_proveedor : Form
    {
        private readonly Proveedor_Controller _controller = new Proveedor_Controller();
        private int _proveedorSeleccionadoId = 0;

        public frm_proveedor()
        {
            InitializeComponent();
            CargarProveedores();
            // Asignación de eventos (Asegúrate de que tus botones estén conectados a estos métodos)
            dgvProveedores.CellClick += dgvProveedores_CellClick;
            btnGuardar.Click += btnGuardar_Click;
            btnActualizar.Click += btnActualizar_Click;
            btnEliminar.Click += btnEliminar_Click;
            btnNuevo.Click += (s, e) => LimpiarCampos();
            btnActualizar.Enabled = false; // Deshabilitar inicialmente
            btnEliminar.Enabled = false; // Deshabilitar inicialmente
        }

        private async void CargarProveedores()
        {
            dgvProveedores.DataSource = await _controller.GetAllAsync();
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtRUC.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            _proveedorSeleccionadoId = 0;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
            btnGuardar.Enabled = true;
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validación básica de campos requeridos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtRUC.Text))
            {
                MessageBox.Show("El Nombre y el RUC son obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Proveedor_Model nuevoProveedor = new Proveedor_Model
            {
                Nombre = txtNombre.Text,
                RUC = txtRUC.Text,
                Direccion = txtDireccion.Text,
                Telefono = txtTelefono.Text
            };

            if (await _controller.AddAsync(nuevoProveedor))
            {
                MessageBox.Show("Proveedor guardado exitosamente.");
                CargarProveedores();
                LimpiarCampos();
            }
            // El manejo de errores (ej. RUC duplicado) ya está en BaseRepository
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            if (_proveedorSeleccionadoId > 0)
            {
                Proveedor_Model proveedorAActualizar = await _controller.GetByIdAsync(_proveedorSeleccionadoId);
                if (proveedorAActualizar != null)
                {
                    proveedorAActualizar.Nombre = txtNombre.Text;
                    proveedorAActualizar.RUC = txtRUC.Text;
                    proveedorAActualizar.Direccion = txtDireccion.Text;
                    proveedorAActualizar.Telefono = txtTelefono.Text;

                    if (await _controller.UpdateAsync(proveedorAActualizar))
                    {
                        MessageBox.Show("Proveedor actualizado exitosamente.");
                        CargarProveedores();
                        LimpiarCampos();
                    }
                }
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_proveedorSeleccionadoId > 0 && MessageBox.Show("¿Está seguro de eliminar este proveedor?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (await _controller.DeleteAsync(_proveedorSeleccionadoId))
                {
                    MessageBox.Show("Proveedor eliminado.");
                    CargarProveedores();
                    LimpiarCampos();
                }
            }
        }

        private void dgvProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProveedores.Rows[e.RowIndex];

                // Asegurar que el ID es válido antes de usarlo
                if (row.Cells["ProveedorId"].Value != null)
                {
                    _proveedorSeleccionadoId = Convert.ToInt32(row.Cells["ProveedorId"].Value);
                    txtNombre.Text = row.Cells["Nombre"].Value?.ToString();
                    txtRUC.Text = row.Cells["RUC"].Value?.ToString();
                    txtDireccion.Text = row.Cells["Direccion"].Value?.ToString();
                    txtTelefono.Text = row.Cells["Telefono"].Value?.ToString();

                    btnGuardar.Enabled = false;
                    btnActualizar.Enabled = true;
                    btnEliminar.Enabled = true;
                }
            }
        }
    }
}