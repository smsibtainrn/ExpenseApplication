using ExpenseApplication.Interfaces;
using ExpenseApplication.Models;
using PCLStorage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace ExpenseApplication.ViewModels
{
    class CategoriesVM
    {
        public ObservableCollection<string> Categories { get; set; }

        public ObservableCollection<CategoryExpenses> CategoryExpensesCollection { get; set; }

        public Command ExportCommand { get; set; }

        public CategoriesVM() {
            ExportCommand = new Command(ShareReport);
            Categories = new ObservableCollection<string>();
            CategoryExpensesCollection = new ObservableCollection<CategoryExpenses>();

            GetCategories();
            GetExpensePerCategory();
        }
        private void GetCategories()
        {
            Categories.Clear();
            Categories.Add("Housing");
            Categories.Add("Debt");
            Categories.Add("Health");
            Categories.Add("Food");
            Categories.Add("Personal");
            Categories.Add("Travel");
            Categories.Add("Other");
        }
        public void GetExpensePerCategory()
        {
            CategoryExpensesCollection.Clear();

            float totalExpensesAmount = Expense.TotalExpensesAmount();
            foreach (var c in Categories) {
                var expenses = Expense.GetExpenses(c);
                float expensesAmountInCategory = expenses.Sum(e => e.Amount);
                
                CategoryExpenses ce = new CategoryExpenses()
                {
                    Category = c,
                    ExpensesPercentage = expensesAmountInCategory / totalExpensesAmount
                };

                CategoryExpensesCollection.Add(ce);
            }
        }

        public async void ShareReport()
        {
            IFileSystem fileSystem = FileSystem.Current;
            IFolder rootFolder = fileSystem.LocalStorage;
            IFolder reportsFolder = await rootFolder.CreateFolderAsync("reports",CreationCollisionOption.OpenIfExists);

            var textFile = await reportsFolder.CreateFileAsync("reports.txt", CreationCollisionOption.ReplaceExisting);

            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(textFile.Path)) {
                foreach (var ce in CategoryExpensesCollection) {
                    sw.WriteLine($"{ce.Category} - {ce.ExpensesPercentage:p}");
                }
            }

            var sharedDependency = DependencyService.Get<IShare>();
            await sharedDependency.Show("Expense Report", "Here is your expense report.", textFile.Path);
        }

        public class CategoryExpenses { 
            public string Category { get; set; }
            public float ExpensesPercentage { get; set; }
        }
    }
}
