using DonAR.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonAR.Domain
{
    public class DonationConfirmation : Entity
    {
        public string SimpleToken { get; set; }
        public byte[] QRCode { get; set; }
        public bool IsConfirmed { get; set; }
        public DateTime ConfirmDate { get; set; }
    }
}
