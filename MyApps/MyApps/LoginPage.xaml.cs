using MyApps.ViewsModel;
using System;


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
        void OnLoginButtonClicked(object sender, EventArgs e)
        {
            var user = new User
            {
                userName = usernameEntry.Text,
                password = passwordEntry.Text
            };

            var isValid = AreCredentialsCorrect(user);
            if (isValid)
            {
                App.IsUserLoggedIn = true;


                Application.Current.MainPage = new NavigationPage(new SideDrawer())
                {
                    BarBackgroundColor = Color.FromHex("#00B0CD"),
                    BarTextColor = Color.White,
                };


            }
            else
            {
                DependencyService.Get<Toast>().Show("Login Failed");

                passwordEntry.Text = string.Empty;
            }
        }

        bool AreCredentialsCorrect(User user)
        {
            return user.userName == Constants.Username && user.password == Constants.Password;
        }

    }
}
