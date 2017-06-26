using MyApps.ViewsModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MyApps.Views
{
    public partial class Commandes : ContentPage
    {
        public Commandes()
        {
            InitializeComponent();
           
        }
        protected override async void OnAppearing()
        {
            await GetRestaurant();


        }
        List<Reservation> getListFromJson(string json)
        {

            var Offre = JsonConvert.DeserializeObject<List<Reservation>>(json);
            return Offre;

        }
        public static List<Reservation> Offres;
        public async Task GetRestaurant()
        {
            var client = new HttpClient();
            var json = await client.GetStringAsync("http://10.0.3.2:61500/api/reservations");
            Offres = getListFromJson(json);
            RestaurantListView.ItemsSource = Offres;

        }
    }
}
