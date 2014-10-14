using DonAR.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonAR.Core.Entities
{
    //las cosas necesarias para meter en un mapa de google maps o bing maps
    public class Geography : Entity
    {
        public Coordinate Coordinate { get; set; }
        public bool IsRural { get; set; }
        public string City { get; set; }
    }
}
