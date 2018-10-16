using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.Clases
{
    class TIcket
    {
        #region Variables
        protected ArrayList LineasDeLaSubCabeza = new ArrayList();
        protected ArrayList LineasDeLaCabeza = new ArrayList();
        protected ArrayList Elementos = new ArrayList();
        protected ArrayList Totales = new ArrayList();
        protected ArrayList LineasDelPie = new ArrayList();
        protected int contador = 0;
        protected int imageHeight = 0;
        protected double margenIzquierdo = 10;
        protected double margenSuperior = 13;
        protected Image headerImagep;
        protected Bitmap btm;
        protected int caracteresMaximos = 35;
        protected int caracteresMaximosDescripcion = 20;
        protected string nombreDeLaFuente = "Lucida Console";
        protected int tamanoDeLaFuente = 9;
        protected Font fuenteImpresa;
        protected SolidBrush colorDeLaFuente = new SolidBrush(Color.Black);
        protected Graphics gfx;
        protected String cadenaPorEscribirEnLinea = "";
        protected PrintDocument DocumentoAImprimir = new PrintDocument();
        #endregion

        #region Constructores
        //Constructores
        public void setHeaderImagep(Image value)
        {
            if (headerImagep == value)
            {
                headerImagep = value;
            }
        }
        public Image GetHeaderImagep()
        {
            return headerImagep;
        }
        public void setCaracteresMaximos(int value)
        {
            if (caracteresMaximos == value)
            {
                caracteresMaximos = value;
            }
        }
        public int getCaracteresMaximos()
        {
            return caracteresMaximos;
        }
        public void setCaracteresMaximosDescripcion(int value)
        {
            if (caracteresMaximosDescripcion == value)
            {
                caracteresMaximosDescripcion = value;
            }
        }
        public int getCaracteresMaximosDescripcion()
        {
            return caracteresMaximosDescripcion;
        }
        public void setTamanoLetra(int value)
        {
            if (tamanoDeLaFuente == value)
            {
                tamanoDeLaFuente = value;
            }
        }
        public int getTamañoLetra()
        {
            return tamanoDeLaFuente;
        }
        public void setNombreLetra(string value)
        {
            if (nombreDeLaFuente == value)
            {
                nombreDeLaFuente = value;
            }
        }
        public string getNombreLetra()
        {
            return nombreDeLaFuente;
        }
        #endregion

        #region Estructura Ticket
        public void anadirLineaCabeza(string line)
        {
            LineasDeLaCabeza.Add(line);
        }
        public void anadirLineaSubCabeza(string line)
        {
            LineasDeLaSubCabeza.Add(line);
        }
        public void anadirElementos(string cantidad, string elemento, string precio)
        {

            OrdenarElementos nuevoElemento = new OrdenarElementos(' ');
            Elementos.Add(nuevoElemento.generarElemento(cantidad, elemento, precio));
        }
        public void anadirTotal(string nombre, string precio)
        {
            ordenarTotal nuevoTotal = new ordenarTotal(' ');
            Totales.Add(nuevoTotal.generarTotal(nombre, precio));
        }
        public void anadeLineaAlPie(string linea)
        {
            LineasDelPie.Add(linea);
        }
        private string AlineaTextoaLaDerecha(int izquierda)
        {
            string espacios = "";
            int spaces = caracteresMaximos - izquierda;
            for (int x = 0; x < spaces; espacios += "")
            {

            }
            return espacios;
        }
        private string DottedLine()
        {
            string dotted = "";
            for (int x = 0; x < caracteresMaximos; dotted += "=")
            {

            }
            return dotted;
        }

        #endregion


        #region Metodo para crear ticket
        private double renglon()
        {
            return margenSuperior + (contador * fuenteImpresa.GetHeight(gfx) + imageHeight);
        }
        private void DrawImage()
        {
            if (headerImagep.Width > 0)
            {
                try
                {
                    gfx.DrawImage(headerImagep, new Point(Convert.ToInt32(margenIzquierdo), Convert.ToInt32(renglon())));
                    double height = (headerImagep.Height / (double)58) * 15;
                    imageHeight = Convert.ToInt32(Math.Round(height) + 3);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        private void DibujaLaCabecera()
        {
            foreach (string Cabecera in LineasDeLaCabeza)
            {
                if ((Cabecera.Length > caracteresMaximos))
                {
                    int CaracterActual = 0;
                    int LongitudDeCabecera = Cabecera.Length;

                    while ((LongitudDeCabecera > caracteresMaximos))
                    {
                        cadenaPorEscribirEnLinea = Cabecera.Substring(CaracterActual, caracteresMaximos);
                        gfx.DrawString(cadenaPorEscribirEnLinea, fuenteImpresa, colorDeLaFuente, Convert.ToInt32(margenIzquierdo), Convert.ToInt32(renglon()), new StringFormat());
                        contador += 1;
                        CaracterActual += caracteresMaximos;
                        LongitudDeCabecera -= caracteresMaximos;
                    }

                    cadenaPorEscribirEnLinea = Cabecera;
                    gfx.DrawString(cadenaPorEscribirEnLinea.Substring(CaracterActual, cadenaPorEscribirEnLinea.Length - CaracterActual), fuenteImpresa, colorDeLaFuente, Convert.ToInt32(margenIzquierdo), Convert.ToInt32(renglon()), new StringFormat());
                    contador += 1;
                }
                else
                {
                    cadenaPorEscribirEnLinea = Cabecera;
                    gfx.DrawString(cadenaPorEscribirEnLinea, fuenteImpresa, colorDeLaFuente, Convert.ToInt32(margenIzquierdo), Convert.ToInt32(renglon()), new StringFormat());

                    contador += 1;
                }
            }

            dibujaEspacio();
        }
        private void DibujaLaSubCabecera()
        {
            foreach (string SubCabecera in LineasDeLaSubCabeza)
            {
                if ((SubCabecera.Length > caracteresMaximos))
                {
                    int CaracterActual = 0;
                    int LongitudSubcabecera = SubCabecera.Length;

                    while ((LongitudSubcabecera > caracteresMaximos))
                    {
                        cadenaPorEscribirEnLinea = SubCabecera;
                        gfx.DrawString(cadenaPorEscribirEnLinea.Substring(CaracterActual, caracteresMaximos), fuenteImpresa, colorDeLaFuente, Convert.ToInt32(margenIzquierdo), Convert.ToInt32(renglon()), new StringFormat());

                        contador += 1;
                        CaracterActual += caracteresMaximos;
                        LongitudSubcabecera -= caracteresMaximos;
                    }

                    cadenaPorEscribirEnLinea = SubCabecera;
                    gfx.DrawString(cadenaPorEscribirEnLinea.Substring(CaracterActual, cadenaPorEscribirEnLinea.Length - CaracterActual), fuenteImpresa, colorDeLaFuente, Convert.ToInt32(margenIzquierdo), Convert.ToInt32(renglon()), new StringFormat());
                    contador += 1;
                }
                else
                {
                    cadenaPorEscribirEnLinea = SubCabecera;

                    gfx.DrawString(cadenaPorEscribirEnLinea, fuenteImpresa, colorDeLaFuente, Convert.ToInt32(margenIzquierdo), Convert.ToInt32(renglon()), new StringFormat());

                    contador += 1;

                    cadenaPorEscribirEnLinea = DottedLine();

                    gfx.DrawString(cadenaPorEscribirEnLinea, fuenteImpresa, colorDeLaFuente, Convert.ToInt32(margenIzquierdo), Convert.ToInt32(renglon()), new StringFormat());

                    contador += 1;
                }
            }

            dibujaEspacio();
        }
        private void DibujarElementos()
        {
            OrdenarElementos ordenElemento = new OrdenarElementos(' ');
            gfx.DrawString("CANT DESCRIPCION IMPORTE", fuenteImpresa, colorDeLaFuente, Convert.ToInt32(margenIzquierdo), Convert.ToInt32(renglon()), new StringFormat());

            contador += 1;
            dibujaEspacio();

            foreach (string Elemento in Elementos)
            {
                cadenaPorEscribirEnLinea = ordenElemento.obtenerCantidadDeElementos(Elemento);

                gfx.DrawString(cadenaPorEscribirEnLinea, fuenteImpresa, colorDeLaFuente, Convert.ToInt32(margenIzquierdo), Convert.ToInt32(renglon()), new StringFormat());
                cadenaPorEscribirEnLinea = ordenElemento.obtenerPrecioElemento(Elemento);
                cadenaPorEscribirEnLinea = AlineaTextoaLaDerecha(cadenaPorEscribirEnLinea.Length) + cadenaPorEscribirEnLinea;

                gfx.DrawString(cadenaPorEscribirEnLinea, fuenteImpresa, colorDeLaFuente, Convert.ToInt32(margenIzquierdo), Convert.ToInt32(renglon()), new StringFormat());

                string nombre = ordenElemento.obtenerNombreElemento(Elemento);

                margenIzquierdo = 10;
                if (nombre.Length > caracteresMaximosDescripcion)
                {
                    int caracterActual = 0;
                    int longitudElemento = nombre.Length;

                    while (longitudElemento > caracteresMaximosDescripcion)
                    {
                        cadenaPorEscribirEnLinea = ordenElemento.obtenerNombreElemento(Elemento);
                        gfx.DrawString("" + cadenaPorEscribirEnLinea.Substring(caracterActual, caracteresMaximos), fuenteImpresa, colorDeLaFuente, Convert.ToInt32(margenIzquierdo), Convert.ToInt32(renglon()), new StringFormat());

                        contador += 1;
                        caracterActual += caracteresMaximosDescripcion;
                        longitudElemento -= caracteresMaximosDescripcion;
                    }
                    cadenaPorEscribirEnLinea = ordenElemento.obtenerNombreElemento(Elemento);
                    gfx.DrawString("" + cadenaPorEscribirEnLinea.Substring(caracterActual, cadenaPorEscribirEnLinea.Length - caracterActual), fuenteImpresa, colorDeLaFuente, Convert.ToInt32(margenIzquierdo), Convert.ToInt32(renglon() + 10), new StringFormat());
                    contador += 1;
                }
                else
                {
                    gfx.DrawString("" + ordenElemento.obtenerNombreElemento(Elemento), fuenteImpresa, colorDeLaFuente, Convert.ToInt32(margenIzquierdo), Convert.ToInt32(renglon()), new StringFormat());

                    contador += 1;
                }
                margenIzquierdo = 10;
                dibujaEspacio();
                cadenaPorEscribirEnLinea = DottedLine();

                gfx.DrawString(cadenaPorEscribirEnLinea, fuenteImpresa, colorDeLaFuente, Convert.ToInt32(margenIzquierdo), Convert.ToInt32(renglon()), new StringFormat());

                contador += 1;
                dibujaEspacio();
            }
        }
        private void DibujarTotales()
        {
            ordenarTotal ordTot = new ordenarTotal(' ');
            foreach (string total in Totales)
            {
                cadenaPorEscribirEnLinea = ordTot.obtenerTotalCantidad(total);
                cadenaPorEscribirEnLinea = AlineaTextoaLaDerecha(cadenaPorEscribirEnLinea.Length) + cadenaPorEscribirEnLinea;

                gfx.DrawString(cadenaPorEscribirEnLinea, fuenteImpresa, colorDeLaFuente, Convert.ToInt32(margenIzquierdo), Convert.ToInt32(renglon()), new StringFormat());
                margenIzquierdo = 10;

                cadenaPorEscribirEnLinea = "" + ordTot.obtenerTotalNombre(total);
                gfx.DrawString(cadenaPorEscribirEnLinea, fuenteImpresa, colorDeLaFuente, Convert.ToInt32(margenIzquierdo), Convert.ToInt32(renglon()), new StringFormat());
                contador += 1;
                margenIzquierdo = 10;
                dibujaEspacio();
                dibujaEspacio();
            }
        }
        private void dibujarPieDePagina()
        {
            foreach (string PieDePagina in LineasDelPie)
            {
                if (PieDePagina.Length > caracteresMaximos)
                {
                    int currentChar = 0;
                    int longitudPieDePagina = PieDePagina.Length;

                    while (longitudPieDePagina > caracteresMaximos)
                    {
                        cadenaPorEscribirEnLinea = PieDePagina;
                        gfx.DrawString(cadenaPorEscribirEnLinea.Substring(currentChar, caracteresMaximos), fuenteImpresa, colorDeLaFuente, Convert.ToInt32(margenIzquierdo), Convert.ToInt32(renglon()), new StringFormat());

                        contador += 1;
                        currentChar += caracteresMaximos;
                        longitudPieDePagina -= caracteresMaximos;
                    }
                    cadenaPorEscribirEnLinea = PieDePagina;
                    gfx.DrawString(cadenaPorEscribirEnLinea.Substring(currentChar, cadenaPorEscribirEnLinea.Length - currentChar), fuenteImpresa, colorDeLaFuente, Convert.ToInt32(margenIzquierdo), Convert.ToInt32(renglon()), new StringFormat());
                    contador += 1;
                }
                else
                {
                    cadenaPorEscribirEnLinea = PieDePagina;
                    gfx.DrawString(cadenaPorEscribirEnLinea, fuenteImpresa, colorDeLaFuente, Convert.ToInt32(margenIzquierdo), Convert.ToInt32(renglon()), new StringFormat());

                    contador += 1;
                }
                margenIzquierdo = 10;
                dibujaEspacio();
            }
        }
        private void dibujaEspacio()
        {
            cadenaPorEscribirEnLinea = "";

            gfx.DrawString(cadenaPorEscribirEnLinea, fuenteImpresa, colorDeLaFuente, Convert.ToInt32(margenIzquierdo), Convert.ToInt32(renglon()), new StringFormat());

            contador += 1;
        }
        #endregion


        #region Metodos Impresora
        public bool ImpresoraExistente(string impresora)
        {
            foreach (string strPrinter in PrinterSettings.InstalledPrinters)
            {
                if (impresora == strPrinter)
                    return true;
            }

            return false;
        }
        public void imprimeTicket(string impresora)
        {
            fuenteImpresa = new Font(nombreDeLaFuente, tamanoDeLaFuente, FontStyle.Regular);
            PrintDocument pr = new PrintDocument();
            DocumentoAImprimir.PrinterSettings.PrinterName = impresora;
            //pr.PrinterSettings.printpa();
            //pr += new PrintPageEventHandler(pr_PrintPage);
            DocumentoAImprimir.Print();
        }
        #endregion
    }

    //Clase Ordenar Total
    public class ordenarTotal
    {
        private char delimitador = ' ';

        public ordenarTotal(char delimitador)
        {
            this.delimitador = delimitador;
        }
        public string obtenerTotalNombre(string totalItem)
        {
            string delimitado = totalItem.Trim(delimitador);
            return delimitado;
        }
        public string obtenerTotalCantidad(string totalItem)
        {
            string delimitado = totalItem.Trim(delimitador);
            return delimitado;
        }
        public string generarTotal(string totalNombre, string price)
        {
            return totalNombre + delimitador + price;
        }
    }
    //Clase Ordenar Elementos
    public class OrdenarElementos
    {
        private char delimitador = ' ';
        public OrdenarElementos(char delimitador)
        {
            this.delimitador = delimitador;
        }
        public string obtenerCantidadDeElementos(string orderItem)
        {

            string delimitado = orderItem.Trim(delimitador);
            return delimitado;
        }
        public string obtenerNombreElemento(string orderItem)
        {
            string delimitado = orderItem.Trim(delimitador);
            return delimitado;
        }
        public string obtenerPrecioElemento(string orderItem)
        {
            string delimitado = orderItem.Trim(delimitador);
            return delimitado;
        }
        public string generarElemento(string cantidad, string nombreElemento, string precio)
        {
            return cantidad + delimitador + nombreElemento + delimitador + precio;
        }
    }
}
