using System;


namespace BaseCleanArchitecture.BL.DTOs.ViewModel
{
    public class dptosViewModel : BaseViewModel
    {
        public string codigo { get; set; }
        public string descripcion { get; set; }
        //        public string empresa { get; set; }
        public string ctamayor_inventario { get; set; }
        public string ctamayor_venta { get; set; }
        public string ctamayor_dev_costo { get; set; }
        public string ctamayor_dev_venta { get; set; }
        public string ctamayor_comision { get; set; }
        public double porcprc0 { get; set; }
        public double porcprc1 { get; set; }
        public double porcprc2 { get; set; }
        public double porcprc3 { get; set; }
        public double porcprc4 { get; set; }
        public double porcprc5 { get; set; }
        public int secuencia { get; set; }
    }
}
