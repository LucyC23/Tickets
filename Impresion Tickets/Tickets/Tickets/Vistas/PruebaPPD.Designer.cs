namespace Tickets.Vistas
{
    partial class PruebaPPD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PruebaPPD));
            this.ppdTicket = new System.Windows.Forms.PrintPreviewDialog();
            this.btnVizualizar = new System.Windows.Forms.Button();
            this.Documento = new System.Drawing.Printing.PrintDocument();
            this.SuspendLayout();
            // 
            // ppdTicket
            // 
            this.ppdTicket.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.ppdTicket.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.ppdTicket.ClientSize = new System.Drawing.Size(400, 300);
            this.ppdTicket.Enabled = true;
            this.ppdTicket.Icon = ((System.Drawing.Icon)(resources.GetObject("ppdTicket.Icon")));
            this.ppdTicket.Name = "ppdTicket";
            this.ppdTicket.Visible = false;
            // 
            // btnVizualizar
            // 
            this.btnVizualizar.Location = new System.Drawing.Point(297, 213);
            this.btnVizualizar.Name = "btnVizualizar";
            this.btnVizualizar.Size = new System.Drawing.Size(84, 28);
            this.btnVizualizar.TabIndex = 0;
            this.btnVizualizar.Text = "Visualizar";
            this.btnVizualizar.UseVisualStyleBackColor = true;
            this.btnVizualizar.Click += new System.EventHandler(this.btnVizualizar_Click);
            // 
            // PruebaPPD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 457);
            this.Controls.Add(this.btnVizualizar);
            this.Name = "PruebaPPD";
            this.Text = "PruebaPPD";
            this.Load += new System.EventHandler(this.PruebaPPD_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PrintPreviewDialog ppdTicket;
        private System.Windows.Forms.Button btnVizualizar;
        private System.Drawing.Printing.PrintDocument Documento;
    }
}