using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorPractica.Model
{
    public class Ventas
    {
        public int idVenta { get; set; }
        public string nombre { get; set; }
        public int idCliente { get; set; }
        public string Numero { get; set; }

        public string Serie { get; set; }

        public int idVendedor { get; set; }

        public int idTipoPago { get; set; }
        public double totalVenta { get; set; }

        public string apellidoPaterno { get; set; }

        public string apellidoMaterno { get; set; }
        public DateTime fechaVenta { get; set; }

        public double totales { get; set; }



    }
}
