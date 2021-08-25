using System;
namespace BaseCleanArchitecture.BL.DTOs.ViewModel
{
    public class UsuarioViewModel : BaseViewModel
    {
        public string codigo { get; set; }
        public string usuario { get; set; }
        public string acceso { get; set; }
        public string empresa { get; set; }
        public string tipo { get; set; }
    }
}
