
using MyApps.ViewsModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
namespace MyApps.Views
{
    public partial class Offre : ContentPage
    {

        int n = 0;
        public Offre()
        {
            InitializeComponent();
            RestaurantListView.ItemSelected += async (sender, e) =>
            {

                Plate rest = e.SelectedItem as Plate;
                if (e.SelectedItem != null)
                {
                    bgLayer.IsVisible = true;
                    frameLayer.IsVisible = true;
                    await Task.Delay(2000);
                    n++;

                    await Navigation.PushAsync(new DetailPage(rest));
                    frameLayer.IsVisible = false;
                    bgLayer.IsVisible = false;
                }
                RestaurantListView.SelectedItem = null;
            };
            tapImage.Tapped += async (object sender, EventArgs e) =>
            {
                await GetRestaurant1();

            };

        }
        protected override async void OnAppearing()
        {
            await GetRestaurant();
           

        }
        List<Plate> getListFromJson(string json)
        {

            var Offre = JsonConvert.DeserializeObject<List<Plate>>(json);
            return Offre;

        }
        public static List<Plate> Offres;
        public async Task GetRestaurant()
        {
            var client = new HttpClient();
            var json = await client.GetStringAsync("http://localhost:61500/api/plates");
            Offres = getListFromJson(json);
            RestaurantListView.ItemsSource = Offres;

        }
        public List<Speciality> pizza { get; set; }
        //List<Speciality> getListFromJson1(string json)
        //{

        //    var pizza = JsonConvert.DeserializeObject<List<Speciality>>(json);
        //    return pizza;

        //}
        public async Task GetRestaurant1()
        {
            var client = new HttpClient();
            var json = await client.GetStringAsync("http://localhost:61500/api/Specialities/1");
            var obj = new { Groups = new List<Speciality>() };
            var groups = JsonConvert.DeserializeAnonymousType(json, obj);
            this.pizza = groups.Groups;
            //pizza = getListFromJson1(json);
            
            RestaurantListView.ItemsSource = pizza;
           
        }
        private void AbsolutePageXaml_SizeChanged(object sender, EventArgs e)
        {
            AbsoluteLayout.SetLayoutFlags(frameLayer,
                AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(frameLayer,
                new Rectangle(0.5d, 0.5d,
           Device.OnPlatform(AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize, Width), AbsoluteLayout.AutoSize));
            AbsoluteLayout.SetLayoutFlags(bgLayer,
                AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(bgLayer,
                new Rectangle(0d, 0d,
                this.Width, this.Height));

            
        }
    }
}
