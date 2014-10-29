﻿using MoneyManager.Business.Logic;
using MoneyManager.Business.Src;
using Windows.ApplicationModel.Background;

namespace MoneyManager.Tasks.TransactionsWp
{
    public sealed class TransactionTask : IBackgroundTask
    {
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            new BackgroundTaskViewModelLocator();
            RecurringTransactionLogic.CheckRecurringTransactions();
        }
    }
}