namespace Tickets
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnPrueba = new System.Windows.Forms.Button();
            this.dgvCompra = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ppdCompra = new System.Windows.Forms.PrintPreviewDialog();
            this.DocumentoAImprimir = new System.Drawing.Printing.PrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompra)).BeginInit();
            this.SuspendLayout();
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(198, 122);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(79, 26);
            this.btnImprimir.TabIndex = 0;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnPrueba
            // 
            this.btnPrueba.Location = new System.Drawing.Point(202, 165);
            this.btnPrueba.Name = "btnPrueba";
            this.btnPrueba.Size = new System.Drawing.Size(100, 23);
            this.btnPrueba.TabIndex = 1;
            this.btnPrueba.Text = "Previzualizar";
            this.btnPrueba.UseVisualStyleBackColor = true;
            this.btnPrueba.Click += new System.EventHandler(this.btnPrueba_Click);
            // 
            // dgvCompra
            // 
            this.dgvCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCompra.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Producto});
            this.dgvCompra.Location = new System.Drawing.Point(395, 81);
            this.dgvCompra.Name = "dgvCompra";
            this.dgvCompra.RowTemplate.Height = 24;
            this.dgvCompra.Size = new System.Drawing.Size(473, 301);
            this.dgvCompra.TabIndex = 2;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // Producto
            // 
            this.Producto.HeaderText = "Codigo";
            this.Producto.Name = "Producto";
            this.Producto.ReadOnly = true;
            // 
            // ppdCompra
            // 
            this.ppdCompra.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.ppdCompra.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.ppdCompra.ClientSize = new System.Drawing.Size(400, 300);
            this.ppdCompra.Enabled = true;
            this.ppdCompra.Icon = ((System.Drawing.Icon)(resources.GetObject("ppdCompra.Icon")));
            this.ppdCompra.Name = "ppdCompra";
            this.ppdCompra.Visible = false;
            // 
            // DocumentoAImprimir
            // 
            this.DocumentoAImprimir.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.DocumentoAImprimir_PrintPage);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 467);
            this.Controls.Add(this.dgvCompra);
            this.Controls.Add(this.btnPrueba);
            this.Controls.Add(this.btnImprimir);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompra)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnPrueba;
        private System.Windows.Forms.DataGridView dgvCompra;
        private System.Windows.Forms.PrintPreviewDialog ppdCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Drawing.Printing.PrintDocument DocumentoAImprimir;
    }
}

