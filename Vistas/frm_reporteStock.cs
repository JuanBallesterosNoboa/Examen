using Examen.Controladores;
using System.Windows.Forms;
using System;

namespace Examen.Vistas
{
    public partial class frm_reporteStock : Form
    {
        private readonly Inventario_Controller _productoController = new Inventario_Controller();

        public frm_reporteStock()
        {
            InitializeComponent();
            btnGenerarReporte.Click += btnGenerarReporte_Click;
        }

        private async void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtUmbral.Text, out int umbral) || umbral < 0)
            {
                MessageBox.Show("El umbral debe ser un número entero positivo.", "Error de Umbral");
                return;
            }

            var productosBajoStock = await _productoController.GetProductosStockBajoAsync(umbral);

            dgvReporteStock.DataSource = productosBajoStock;

            if (productosBajoStock.Count == 0)
            {
                MessageBox.Show($"Ningún producto tiene un stock igual o menor a {umbral}.", "Reporte de Stock");
            }
        }
    }
}