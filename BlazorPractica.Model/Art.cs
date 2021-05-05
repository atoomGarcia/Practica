using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorPractica.Model
{
    public class Art
    {
        public int idArticulo { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int idDep { get; set; }
        public int stock { get; set; }
        public double costo { get; set; }
        public double precio { get; set; }
        public int idProveedor { get; set; }
        public int estatus { get; set; }
        public DateTime fechaAlta { get; set; }

        public string nombreDep { get; set; }
        public string razonSocial { get; set; }



    }

}
