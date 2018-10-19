using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using Tickets.Clases;
using System.Collections;

namespace Tickets
{
    public partial class Form1 : Form
    {
        public static object TicketsTemplateFactory { get; private set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            TIcket ticket = new TIcket();
            ticket.TextoDerecha("MARQUESADA CELULAR S DE R.L DE C.V");
            ticket.TextoDerecha("Expedido en: ");
            ticket.TextoDerecha("Direccion: Zaragoza #239");
            ticket.TextoIzquierda("Ticket #");
            ticket.LineaAsterisco();
            //Subtitulos del encabezadO
            ticket.textoCentro("ATENDIDO POR: Vendedor");
            ticket.textoCentro("CLIENTE: 1");
            ticket.LineaAsterisco();
            ticket.textoExtremos("Fecha: " + DateTime.Now.ToShortDateString(), "Hora: " + DateTime.Now.ToLongTimeString());
            ticket.LineaAsterisco();
            //Articulos a vender 
            ticket.encabezadoVenta();
            ticket.LineaAsterisco();
            //Para agregar los articulos que se tienen en un datagridview
            //foreach (DataGridViewRow item in #NombredelDGVdelacompra)
            // {
            // ticket.agregarArticulos(//Posicion de cada uno de los elementos del articulo);
            // }
            ticket.agregarArticulos("ESTO ES UN EJEMPLO DE UN TICKET DE VENTA EN C#", 11, 100);
            //Resumen de la venta
            ticket.LineasIgual();
            ticket.agregarTotales("TOTAL.......$", 100);
            //Texto al final del Ticket
            ticket.TextoDerecha("Gracias por su compra");
            ticket.TextoIzquierda("");
            ticket.imprimeTicket("Microsoft XPS Document Writer");
        }
      

        }
        //private void btnPrueba_Click(object sender, EventArgs e)
        //{
        //    PrintPreviewDialog ppd = new PrintPreviewDialog();
        //    ppd.ClientSize = new Size(400,300);
        //    ppd.Document = DocumentoAImprimir;
        //    ppd.ShowDialog();
        //}
       
    }

