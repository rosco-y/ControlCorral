using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCorral.Model
{
    public class CustomerInfo
    {
        public string CustomerName { set; get; }
        public byte[] CustomerImage { get; set; }
        public double MassageIntensity { get; set; }
        public DateTime DOB { get; set; }
    }
}
