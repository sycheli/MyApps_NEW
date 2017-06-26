
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MyApps.Views
{
    public partial class Paramètres : ContentPage
    {
        public Paramètres()
        {
            InitializeComponent();
            version.Tapped +=  (object sender, EventArgs e) =>
            {
                DependencyService.Get<Toast>().Show("1.0.0");
            };
            facebook.Tapped += (object sender, EventArgs e) =>
            {
                Device.OpenUri(new Uri("https://m.facebook.com/Sycheli"));
            };
            dec.Tapped += (object sender, EventArgs e) =>
            {
                App.IsUserLoggedIn = false;
                Application.Current.MainPage = new NavigationPage(new ViewPage());
            };
        }
        
        }
}

