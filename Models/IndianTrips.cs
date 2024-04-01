using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trip.Models
{
    public class IndianTrips
    {
        public int productId { get; set; }
        public string productName { get; set; }
        public string productDesc { get; set; }
        public int categoryId { get; set; }

        public string fieldimage { get; set; }
        public string fieldaudio { get; set; }
    }
}
