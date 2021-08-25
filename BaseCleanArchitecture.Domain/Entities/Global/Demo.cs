using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseCleanArchitecture.Core.Basemodel.BaseEntity;

namespace BaseCleanArchitecture.Domain.Entities.Global
{
    public class Demo : BaseEntity
    {
        [MaxLength(10)]
        public string Codigo { get; set; }
        [MaxLength(60)]
        public string Descripcion { get; set; }
    }
}
