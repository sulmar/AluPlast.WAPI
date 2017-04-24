using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluPlast.Models
{
    public class EtykietaPalety
    {
        public EtykietaType EtykietaType { get; set; }
        public int Number { get; set; }
        public override string ToString()
        {
            return $"{EtykietaType}-{Number}";
        }
    }
}
