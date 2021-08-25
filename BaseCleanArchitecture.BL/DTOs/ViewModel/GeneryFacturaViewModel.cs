using System;
using System.Collections.Generic;
using System.Text;

namespace BaseCleanArchitecture.BL.DTOs.ViewModel
{
    public class GeneryFacturaViewModel
    {
        public string clienteid { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string rnc { get; set; }
        public string nivelprecio { get; set; }
        public string comprobante { get; set; }
        public string envio { get; set; }
        public string impuesto { get; set; }
        public string condicion { get; set; }
        public string moneda { get; set; }
        public string vendedor { get; set; }
        public string fecha { get; set; }
        public string ordenCompra { get; set; }
        public string referencia { get; set; }
        public string tipoPago { get; set; }
        public string despacho { get; set; }
        public string promotor { get; set; }

        public List<productosFacturaViewModel> productos { get; set; }
        public int subtotal { get; set; }
        public int total { get; set; }
    }
}
