using System;
namespace BaseCleanArchitecture.BL.DTOs.ViewModel
{
    public class ubicacionViewModel : BaseViewModel
    {
        public string codigo { get; set; }
        public string almacen { get; set; }
        public string descripcion { get; set; }
        public string estatus { get; set; }
        public string subalmacen { get; set; }
        public string seccion { get; set; }
        public string tramo { get; set; }
        public string bandeja { get; set; }
    }
}
