using Mauiverter.MVVM.Models;
using Mauiverter.MVVM.Views;

namespace Mauiverter
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MenuView());
        }
    }
}
