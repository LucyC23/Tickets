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
using Tickets.Clases;

namespace Tickets.Vistas
{
    public partial class PruebaPPD : Form
    {
        public PruebaPPD()
        {
            InitializeComponent();
        }
        private void PruebaPPD_Load(object sender, EventArgs e)
        {

        }
        private void btnVizualizar_Click(object sender, EventArgs e)
        {
            TIcket a = new TIcket();

            a.anadirLineaCabeza("STARBUCKS COFFEE TAMAULIPAS");
            a.anadirLineaCabeza("EXPEDIDO EN:");
            a.anadirLineaCabeza("AV. TAMAULIPAS NO. 5 LOC. 101");
            a.anadirLineaCabeza("MEXICO, DISTRITO FEDERAL");
            a.anadirLineaCabeza("RFC: CSI-020226-MV4");
            // El metodo AddSubHeaderLine es lo mismo al de AddHeaderLine con la diferencia 
            // de que al final de cada linea agrega una linea punteada "==========" 
            a.anadirLineaSubCabeza("Caja # 1 - Ticket # 1");
            a.anadirLineaSubCabeza("Le atendió: Prueba");
            a.anadirLineaSubCabeza(DateTime.Now.ToShortTimeString()); /* TODO ERROR: Skipped SkippedTokensTrivia */

            // El metodo AddItem requeire 3 parametros, el primero es cantidad, el segundo es la descripcion 
            // del producto y el tercero es el precio 
            a.anadirElementos("1", "Articulo Prueba", "15.00");
            a.anadirElementos("2", "Articulo Prueba", "25.00");
            // El metodo AddTotal requiere 2 parametros, la descripcion del total, y el precio 
            a.anadirTotal("SUBTOTAL", "29.75");
            a.anadirTotal("IVA", "5.25");
            a.anadirTotal("TOTAL", "35.00");
            a.anadirTotal("", "");
            a.anadirTotal("RECIBIDO", "50.00");
            a.anadirTotal("CAMBIO", "15.00");
            a.anadirTotal("", "");
            a.anadirTotal("USTED AHORRO", "0.00");

            // //El metodo AddFooterLine funciona igual que la cabecera 
            a.anadeLineaAlPie("EL CAFE ES NUESTRA PASION...");
            a.anadeLineaAlPie("VIVE LA EXPERIENCIA EN STARBUCKS");
            a.anadeLineaAlPie("GRACIAS POR TU VISITA");
            // //Y por ultimo llamamos al metodo PrintTicket para imprimir el ticket, este metodo necesita un 
            // //parametro de tipo string que debe de ser el nombre de la impresora. 
            a.imprimeTicket("Epson TM-T20 Receipt");
            ppdTicket.ShowDialog();
        }

        private void Documento_PrintPage(object sender, PrintPageEventArgs e)
        {
            
        }

        private void DocumentoAImprimir_PrintPage(object sender, PrintPageEventArgs e)
        {
            //Bitmap bmp = new Bitmap("C:\\Marquesada.jpeg");
            //e.Graphics.DrawImage(bmp, 0, 0);

        }
    }
}
