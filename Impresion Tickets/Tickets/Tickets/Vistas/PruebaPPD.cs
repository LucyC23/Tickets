using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using Tickets.Properties;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace Tickets.Vistas
{
    public partial class PruebaPPD : Form
    {
        public PruebaPPD()
        {
            InitializeComponent();
        }
        CrearTicket ticket = new CrearTicket();
        private void PruebaPPD_Load(object sender, EventArgs e)
        {

        }
        private void btnVizualizar_Click(object sender, EventArgs e)
        {
            ppdTicket.Document = Documento;
            ppdTicket.ShowDialog();
        }

        private void Documento_PrintPage(object sender, PrintPageEventArgs e)
        {
            //e.Graphics.DrawString("Producto: " + dgvCompra.CurrentRow.Cells[1].Value );
        }
    }
}
