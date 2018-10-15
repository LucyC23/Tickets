
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//Agregamos las librerias que utilizaremos.
using System.Drawing;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using System.IO;
using System.Collections;

namespace Tickets
{
    //Clase para crear el ticket de venta, para ello se crearan varios metodos
    public class CrearTicket
    {

        ArrayList LineasDeLaSubCabeza = new ArrayList();
        ArrayList LineasDeLaCabeza = new ArrayList();
        ArrayList Elementos = new ArrayList();
        ArrayList Totales = new ArrayList();
        ArrayList LineasDelPie = new ArrayList();

        private Image headerImagep { set; get; }

        public int contador = 0;
        public int caracteresMaximos { set; get; } = 35;
        public int caracteresMaximosDescripcion { set; get; } = 20;
        public int imageHeight = 0;
        public double margenIzquierdo = 10;
        public double margenSuperior = 13;
        public string nombreDeLaFuente { set; get; } = "";
        public int tamanoDeLaFuente { set; get; } = 9;
        public Font fuenteImpresa;
        public SolidBrush colorDeLaFuente = new SolidBrush(Color.Black);
        public Graphics gfx;
        public String cadenaPorEscribirEnLinea = "";
        private PrintDocument DocumentoAImprimir = new PrintDocument();

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
            for (int x = 0; x < spaces; espacios +="")
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
        //Metodos de la impresora
        public Boolean impresoraExistente(string impresora)
        {
            foreach (string strPrinter  in PrinterSettings.InstalledPrinters)
            {
                if (impresora = strPrinter)
                {
                    return true;
                }

            }
        }
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

    //Clase para mandara a imprimir texto plano a la impresora
    public class RawPrinterHelper
    {
        // Structure and API declarions:
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public class DOCINFOA
        {
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDocName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pOutputFile;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDataType;
        }
        [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);

        [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartDocPrinter(IntPtr hPrinter, Int32 level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

        [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32 dwCount, out Int32 dwWritten);

        // SendBytesToPrinter()
        // When the function is given a printer name and an unmanaged array
        // of bytes, the function sends those bytes to the print queue.
        // Returns true on success, false on failure.
        public static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, Int32 dwCount)
        {
            Int32 dwError = 0, dwWritten = 0;
            IntPtr hPrinter = new IntPtr(0);
            DOCINFOA di = new DOCINFOA();
            bool bSuccess = false; // Assume failure unless you specifically succeed.

            di.pDocName = "Ticket de Venta";//Este es el nombre con el que guarda el archivo en caso de no imprimir a la impresora fisica.
            di.pDataType = "RAW";//de tipo texto plano

            // Open the printer.
            if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
            {
                // Start a document.
                if (StartDocPrinter(hPrinter, 1, di))
                {
                    // Start a page.
                    if (StartPagePrinter(hPrinter))
                    {
                        // Write your bytes.
                        bSuccess = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                        EndPagePrinter(hPrinter);
                    }
                    EndDocPrinter(hPrinter);
                }
                ClosePrinter(hPrinter);
            }
            // If you did not succeed, GetLastError may give more information
            // about why not.
            if (bSuccess == false)
            {
                dwError = Marshal.GetLastWin32Error();
            }
            return bSuccess;
        }

        public static bool SendStringToPrinter(string szPrinterName, string szString)
        {
            IntPtr pBytes;
            Int32 dwCount;
            // How many characters are in the string?
            dwCount = szString.Length;
            // Assume that the printer is expecting ANSI text, and then convert
            // the string to ANSI text.
            pBytes = Marshal.StringToCoTaskMemAnsi(szString);
            // Send the converted ANSI string to the printer.
            SendBytesToPrinter(szPrinterName, pBytes, dwCount);
            Marshal.FreeCoTaskMem(pBytes);
            return true;
        }
    }
}

