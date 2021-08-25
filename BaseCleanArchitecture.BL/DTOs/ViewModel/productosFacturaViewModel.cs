using System;
using System.Collections.Generic;
using System.Text;

namespace BaseCleanArchitecture.BL.DTOs.ViewModel
{
    public class productosFacturaViewModel
    {
        public string productoId { get; set; }
        public int cantidad { get; set; }
        public string descripcion { get; set; }
        public int descuento { get; set; }
        public string empaque { get; set; }
        public int itibis { get; set; }
        public int precio { get; set; }
        public string tipo { get; set; }
    }
}
