using MyApps.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyApps.ViewsModel
{
    public class RegisterViewModel
    {
        public string userName { get; set; }
                
        public string email { get; set; }

        public string password { get; set; }

        public ICommand RegisterCommand
        {
            get
            {
                return new Command(async () =>
                {
                    ApiServices apiServices = new ApiServices();
                    await apiServices.RegisterUserAsync(userName, email, password);
                    
                });
            }
        }

    }
}
