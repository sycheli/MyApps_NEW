using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApps.ViewsModel
{
    public class Plate
    {
        public int id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public double rate { get; set; }
        public string description { get; set; }
        public string img { get; set; }
        public double pointValue { get; set; }
        public Offer offer { get; set; }       
        public Restaurant restaurant { get; set; }
    }
    public class Offer
    {
       
        public double discount { get; set; }

        
    }
    
   
}
