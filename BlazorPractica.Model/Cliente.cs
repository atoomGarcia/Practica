using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorPractica.Model
{
     public class Cliente
    {
        public int idCliente { get; set; }
        public string nombre { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }

        public string rfc { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string estado { get; set; }
        public string ciudad { get; set; }
        public string colonia { get; set; }
        public int cp { get; set; }
        public int estatus { get; set; }
        public DateTime fechaIngreso { get; set; }

    }

}
