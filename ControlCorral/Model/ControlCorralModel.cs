using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCorral.Model
{
    public class ControlCorralModel
    {
        public List<CustomerInfo> Customers { get; set; } = new List<CustomerInfo>();
        public List<ReservationInfo> Reservations { get; set; } = new List<ReservationInfo>();
        public List<MassageTypes> MassageTypes { get; set; } = new List<MassageTypes>();

    }
}
