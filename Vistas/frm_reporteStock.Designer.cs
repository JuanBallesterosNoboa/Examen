namespace ControlInventario.Vistas
{
    partial class frm_reporteStock
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.dgvReporteStock = new System.Windows.Forms.DataGridView();
            this.lblUmbral = new System.Windows.Forms.Label();
            this.txtUmbral = new System.Windows.Forms.TextBox();
            this.btnGenerarReporte = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporteStock)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvReporteStock
            // 
            this.dgvReporteStock.AllowUserToAddRows = false;
            this.dgvReporteStock.AllowUserToDeleteRows = false;
            this.dgvReporteStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReporteStock.Location = new System.Drawing.Point(20, 100);
            this.dgvReporteStock.MultiSelect = false;
            this.dgvReporteStock.Name = "dgvReporteStock";
            this.dgvReporteStock.ReadOnly = true;
            this.dgvReporteStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReporteStock.Size = new System.Drawing.Size(760, 250);
            this.dgvReporteStock.TabIndex = 0;
            // 
            // lblUmbral
            // 
            this.lblUmbral.AutoSize = true;
            this.lblUmbral.Location = new System.Drawing.Point(20, 60);
            this.lblUmbral.Name = "lblUmbral";
            this.lblUmbral.Size = new System.Drawing.Size(108, 13);
            this.lblUmbral.TabIndex = 1;
            this.lblUmbral.Text = "Stock Mínimo (Umbral):";
            // 
            // txtUmbral
            // 
            this.txtUmbral.Location = new System.Drawing.Point(135, 57);
            this.txtUmbral.Name = "txtUmbral";
            this.txtUmbral.Size = new System.Drawing.Size(100, 20);
            this.txtUmbral.TabIndex = 2;
            this.txtUmbral.Text = "10";
            // 
            // btnGenerarReporte
            // 
            this.btnGenerarReporte.Location = new System.Drawing.Point(250, 50);
            this.btnGenerarReporte.Name = "btnGenerarReporte";
            this.btnGenerarReporte.Size = new System.Drawing.Size(120, 30);
            this.btnGenerarReporte.TabIndex = 3;
            this.btnGenerarReporte.Text = "Generar Reporte";
            this.btnGenerarReporte.UseVisualStyleBackColor = true;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(16, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(262, 20);
            this.lblTitulo.TabIndex = 4;
            this.lblTitulo.Text = "Reporte de Productos Bajo Stock";
            // 
            // frm_reporteStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 370);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnGenerarReporte);
            this.Controls.Add(this.txtUmbral);
            this.Controls.Add(this.lblUmbral);
            this.Controls.Add(this.dgvReporteStock);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frm_reporteStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de Stock";
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporteStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvReporteStock;
        private System.Windows.Forms.Label lblUmbral;
        private System.Windows.Forms.TextBox txtUmbral;
        private System.Windows.Forms.Button btnGenerarReporte;
        private System.Windows.Forms.Label lblTitulo;
    }
}