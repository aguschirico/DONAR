using DonAR.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonAR.Domain
{
    public class Donation : Entity
    {
        public DonationConfirmation DonationConfirmation { get; set; }
        public DateTime TimeStamp { get; set; }
        public Geography Geography { get; set; }
    }
}
