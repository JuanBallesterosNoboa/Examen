namespace Examen.Vistas
{
    partial class frm_menuprincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_productos = new System.Windows.Forms.Button();
            this.btn_proveedores = new System.Windows.Forms.Button();
            this.btn_entradas = new System.Windows.Forms.Button();
            this.btn_reportes = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_productos
            // 
            this.btn_productos.Location = new System.Drawing.Point(50, 80);
            this.btn_productos.Name = "btn_productos";
            this.btn_productos.Size = new System.Drawing.Size(150, 50);
            this.btn_productos.TabIndex = 0;
            this.btn_productos.Text = "Gestión de Productos";
            this.btn_productos.UseVisualStyleBackColor = true;
            this.btn_productos.Click += new System.EventHandler(this.btn_productos_Click);
            // 
            // btn_proveedores
            // 
            this.btn_proveedores.Location = new System.Drawing.Point(50, 150);
            this.btn_proveedores.Name = "btn_proveedores";
            this.btn_proveedores.Size = new System.Drawing.Size(150, 50);
            this.btn_proveedores.TabIndex = 1;
            this.btn_proveedores.Text = "Gestión de Proveedores";
            this.btn_proveedores.UseVisualStyleBackColor = true;
            this.btn_proveedores.Click += new System.EventHandler(this.btn_proveedores_Click);
            // 
            // btn_entradas
            // 
            this.btn_entradas.Location = new System.Drawing.Point(220, 80);
            this.btn_entradas.Name = "btn_entradas";
            this.btn_entradas.Size = new System.Drawing.Size(150, 50);
            this.btn_entradas.TabIndex = 2;
            this.btn_entradas.Text = "Registro de Entradas";
            this.btn_entradas.UseVisualStyleBackColor = true;
            this.btn_entradas.Click += new System.EventHandler(this.btn_entradas_Click);
            // 
            // btn_reportes
            // 
            this.btn_reportes.Location = new System.Drawing.Point(220, 150);
            this.btn_reportes.Name = "btn_reportes";
            this.btn_reportes.Size = new System.Drawing.Size(150, 50);
            this.btn_reportes.TabIndex = 3;
            this.btn_reportes.Text = "Reporte de Stock Bajo";
            this.btn_reportes.UseVisualStyleBackColor = true;
            this.btn_reportes.Click += new System.EventHandler(this.btn_reportes_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(70, 25);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(286, 24);
            this.lblTitulo.TabIndex = 4;
            this.lblTitulo.Text = "SISTEMA DE INVENTARIO";
            // 
            // frm_menuprincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 230);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btn_reportes);
            this.Controls.Add(this.btn_entradas);
            this.Controls.Add(this.btn_proveedores);
            this.Controls.Add(this.btn_productos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frm_menuprincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menú Principal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_productos;
        private System.Windows.Forms.Button btn_proveedores;
        private System.Windows.Forms.Button btn_entradas;
        private System.Windows.Forms.Button btn_reportes;
        private System.Windows.Forms.Label lblTitulo;
    }
}