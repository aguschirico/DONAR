using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DonAR.UI.Models
{
    public class CampaignModels
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime LimitDate { get; set; }
        public DateTime StartDate { get; set; }
        public decimal Funded { get; set; }
        public string ImageName { get; set; }
    }
}