using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tickets
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            //Creamos una instancia de la clase CrearTicket
            CrearTicket ticket = new CrearTicket();

            //Se comienza a formar el ticket 

            //Datos de los encabezados del ticket
            ticket.textoCentro("MARQUESADA CELULAR S DE R.L DE C.V");
            ticket.TextoIzquierda("Expedido en: Local Zaragoza");
            ticket.TextoIzquierda("Direccion: Zaragoza #239");
            ticket.TextoIzquierda("");
            ticket.textoExtremos("Caja #", "Ticket #");
            ticket.LineaAsterisco();
            //Subtitulos del encabezado
            ticket.TextoIzquierda("");
            ticket.TextoIzquierda("ATENDIDO POR: Vendedor");
            ticket.TextoIzquierda("CLIENTE: 1");
            ticket.TextoIzquierda("");
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
            ticket.agregarArticulos("Celular Samsung", 1, 10);
            ticket.agregarArticulos("Funda para celular", 1, 50);
            ticket.agregarArticulos("Este es un nombre largo del articulo para mostrar como se bajan las lineas", 1, 10);

            //Resumen de la venta
            ticket.LineasIgual();
            ticket.agregarTotales("              TOTAL.......$", 100);
            ticket.TextoIzquierda("");
            ticket.TextoIzquierda("Articulos vendidos");
            ticket.TextoIzquierda("");
            //Texto al final del Ticket
            ticket.TextoDerecha("¡¡Gracias por su compra!!");
            ticket.cortarTicket();
            ticket.imprimirTicket("Microsoft XPS Document Writer");
        }
    }
}
