using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViajeFacil.Poco
{
    public partial class paispoco
    {
        public paispoco()
        {
        }

        public long codigopais { get; set; }
        public string nome { get; set; } = null!;
    }
}
