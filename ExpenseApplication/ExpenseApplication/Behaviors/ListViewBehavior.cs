using ExpenseApplication.Models;
using ExpenseApplication.Views;
using Xamarin.Forms;

namespace ExpenseApplication.Behaviors
{
    class ListViewBehavior:Behavior<ListView>
    {
        ListView listView;

        protected override void OnAttachedTo(ListView bindable)
        {
            base.OnAttachedTo(bindable);

            listView = bindable;
            listView.ItemSelected += ListView_ItemSelected;
        }

        void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e) {
            Expense expense = listView.SelectedItem as Expense;

            Application.Current.MainPage.Navigation.PushAsync(new ExpenseDetailsPage(expense));
        }

        protected override void OnDetachingFrom(ListView bindable)
        {
            base.OnDetachingFrom(bindable);

            listView.ItemSelected -= ListView_ItemSelected;
        }
    }
}
