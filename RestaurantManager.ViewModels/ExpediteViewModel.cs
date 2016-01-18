using RestaurantManager.Models;
using System.Collections.ObjectModel;
using Windows.UI.Popups;

namespace RestaurantManager.ViewModels
{
    public class ExpediteViewModel : ViewModel
    {
        public ExpediteViewModel()
        {
            ClearAllOrdersCommand = new DelegateCommand(ClearAllOrdersExecute);
            DeleteCommand = new DelegateCommand(DeleteExecute);
        }

        protected override void OnDataLoaded()
        {
            this.OrderItems = new ObservableCollection<Order>(base.Repository.Orders);
        }

        private ObservableCollection<Order> _orderItems;

        private Order _listViewSelectedOrder;

        public DelegateCommand ClearAllOrdersCommand { get; private set; }

        public DelegateCommand DeleteCommand { get; private set; }

        public ObservableCollection<Order> OrderItems
        {
            get { return this._orderItems; }
            set
            {
                // Ignore testing for same items, since it's a collection and will take too long.
                this._orderItems = value;
                NotifyPropertyChanged();
            }
        }

        public Order ListViewSelectedOrder
        {
            get { return this._listViewSelectedOrder; }
            set
            {
                if (_listViewSelectedOrder != value)
                {
                    _listViewSelectedOrder = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private void ClearAllOrdersExecute()
        {
            MessageDialog messageDialog = new MessageDialog("Are you sure you want to clear all orders?");
            messageDialog.Commands.Add(new UICommand("Yes", new UICommandInvokedHandler(this.CommandInvokedHandler)));
            messageDialog.Commands.Add(new UICommand("No", new UICommandInvokedHandler(this.CommandInvokedHandler)));

            // Set the command that will be invoked by default
            messageDialog.DefaultCommandIndex = 1;

            // Set the command to be invoked when escape is pressed
            messageDialog.CancelCommandIndex = 1;

            // Show the message dialog
            messageDialog.ShowAsync();
        }

        private void CommandInvokedHandler(IUICommand command)
        {
            if (command.Label == "Yes")
            {
                this.Repository.Orders.Clear();
                this.OrderItems.Clear();
                NotifyPropertyChanged("OrderItems");
            }
        }

        private void DeleteExecute()
        {
            new MessageDialog("Hello").ShowAsync();
            // So I really want to give it an "order to delete" parameter and use a CommandParameter and databinding,
            // Alas, Due to the DelegateCommand class, I cannot add parameters to my "_execute" functions.
            
            // In theory, this should never be null, but defensive programming.
            if (this.ListViewSelectedOrder != null)
            {
                this.Repository.Orders.Remove(this.ListViewSelectedOrder);
                this.OrderItems.Remove(this.ListViewSelectedOrder);
                NotifyPropertyChanged("OrderItems");
            }
        }
    }
}
