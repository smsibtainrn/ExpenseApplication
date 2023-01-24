using ExpenseApplication.ViewModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpenseApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoriesPage : ContentPage
    {
        CategoriesVM ViewModel;


        public CategoriesPage()
        {
            InitializeComponent();

            ViewModel = Resources["vm"] as CategoriesVM;

            SizeChanged += CategoriesPage_SizeChanged;

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ViewModel.GetExpensePerCategory();
        }

        void CategoriesPage_SizeChanged(object sender, EventArgs e) {
            string visualState = Width > Height ? "Landscape" : "Portrait";

            VisualStateManager.GoToState(titleLabel, visualState);
        }

        void Handle_Pressed(object sender, EventArgs e) {
            //VisualStateManager.GoToState(mainPageButton, "Focused");
        }

        void Handle_Released(object sender, EventArgs e)
        {
            //VisualStateManager.GoToState(mainPageButton, "Normal");
        }

        private void ImageButton_Pressed(object sender, EventArgs e)
        {

        }
    }
}