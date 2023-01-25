using ExpenseApplication.Resources;
using ExpenseApplication.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpenseApplication
{
    public partial class App : Application
    {
        public static string DatabasePath;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }
        public App(string databasePath)
        {
            InitializeComponent();

            //AppResources.Culture = new System.Globalization.CultureInfo("en-US);
            //AppResources.Culture = new System.Globalization.CultureInfo("es-ES");

            DatabasePath = databasePath;

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
