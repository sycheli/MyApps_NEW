using MyApps.Views;
using MyApps.ViewsModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyApps
{
    public partial class DetailPage : ContentPage
    {
        
        Plate Ofrre;
        string stringVal;
        string stringVal1;
        string stringVal2;



        public DetailPage(Plate Ofrre)
        {
            Title = Ofrre.name;
            this.Ofrre = Ofrre;
          
            InitializeComponent();


        }
        public static List<Plate> Offre;
        public static List<Restaurant> restaurant;
        protected override  void OnAppearing()
        {
           
            base.OnAppearing();
            var Offre = new List<Plate>();
            
            Offre.Add(Ofrre);
            
            name.Text = Ofrre.name;
            description.Text = Ofrre.description;
            image.Source = Ofrre.img;
            stringVal = System.Convert.ToString(Ofrre.price);
            price.Text = stringVal;
            stringVal1 = System.Convert.ToString(Ofrre.rate);
            rate.Text = stringVal1;
            street.Text = Ofrre.restaurant.address.street;
            city.Text = Ofrre.restaurant.address.city;
            country.Text = Ofrre.restaurant.address.country;
            stringVal2 = System.Convert.ToString(Ofrre.restaurant.address.zipCode);
            zipCode.Text = stringVal2;
        }

        public async Task RegisterUserAsync()
        {
            var client = new HttpClient();
            var model = new Reservation
            {

                reservationPrice = Ofrre.price,
                Plates = Offre
            };
            var json = JsonConvert.SerializeObject(model);
            HttpContent content = new StringContent(json);
            
            var response = await client.PostAsync("http://10.0.3.2:61500/api/reservations", content);


        }
        public async void command(object sender, EventArgs e)
        {
           await RegisterUserAsync();
        }

    }
}
