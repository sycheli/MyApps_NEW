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
        public int id { get; set; }
        public double discount { get; set; }
        public int? PlateId { get; set; }
        public Plate Plate { get; set; }
        public Timing Timing { get; set; }
        
    }
    public class Timing
    {
        
        public int id { get; set; }
        public DateTime begin { get; set; }
        public DateTime end { get; set; }
        public Offer Offer { get; set; }
    }
    public class Speciality
    {
        
        public int id { get; set; }
        public string name { get; set; }
        public Plate Plate { get; set; }
        
    }
    public class Reservation
    {
        public Plate Plates { get; set; }
        public int id { get; set; }
        public double reservationPrice { get; set; }
        public DateTime reservationDate { get; set; }
        public DateTime deliveryDate { get; set; }
        public string state { get; set; }



    }
}
