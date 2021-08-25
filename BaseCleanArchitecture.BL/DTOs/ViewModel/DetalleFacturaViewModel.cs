using System;
using System.Collections.Generic;
using System.Text;

namespace BaseCleanArchitecture.BL.DTOs.ViewModel
{
    public class DetalleFacturaViewModel : BaseViewModel
    {
        public string factura { get; set; }
        public int itemno { get; set; }
        public string cliente { get; set; }
        public DateTime? fecha { get; set; }
        public string codigo { get; set; }
        public string estacion { get; set; }
        public int cantidad { get; set; }
        public int costo { get; set; }
        public int precio { get; set; }
        public double importe { get; set; }
        public int impuesto { get; set; }
        public float fraccion { get; set; }
        public string dpto { get; set; }
        public string familia { get; set; }
        public string estatus { get; set; }
        public string serie { get; set; }
        public string almacen { get; set; }
        public double comision { get; set; }
        public string vendedor { get; set; }
        public int cntentera { get; set; }
        public int cntfraccion { get; set; }
        public string serial { get; set; }
        public string conduce { get; set; }
        public string zona { get; set; }
        public string ciudad { get; set; }
        public string sector { get; set; }
        public string categoria { get; set; }
        public string region { get; set; }
        public string medida { get; set; }
        public int descuentop { get; set; }
        public float despachado { get; set; }
        public string tipo { get; set; }
        public string descripcion { get; set; }
        public int tipoconduce { get; set; }
        public string cabecera { get; set; }
        public float pcomision { get; set; }
        public string ubicacion { get; set; }
        public float tasa { get; set; }
        public string suplidorx { get; set; }
        public string suplidor { get; set; }
        public double tasa_itbis { get; set; }
        public double comision1 { get; set; }
        public string notas { get; set; }
    }
}
