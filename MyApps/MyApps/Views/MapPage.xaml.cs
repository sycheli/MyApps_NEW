using MyApps.ViewsModel;
using Newtonsoft.Json;
using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MyApps.Views
{
    public partial class MapPage : ContentPage
    {
        public static List<Restaurant> restaurants { get; set; }
        Position MyPosition = new Position(36.244998, 6.570788);
        public MapPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            
        }
        
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await GetRestaurant();
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            var pos = await locator.GetPositionAsync(timeoutMilliseconds: 10000);
            MainMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(pos.Latitude,pos.Longitude), Distance.FromKilometers(1)));
            foreach (Restaurant r in restaurants)
            {
                System.Diagnostics.Debug.WriteLine(r.address.latitude);
                
                     var pin = new Pin
                     {
                        
                        Position = new Position(r.address.latitude, r.address.longitude),
                        Label = r.name != null ? r.name : "No description !!!",
                        
                        
                    };
                    pin.Clicked += PinOnClicked;
                //MainMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(r.address.latitude,r.address.longitude), Distance.FromKilometers(1)));
                MainMap.Pins.Add(pin);
                    
                
            }
            
            
        }
        private void PinOnClicked(object sender, EventArgs e)
        {
            var selectedPin = sender as Pin;
            DisplayAlert(selectedPin?.Label, selectedPin?.Address, "OK");
        }
        public List<Restaurant> getListFromJson(string json)
        {
            var Restaurants = JsonConvert.DeserializeObject<List<Restaurant>>(json);


            return Restaurants;
        }

        
        public async Task GetRestaurant()
        {
            var client = new HttpClient();
            var json = await client.GetStringAsync("http://10.0.3.2:61500/api/restaurants");
            restaurants = getListFromJson(json);
            
        }

        //private double distance(double lat1, double lon1, double lat2, double lon2, char unit)
        //{

        //    double theta = 6.570788 - restaurant.Longitude ;
        //    double dist = Math.Sin(deg2rad(36.244998)) * Math.Sin(deg2rad(restaurant.Latitude)) + Math.Cos(deg2rad(36.244998)) * Math.Cos(deg2rad(restaurant.Latitude)) * Math.Cos(deg2rad(theta));
        //    dist = Math.Acos(dist);
        //    dist = rad2deg(dist);
        //    dist = dist * 60 * 1.1515;
        //    if (unit == 'K')
        //    {
        //        dist = dist * 1.609344;
        //    }
        //    else if (unit == 'N')
        //    {
        //        dist = dist * 0.8684;
        //    }
        //    return (dist);
        //}
        //private double deg2rad(double deg)
        //{
        //    return (deg * Math.PI / 180.0);
        //}
        //private double rad2deg(double rad)
        //{
        //    return (rad / Math.PI * 180.0);
        //}
    }
}
