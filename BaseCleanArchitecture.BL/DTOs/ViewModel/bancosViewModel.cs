using System;
namespace BaseCleanArchitecture.BL.DTOs.ViewModel
{
    public class bancosViewModel : BaseViewModel
    {
        public int id { get; set; }
        public string tipo { get; set; }
        public string descripcion { get; set; }
    }
}
