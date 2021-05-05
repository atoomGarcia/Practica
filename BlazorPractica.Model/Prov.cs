using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorPractica.Model
{
    public class Prov
    {
        public int idProveedor { get; set; }
        public string razonSocial { get; set; }
        public string rfc { get; set; }
        public string estado { get; set; }
        public string ciudad { get; set; }
        public string colonia { get; set; }
        public int cp { get; set; }
        public int estatus { get; set; }
        public DateTime fechaAlta { get; set; }
    }
}
