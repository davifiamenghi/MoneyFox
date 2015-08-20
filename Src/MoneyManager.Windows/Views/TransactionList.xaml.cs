﻿using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using MoneyManager.Business.Logic;
using MoneyManager.Foundation;

namespace MoneyManager.Windows.Views
{
    public sealed partial class TransactionList
    {
        public TransactionList()
        {
            InitializeComponent();
        }

        private void AddSpendingClick(object sender, RoutedEventArgs e)
        {
            AddTransaction(TransactionType.Spending);
        }

        private void AddIncomeClick(object sender, RoutedEventArgs e)
        {
            AddTransaction(TransactionType.Income);
        }

        private void AddTransferClick(object sender, RoutedEventArgs e)
        {
            AddTransaction(TransactionType.Transfer);
        }

        private static void AddTransaction(TransactionType type)
        {
            TransactionLogic.GoToAddTransaction(type, true);
            ((Frame) Window.Current.Content).Navigate(typeof (AddTransaction));
        }
    }
}