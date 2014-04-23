using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskMeter.Core.Models
{
    public class State
    {
        public string Name { get; set; }
        public string Code { get; set; }

        public virtual List<string> Cities { get; set; } 
    }
}
