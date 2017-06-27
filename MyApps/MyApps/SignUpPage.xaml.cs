using MyApps.ViewsModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MyApps
{
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            var user = new User()
            {
                userName = usernameEntry.Text,
                password = passwordEntry.Text,
                email = emailEntry.Text
            };



            var signUpSucceeded = AreDetailsValid(user);
            if (signUpSucceeded)
            {
                var rootPage = Navigation.NavigationStack.FirstOrDefault();
                if (rootPage != null)
                {
                    App.IsUserLoggedIn = true;

                    Navigation.InsertPageBefore(new SideDrawer(), Navigation.NavigationStack.First());
                    await Navigation.PopToRootAsync();
                }
            }
            else
            {
                DependencyService.Get<Toast>().Show("SignUp Failed");

            }
        }

        bool AreDetailsValid(User user)
        {
            return (!string.IsNullOrWhiteSpace(user.userName) && !string.IsNullOrWhiteSpace(user.password) && !string.IsNullOrWhiteSpace(user.email) && user.email.Contains("@"));
        }
        
    }
}
