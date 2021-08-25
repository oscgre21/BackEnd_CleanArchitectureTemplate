using System;
namespace BaseCleanArchitecture.BL.DTOs.ViewModel
{
    public class condicionViewModel : BaseViewModel
    {
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public int dias { get; set; }
    }
}
