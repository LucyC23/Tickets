
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//Agregamos las librerias que utilizaremos.
using System.Drawing;
using System.Drawing.Printing;
using System.Runtime.InteropServices;

namespace Tickets
{
    //Clase para crear el ticket de venta, para ello se crearan varios metodos
    public class CrearTicket
    {
        //Creacion de un objeto de la clase StringBuilder, en este objeto agregamos las lineas del ticket 
        StringBuilder line = new StringBuilder();
        //Creacion de variable para almacenar el numero maximo de caracteres que se permiten en el ticket
        int maxCaract = 40, cortar;

        //Metodo para dibujar lineas guia
        public string LineasGuia()
        {
            string lineasG = "";
            for (int i = 0; i < maxCaract; i++)
            {
                lineasG += "-";//Se agrega un guin cuando se llega al maximo numero de caracteres
            }
            return line.AppendLine(lineasG).ToString();// Devolvemos la lineaGuia
        }
        //Metodo para dibujar lineas con asteriscos
        public string LineaAsterisco()
        {
            string lineasAsterisco = "";
            for (int i = 0; i < maxCaract; i++)
            {
                lineasAsterisco += "*";//Se agrega un asterisco cuando se llega al maximo numero de caracteres
            }
            return line.AppendLine(lineasAsterisco).ToString();// Devolvemos la lineaGuia
        }
        //Metodo para dibujar lineas con signo igual
        public string LineasIgual()
        {
            string lineaIgual = "";
            for (int i = 0; i < maxCaract; i++)
            {
                lineaIgual += "=";//Se agrega un signo igual cuando se llega al maximo numero de caracteres
            }
            return line.AppendLine(lineaIgual).ToString();// Devolvemos la lineaGuia con signo igual
        }
        //Creacion del encabezado para los articulos
        public void encabezadoVenta()
        {
            line.AppendLine("ARTICULO           |CANTIDAD|PRECIO");
        }
        //Metodo para colocar el texto a la izquierda
        public void TextoIzquierda(string texto)
        {
            //Condicion si el texto es mayor al numero maximo de caracteres 
            if (texto.Length > maxCaract)
            {
                int caracterActual = 0;
                for (int longitudTexto = texto.Length; longitudTexto > maxCaract; longitudTexto -= maxCaract)
                {
                    //Agregamos los fragmentos que salgan del texto
                    line.AppendLine(texto.Substring(caracterActual, maxCaract));
                    caracterActual += maxCaract;
                }
                //Agregamos el fragmento restante
                line.AppendLine(texto.Substring(caracterActual, texto.Length - caracterActual));
            }
            else
            {
                //Si no es mayor solo agregarlo
                line.AppendLine(texto);
            }
        }
        public void TextoDerecha(string texto)
        {
            //Condicion si el texto es mayor al numero maximo de caracteres 
            if (texto.Length > maxCaract)
            {
                int caracterActual = 0;// Nos indicara en que caracter se posiciona al bajar el texto a la siguiente linea
                for (int longitudTexto = texto.Length; longitudTexto > maxCaract; longitudTexto -= maxCaract)
                {
                    //Agregamos los fragmentos que salgan del texto
                    line.AppendLine(texto.Substring(caracterActual, maxCaract));
                    caracterActual += maxCaract;
                }
                //Variable para poner espacios restantes
                string espacios = "";
                //Obtenemos la longitus del texto restante
                for (int i = 0; i < (maxCaract - texto.Substring(caracterActual, texto.Length - caracterActual).Length); i++)
                {
                    espacios += " ";//Agrega espacios para alinear a la derecha
                }

                //Agregamos el fragmento restante, agregamos antes del texto los espacios
                line.AppendLine(espacios + texto.Substring(caracterActual, texto.Length - caracterActual));
            }
            else
            {
                //Si no es mayor solo agregarlo
                string espacios = "";
                //Obtenemos la longitud del texto restante
                for (int i = 0; i < (maxCaract - texto.Length); i++)
                {
                    espacios += " ";
                }
                //Si no es mayor solo agregarlo
                line.AppendLine(espacios + texto);
            }
        }
        //Metodo para centrar el texto
        public void textoCentro(string texto)

