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
        
        Offer Ofrre;
        string stringVal;
        string stringVal1;
        string stringVal2;



        public DetailPage(Offer Ofrre)
        {
            Title = Ofrre.Plate.name;
            this.Ofrre = Ofrre;
          
            InitializeComponent();


        }
        public static List<Offer> Offre;
        public static List<Restaurant> restaurant;
        protected override  void OnAppearing()
        {
           
            base.OnAppearing();
            var Offre = new List<Offer>();
            
            Offre.Add(Ofrre);
            
            name.Text = Ofrre.Plate.name;
            description.Text = Ofrre.Plate.description;
            image.Source = Ofrre.Plate.img;
            stringVal = System.Convert.ToString(Ofrre.Plate.price);
            price.Text = stringVal;
            stringVal1 = System.Convert.ToString(Ofrre.Plate.rate);
            rate.Text = stringVal1;
            street.Text = Ofrre.Plate.restaurant.address.street;
            city.Text = Ofrre.Plate.restaurant.address.city;
            country.Text = Ofrre.Plate.restaurant.address.country;
            stringVal2 = System.Convert.ToString(Ofrre.Plate.restaurant.address.zipCode);
            zipCode.Text = stringVal2;
            Restaurant.Text = Ofrre.Plate.restaurant.name;
        }

        //public async Task RegisterUserAsync()
        //{
        //    var client = new HttpClient();
        //    var model = new Reservation
        //    {

        //        reservationPrice = Ofrre.Plate.price,
        //        Plates = Offre
        //    };
        //    var json = JsonConvert.SerializeObject(model);
        //    HttpContent content = new StringContent(json);

        //    var response = await client.PostAsync("http://10.0.3.2:61500/api/reservations", content);


        //}
        public async void command(object sender, EventArgs e)
        {
            //await RegisterUserAsync();
        }

    }
}
