using DonAR.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonAR.Core.Entities
{
    public class CampaignType : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        //Si alguna empresa tiene ganas de participar.  Se puede hacer mas complejo seguro.
        public bool HasPrivateSupport { get; set; } 

    }
}
