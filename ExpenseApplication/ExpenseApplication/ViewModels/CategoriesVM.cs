using ExpenseApplication.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace ExpenseApplication.ViewModels
{
    class CategoriesVM
    {
        public ObservableCollection<string> Categories { get; set; }

        public ObservableCollection<CategoryExpenses> CategoryExpensesCollection { get; set; }


        public CategoriesVM() {
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

        public class CategoryExpenses { 
            public string Category { get; set; }
            public float ExpensesPercentage { get; set; }
        }
    }
}
