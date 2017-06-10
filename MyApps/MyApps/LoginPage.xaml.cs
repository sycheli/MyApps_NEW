using MyApps.ViewsModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MyApps
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            
        }
        //async void OnLoginButtonClicked(object sender, EventArgs e)
        //{
        //    var users = new RegisterViewModel();
        //    var user = new LoginViewModel()
        //    {
        //        Email = email.Text,
        //        Password = password.Text,
                
        //    };



        //    var isValid = AreCredentialsCorrect(user);
        //    if (isValid)
        //    {
                
        //            App.IsUserLoggedIn = true;

        //            Application.Current.MainPage = new NavigationPage(new SideDrawer())
        //            {
        //                BarBackgroundColor = Color.FromHex("#00B0CD"),
        //                BarTextColor = Color.White,
        //            };
               
        //    }
        //    else
        //    {
        //        DependencyService.Get<Toast>().Show("Login Failed");
        //        email.Text = string.Empty;
        //        password.Text = string.Empty;
        //    }
        //}

        //bool AreCredentialsCorrect(LoginViewModel user )
        //{
        //    return user.Email == users.Email && user.Password == users.Password;
        //}
    }
}
