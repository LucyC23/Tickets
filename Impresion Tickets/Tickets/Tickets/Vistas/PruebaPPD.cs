using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tickets.Vistas
{
    public partial class PruebaPPD : Form
    {
        public PruebaPPD()
        {
            InitializeComponent();
        }
        CrearTicket ticket = new CrearTicket();
        RawPrinterHelper rh = new RawPrinterHelper();
        private void PruebaPPD_Load(object sender, EventArgs e)
        {

        }

        private void btnVizualizar_Click(object sender, EventArgs e)
        {
            ticket.imprimirTicket("Microsoft XPS Document Writer");
            ppdTicket.Document = Documento;
            ppdTicket.ShowDialog();
        }
    }
}
