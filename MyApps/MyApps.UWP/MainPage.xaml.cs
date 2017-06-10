using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace MyApps.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            Xamarin.FormsMaps.Init("n9RYeX7w8KgGMcJn66e8~TKk2Lt4OATg0MCYfZI0n0A~AhPsbyMRDl0waj8VCiC8o1VdBwk11jNIDiy7W_UEjc2FFtoHo213sj01CwpJW8XK");
            LoadApplication(new MyApps.App());
        }
    }
}
