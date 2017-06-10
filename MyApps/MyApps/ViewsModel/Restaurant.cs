﻿using System.Collections.Generic;

namespace MyApps
{
    public class Restaurant
    {
        public string name { get; set; }
        public string img { get; set; }
        public Address address { get; set; }
        public string description { get; set; }
        public string cover { get; set; }
    }
    public class Address
    {
        public string street { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public double zipCode { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
    }
}
