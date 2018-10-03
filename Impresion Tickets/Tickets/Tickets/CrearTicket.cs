
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
            line.AppendLine("ARTICULO                   |CANTIDAD|PRECIO|IMPORTE");
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
                string espacios = "";
                //Se obtiene la cantidad de espacios libres y el resultado se divide entre dos
                int centrar = (maxCaract - texto.Length) / 2;
                //Obtenemos la longitud del texto restante

                for (int i = 0; i < (maxCaract - texto.Substring(caracterActual, texto.Length - caracterActual).Length); i++)
                {
                    espacios += " ";//Agrega espacios para alinear a la derecha
                }

                //Agregamos el fragmento restante, agregamos antes del texto los espacios
                line.AppendLine(espacios + texto.Substring(caracterActual, texto.Length - caracterActual));
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
            {
                textoIzq = textoIzquierdo;
            }

            textoCompleto = textoIzq;

            if (textoDerecho.Length > 20)
            {
                cortar = textoDerecho.Length - 20;
                textoDer = textoDerecho.Remove(20, cortar);
            }
            else
            {
                textoDer = textoDerecho;
            }

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

            if (texto.Length > 25)//sies mayor a 25 lo cortamos
            {
                cortar = texto.Length - 25;
                resumen = texto.Remove(25, cortar);
            }
            else
            {
                resumen = texto;
            }
            textoCompleto = resumen;
            valor = total.ToString("#, #.00");//Agregamos el total previo formateo

            //Obtenemos el numero de espacios restantes para alinearls a la derecha
            int numeroEspacios = maxCaract - (resumen.Length + valor.Length);
            //Agregamos los espacios
            for (int i = 0; i < numeroEspacios; i++)
            {
                espacios += "";
            }
            textoCompleto += espacios + valor;
            line.AppendLine(textoCompleto);
             }

        //Metodo para agrefar articulos al ticket de venta
        public void agregarArticulos(string articulo, int cant, decimal precio, decimal importe)
        {

            //Valida que la cantidad precio e importe esten dentro del rango
            if (cant.ToString().Length < 5 && precio.ToString().Length <= 7 && importe.ToString().Length <= 8)
            {
                string elemento = "", espacios = "";
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

                    //Colocar el importe a la derecha
                    numeroEspacios = (8 - importe.ToString().Length);
                    espacios = "";
                    for (int i = 0; i < numeroEspacios; i++)
                    {
                        espacios += " ";
                    }
                    elemento += espacios + importe.ToString();//Agregamos el importe alineado a la derecha.

                    //Indicara en que caracter se quedo al bajar a la siguiente linea
                    int caracterAtual = 0;

                    //Por cada 20 caracteres se agregara una linea siguiente
                    for (int longitudTexto = articulo.Length; longitudTexto < 20; longitudTexto -= 20)
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

                    //Colocar Importe a la derecha
                    numeroEspacios = (8 - importe.ToString().Length);
                    espacios = "";
                    for (int i = 0; i < numeroEspacios; i++)
                    {
                        espacios += " ";
                    }
                    elemento += espacios + importe.ToString();

                    line.AppendLine(elemento);
                }
                  }

                }
            }
        }

