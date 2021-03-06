using System;
using System.Threading.Tasks;
using MoneyFox.Business.Extensions;
using MoneyFox.Business.Messages;
using MoneyFox.Foundation.Resources;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;

namespace MoneyFox.Business.ViewModels
{
    /// <summary>
    ///     Reprsents the statistic view.
    /// </summary>
    public abstract class StatisticViewModel : MvxViewModel
    {
        //this token ensures that we will be notified when a message is sent.
        private readonly MvxSubscriptionToken token;

        private DateTime startDate;
        private DateTime endDate;

        /// <summary>
        ///     Creates a StatisticViewModel Object and passes the first and last day of the current month
        ///     as a start and end date.
        /// </summary>
        protected StatisticViewModel(IMvxMessenger messenger)
            : this(DateTime.Today.GetFirstDayOfMonth(), DateTime.Today.GetLastDayOfMonth(), messenger)
        {
        }

        /// <summary>
        ///     Creates a Statistic ViewModel with custom start and end date
        /// </summary>
        /// <param name="startDate">Start date to select data from.</param>
        /// <param name="endDate">End date to select date from.</param>
        protected StatisticViewModel(DateTime startDate, DateTime endDate, IMvxMessenger messenger)
        {
            StartDate = startDate;
            EndDate = endDate;

            token = messenger.Subscribe<DateSelectedMessage>(message =>
            {
                StartDate = message.StartDate;
                EndDate = message.EndDate;
                Load();
            });
        }

        /// <summary>
        ///     Loads the data with the current start and end date.
        /// </summary>
        public MvxAsyncCommand LoadCommand => new MvxAsyncCommand(Load);

        /// <summary>
        ///     Startdate for a custom statistic
        /// </summary>
        public DateTime StartDate
        {
            get => startDate;
            set
            {
                startDate = value;
                RaisePropertyChanged();
                // ReSharper disable once ExplicitCallerInfoArgument
                RaisePropertyChanged(nameof(Title));
            }
        }

        /// <summary>
        ///     Enddate for a custom statistic
        /// </summary>
        public DateTime EndDate
        {
            get => endDate;
            set
            {
                endDate = value; 
                RaisePropertyChanged();
                // ReSharper disable once ExplicitCallerInfoArgument
                RaisePropertyChanged(nameof(Title));
            }
        }

        /// <summary>
        ///     Returns the title for the CategoryViewModel view
        /// </summary>
        public string Title => Strings.StatisticTitle + " " + StartDate.ToString("d") +
                               " - " +
                               EndDate.ToString("d");

        protected abstract Task Load();
    }
}