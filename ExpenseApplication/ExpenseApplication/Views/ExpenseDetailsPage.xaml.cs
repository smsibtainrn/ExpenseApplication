using ExpenseApplication.Models;
using ExpenseApplication.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpenseApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExpenseDetailsPage : ContentPage
    {
        
        ExpenseDetailsVM ViewModel;
        public ExpenseDetailsPage()
        {
            InitializeComponent();
        }

        public ExpenseDetailsPage(Expense expense)
        {
            InitializeComponent();

            ViewModel = Resources["vm"] as ExpenseDetailsVM;
            ViewModel.Expense = expense;
        }
    }
}