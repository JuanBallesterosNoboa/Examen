// Archivo: Vistas/frm_menuprincipal.cs

using System;
using System.Windows.Forms;
using Examen.Vistas;

namespace Examen.Vistas
{
    public partial class frm_menuprincipal : Form
    {
        public frm_menuprincipal()
        {
            InitializeComponent();
        }

        private void btn_productos_Click(object sender, EventArgs e)
        {
            // Asume que este botón se llama btn_productos y abre el formulario de inventario
            frm_inventario frm = new frm_inventario();
            frm.Show();
        }

        private void btn_proveedores_Click(object sender, EventArgs e)
        {
            // Asume que este botón se llama btn_proveedores
            frm_proveedor frm = new frm_proveedor();
            frm.Show();
        }

        private void btn_entradas_Click(object sender, EventArgs e)
        {
            // Asume que este botón se llama btn_entradas
            frm_entrada frm = new frm_entrada();
            frm.Show();
        }

        private void btn_reportes_Click(object sender, EventArgs e)
        {
            // Asume que este botón se llama btn_reportes
            frm_reporteStock frm = new frm_reporteStock();
            frm.Show();
        }
    }
}