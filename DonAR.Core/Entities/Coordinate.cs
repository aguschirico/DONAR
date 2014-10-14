using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonAR.Core.Entities
{
    public struct Coordinate
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public Coordinate(decimal latitude, decimal longitude)
            : this()
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
