using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.Clases
{
    class OrdenarTicket
    {
        public class OrdenarElementos {

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
}
