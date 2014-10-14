using DonAR.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonAR.Domain
{
    public class Target : Entity
    {
        public DateTime LimitDate { get; set; }
        public DateTime StartDate { get; set; }
        public decimal Funded { get; set; }
    }
}
