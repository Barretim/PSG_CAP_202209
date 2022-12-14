using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViajeFacil.Poco
{
    public partial class rotapoco
    {
        public rotapoco()
        {
        }

        public long codigorota { get; set; }
        public string pontoinicial { get; set; } = null!;
        public string pontofinal { get; set; } = null!;
    }
}

