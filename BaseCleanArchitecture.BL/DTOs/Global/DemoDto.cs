using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseCleanArchitecture.BL.DTOs.Base;

namespace BaseCleanArchitecture.BL.DTOs.Global
{
    public class DemoDto : BaseEntityDto
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
    }
}
