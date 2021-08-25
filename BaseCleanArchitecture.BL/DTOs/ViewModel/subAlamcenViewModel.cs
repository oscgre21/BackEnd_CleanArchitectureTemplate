using System;
namespace BaseCleanArchitecture.BL.DTOs.ViewModel
{
    public class subAlamcenViewModel : BaseViewModel
    {
        public string codigo { get; set; }
        public string almacen { get; set; }
        public string descripcion { get; set; }
        public string estatus { get; set; }
    }
}
