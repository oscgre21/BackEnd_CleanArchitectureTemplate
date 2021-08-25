using System;
namespace BaseCleanArchitecture.BL.DTOs.ViewModel
{
    public class ncfViewModel : BaseViewModel
    {
        public string codigo { get; set; }
        public string serie { get; set; }
        public string tipo { get; set; }
        public string cadena { get; set; }
        public int desde { get; set; }
        public int hasta { get; set; }
        public string descripcion { get; set; }
        public string estacion { get; set; }
        //public DateTime fechavence { get; set; }
        //public DateTime fechaemision { get; set; }
        public int registro { get; set; }
        public int secuencia { get; set; }
        public int aprobado { get; set; }
        public int alerta { get; set; }
    }
}
