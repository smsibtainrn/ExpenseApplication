﻿using ExpenseApplication.Models;
using ExpenseApplication.Resources;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace ExpenseApplication.ViewModels
{
    class NewExpenseVM : INotifyPropertyChanged
    {
        private string expenseName;
        public string ExpenseName {
            get { return expenseName; }
            set { expenseName = value;
                OnPropertyChanged("ExpenseName");
            }
        }

        private string expenseDescription;
        public string ExpenseDescription
        {
            get { return expenseDescription; }
            set
            {
                expenseDescription = value;
                OnPropertyChanged("ExpenseDescription");
            }
        }

        private float expenseAmount;
        public float ExpenseAmount
        {
            get { return expenseAmount; }
            set
            {
                expenseAmount = value;
                OnPropertyChanged("ExpenseAmount");
            }
        }

        private DateTime expenseDate;
        public DateTime ExpenseDate
        {
            get { return expenseDate; }
            set
            {
                expenseDate = value;
                OnPropertyChanged("ExpenseDate");
            }
        }

        private string expenseCategory;
        public string ExpenseCategory
        {
            get { return expenseCategory; }
            set
            {
                expenseCategory = value;
                OnPropertyChanged("ExpenseCategory");
            }
        }

        public Command SaveExpenseCommand { get; set; }

        public ObservableCollection<string> Categories { get; set; }
        public ObservableCollection<ExpenseStatus> ExpenseStatuses { get; set; }

        public NewExpenseVM() {
            Categories = new ObservableCollection<string>();
            ExpenseStatuses = new ObservableCollection<ExpenseStatus>();
            ExpenseDate = DateTime.Today;
            SaveExpenseCommand = new Command(InsertExpense);
            GetCategories();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void InsertExpense() {

            var vm = this;

            Expense expense = new Expense()
            {
                Name = ExpenseName,
                Amount = ExpenseAmount,
                Category = ExpenseCategory,
                Date = ExpenseDate,
                Description = ExpenseDescription
            };

            int response = Expense.InsertExpense(expense);

            if (response > 0)
                Application.Current.MainPage.Navigation.PopAsync();  
            else 
                Application.Current.MainPage.DisplayAlert("Error","No items were inserted","Ok");
        }
        private void GetCategories()
        {
            Categories.Clear();
            Categories.Add(AppResources.housingCategory);
            Categories.Add(AppResources.debtCategory);
            Categories.Add(AppResources.healthCategory);
            Categories.Add(AppResources.foodCategory);
            Categories.Add(AppResources.personalCategory);
            Categories.Add(AppResources.travelCategory);
            Categories.Add(AppResources.otherCategory);
        }

        public void GetExpenseStatus() {
            ExpenseStatuses.Clear();
            ExpenseStatuses.Add(new ExpenseStatus()
            {
                Name = "Random 1",
                Status = true
            });
            ExpenseStatuses.Add(new ExpenseStatus()
            {
                Name = "Random 2",
                Status = true
            });
            ExpenseStatuses.Add(new ExpenseStatus()
            {
                Name = "Random 3",
                Status = false
            });
        }

        public class ExpenseStatus {
            public string Name { get; set; }
            public bool Status { get; set; }
        }
    }
}
