using MyApps.ViewsModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;


namespace MyApps.ViewsModel

{
    public class Reservation
    {
        public List<Plate> Plates { get; set; }
        public int id { get; set; }
        public double reservationPrice { get; set; }
        public DateTime reservationDate { get; set; }
        public DateTime deliveryDate { get; set; }
        public string state { get; set; }
        
        

    }
}