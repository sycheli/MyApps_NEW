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
    public partial class MapPages : ContentPage
    {
        public static List<Restaurant> restaurants { get; set; }
        Position MyPosition = new Position(36.244998, 6.570788);
        Restaurant r;
        public MapPages(Restaurant restaurant)
        {
            this.r = restaurant;
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
            MainMap.MoveToRegion(MapSpan.FromCenterAndRadius(MyPosition, Distance.FromKilometers(1)));
            
                var pin = new Pin
                {
                    Position = new Position(r.address.latitude, r.address.longitude),
                    Label = r.name != null ? r.name : "No description !!!",
                };
                pin.Clicked += PinOnClicked;
                MainMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(r.address.latitude, r.address.longitude), Distance.FromKilometers(1)));
                MainMap.Pins.Add(pin);
            
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
            var json = await client.GetStringAsync("http://localhost:61500/api/restaurants");
            restaurants = getListFromJson(json);
        }


    }
}
