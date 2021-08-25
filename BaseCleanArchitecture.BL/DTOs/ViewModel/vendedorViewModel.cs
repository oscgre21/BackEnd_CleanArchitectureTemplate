using System;
namespace BaseCleanArchitecture.BL.DTOs.ViewModel
{
    public class vendedorViewModel : BaseViewModel
    {
        public string vendedorid { get; set; }
        public string v_nombre { get; set; }
        public string v_direccion { get; set; }
        public string v_sector { get; set; }
        public string v_ciudad { get; set; }
        public string v_telefono { get; set; }
        public string v_postal { get; set; }
        public string v_email { get; set; }
        public string v_cedula { get; set; }
        public string v_celular { get; set; }
        public string v_zona { get; set; }
        public string v_region { get; set; }
        public string v_categoria { get; set; }
        public string v_tipocomision { get; set; }
        public double v_pcomisionv { get; set; }
        public double v_pcomisionc { get; set; }
        public double v_ventasante { get; set; }
        public double v_cobrosante { get; set; }
        public double v_ventasact { get; set; }
        public double v_cobrosact { get; set; }
        public double v_comisionvant { get; set; }
        public double v_comisioncant { get; set; }
        public double v_comisionvact { get; set; }
        public double v_comisioncact { get; set; }
        // public DateTime v_fechaentrada { get; set; }
        //public string v_fechacorte { get; set; }
        public int v_estatus { get; set; }
        public string v_observacion { get; set; }
        public string v_foto { get; set; }
        public string idcia { get; set; }
        public string v_mayor_pasivo { get; set; }
        public int ndia1 { get; set; }
        public int ndia2 { get; set; }
        public int ndia3 { get; set; }
        public int ndia4 { get; set; }
        public int ndia5 { get; set; }
        public float pcomi2 { get; set; }
        public float pcomi3 { get; set; }
        public float pcomi4 { get; set; }
        public float pcomi5 { get; set; }
        public float pcomi1 { get; set; }
    }
}
