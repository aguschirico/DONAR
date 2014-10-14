using DonAR.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonAR.Domain
{
    public class User : Entity
    {
        public IList<Donation> Donations { get; set; }
        public IList<Campaign> Campaigns { get; set; }

        public User()
        {
            Donations = new List<Donation>();
            Campaigns = new List<Campaign>();
        }
    }
}
