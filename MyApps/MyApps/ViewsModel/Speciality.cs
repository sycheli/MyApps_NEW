using MyApps.ViewsModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;


namespace MyApps.ViewsModel
{
    public class Speciality
    {

        public int id { get; set; }

        public string name { get; set; }
        [JsonProperty("Plates")]
        public List<Plate> Plates { get; set; }
    }
    

    
}