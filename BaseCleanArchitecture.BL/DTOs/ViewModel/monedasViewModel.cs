using System;
namespace BaseCleanArchitecture.BL.DTOs.ViewModel
{
    public class monedasViewModel : BaseViewModel
    { 
        public string monedaid { get; set; }
        public string descripcion { get; set; }
        public double tasa { get; set; }
    }
}
