using System;
namespace BaseCleanArchitecture.BL.DTOs.ViewModel
{
    public class catalogoViewModel : BaseViewModel
    {
        public string cuenta { get; set; }
        public string nombre { get; set; }
        public string tipo { get; set; }
        public int grupo { get; set; }
        public int nivel { get; set; }
        public string control { get; set; }
        public int centro { get; set; }
        public string posteado { get; set; }
    }
}