        {
            if (texto.Length > maxCaract)
            {
                int caracterActual = 0;// Nos indicara en que caracter se posiciona al bajar el texto a la siguiente linea
                for (int longitudTexto = texto.Length; longitudTexto > maxCaract; longitudTexto -= maxCaract)
                {
                    //Agregamos los fragmentos que salgan del texto
                    line.AppendLine(texto.Substring(caracterActual, maxCaract));
                    caracterActual += maxCaract;
                }
                //Variable para poner espacios restantes
                string espacios = " ";
                //Se obtiene la cantidad de espacios libres y el resultado se divide entre dos
                int centrar = (maxCaract - texto.Substring(caracterActual, texto.Length - caracterActual).Length)/2;
                //Obtenemos la longitud del texto restante

                for (int i = 0; i < (maxCaract - texto.Substring(caracterActual, texto.Length - caracterActual).Length); i++)
                {
                    espacios += " ";//Agrega espacios para alinear a la derecha
                }

                //Agregamos el fragmento restante, agregamos antes del texto los espacios
                line.AppendLine(espacios + texto.Substring(caracterActual, texto.Length - caracterActual));
            }
            else
            {
                string espacios = "";
                int centrar = (maxCaract-texto.Length)/2;

                for (int i = 0; i < centrar; i++)
                {
                    espacios += " ";
                }

                line.AppendLine(espacios + texto);
            }
        }
        //Metodo para poner texto a los extremos
        public void textoExtremos(string textoIzquierdo, string textoDerecho)
        {
            //Variables que utilizaremos
            string textoIzq, textoDer, textoCompleto = "", espacios = "";

            //Si el texto que va a la izquierda es mayor a 18, cortamos el texto
            if (textoIzquierdo.Length > 18)
            {
               cortar = textoIzquierdo.Length - 18;
                textoIzq = textoIzquierdo.Remove(18, cortar);
            }
            else
            {textoIzq = textoIzquierdo; }

            textoCompleto = textoIzq;

            if (textoDerecho.Length > 20)
            {
                cortar = textoDerecho.Length - 20;
                textoDer = textoDerecho.Remove(20, cortar);
            }
            else
            {textoDer = textoDerecho;}

            //Obtenemos el numero de espacios restantes para poner textoDerecho al final
            int numeroEspacios = maxCaract - (textoIzq.Length + textoDer.Length);
            for (int i = 0; i <numeroEspacios; i++)
            {
                espacios += " ";
            }
            textoCompleto += espacios + textoDerecho;
            line.AppendLine(textoCompleto);//Agregamos la linea al ticket, al objeto en si.
        }
         //Metodo para agregar los totales de la venta
         public void agregarTotales(string texto, decimal total)
             {
            //Variables a utilizar
            string resumen, valor, textoCompleto, espacios = "";

            if (texto.Length > 25)//si es mayor a 25 lo cortamos
            {
                cortar = texto.Length - 25;
                resumen = texto.Remove(25, cortar);
            }
            else
            { resumen = texto;}

            textoCompleto = resumen;
            valor = total.ToString("#.00");//Agregamos el total previo formateo

            //Obtenemos el numero de espacios restantes para alinearls a la derecha
            int numeroEspacios = maxCaract - (resumen.Length + valor.Length);
            //Agregamos los espacios
            for (int i = 0; i < numeroEspacios; i++)
            {
                espacios += " ";
            }
            textoCompleto += espacios + valor;
            line.AppendLine(textoCompleto);
             }
        //Metodo para agrefar articulos al ticket de venta
        public void agregarArticulos(string articulo, int cant, decimal precio)
        {
            //Valida que la cantidad precio  esten dentro del rango
            if (cant.ToString().Length <= 5 && precio.ToString().Length <= 7 )
            {
                string elemento = "", espacios = " ";
                bool bandera = false;// Indicara ei es la primera linea que se escribe cuando se baje a la segunda si el nombre del articulo no entra en la primera linea 
                int numeroEspacios = 0;

                //Si el nombre o descripcion del articulo es mayor a 20, bajar a la siguiente linea
                if (articulo.Length > 20)
                {
                    //Colocar la cantidad a la derecha 
                    numeroEspacios = (5 - cant.ToString().Length);
                    espacios = "";
                    for (int i = 0; i < numeroEspacios; i++)
                    {
                        espacios += " ";//Generamos los espacios necesarios para alinear a la derecha
                    }
                    elemento += espacios + cant.ToString();// Agregamosla cantidad con los espacios

                    //Colocar el precio a la derecha
                    numeroEspacios = (7 - precio.ToString().Length);
                    espacios = "";
                    for (int i = 0; i < numeroEspacios; i++)
                    {
                        espacios += " ";// Genera los espacios
                    }
                    elemento += espacios + precio.ToString();//Agregamos el precio a la variable elemento

                    //Indicara en que caracter se quedo al bajar a la siguiente linea
                    int caracterAtual = 0;
                    //Por cada 20 caracteres se agregara una linea siguiente
                    for (int longitudTexto = articulo.Length; longitudTexto > 20; longitudTexto -= 20)
                    {
                        if (bandera == false)
                        {
                            line.AppendLine(articulo.Substring(caracterAtual, 20) + elemento);
                            bandera = true;
                        }
                        else

                            line.AppendLine(articulo.Substring(caracterAtual, 20));

                        caracterAtual += 20;
                    }
                    line.AppendLine(articulo.Substring(caracterAtual, articulo.Length - caracterAtual));
                }
                else
                {
                    for (int i = 0; i < (20 - articulo.Length); i++)
                    {
                        espacios += " ";
                    }
                    elemento = articulo + espacios;

                    //Colocar la cantidad a la derecha
                    numeroEspacios = (5 - cant.ToString().Length);
                    espacios = "";
                    for (int i = 0; i < numeroEspacios; i++)
                    {
                        espacios += " ";
                    }
                    elemento += espacios + cant.ToString();

                    //Colocar el precio a la derecha
                    numeroEspacios = (7 - precio.ToString().Length);
                    espacios = "";
                    for (int i = 0; i < numeroEspacios; i++)
                    {
                        espacios += " ";
                    }
                    elemento += espacios + precio.ToString();
                    line.AppendLine(elemento);
                }
                  }
            else
            {
                line.AppendLine("Los valores ingresados para esta fila");
                line.AppendLine("superan las columnas soportadas para este.");
                throw new Exception("Los valores ingresados para algunas filas del ticket\n superan las columnas soportadas por este");
            }
          }

        //Metodo para enviar secuencias de escape a la impresora
        //Para cortar el ticket
        public void cortarTicket()
        {
            line.AppendLine("\x1B69" + "m");//Caracteres de corte, estps comandos varian segun el tipo de impresor
            line.AppendLine("\x1B69" + "d" + "\x09");//Avanza 9 renglones, tambien varian 
        }
        public void imprimirTicket(string impresora)
        {
            RawPrinterHelper.SendStringToPrinter(impresora, line.ToString());
            line.Clear();
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

