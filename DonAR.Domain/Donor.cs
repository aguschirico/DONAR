using DonAR.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonAR.Domain
{
    //Acá está la papa. Se pone medio turbio aca el modelo, pero la idea
    // es poder trackear donaciones y usuarios donantes.
    public class Donor : Entity
    {
        public User User { get; set; }
        public Donation Donation { get; set; }
        public DonationConfirmation Confirmation { get; set; }

        public Donor()
        {

        }

        public Donor(User user, Donation donation)
        {
            User = user;
            Donation = donation;
        }
    }
}
