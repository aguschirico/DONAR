using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonAR.Domain
{
    public class Campaign : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string DescriptionBody { get; set; }
        public string EmbededVideo { get; set; }
        public bool Active { get; set; }

        public Category Category { get; set; }
        public Target Target { get; set; } //Funded, completed, las cosas de la barra verde en indiegogo
        public CampaignType CampaignType { get; set; }
        public Geography Geography { get; set; }
        public IList<Donor> Donors { get; set; }

        public Campaign()
        {
            Donors = new List<Donor>();
        }
    }
}
