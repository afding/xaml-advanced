using RestaurantManager.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI.Popups;

namespace RestaurantManager.ViewModels
{
    public class OrderViewModel : ViewModel
    {
        public OrderViewModel()
        {
            AddToOrderCommand = new DelegateCommand(AddToOrderExecute);
            SubmitOrderCommand = new DelegateCommand(SubmitOrderExecute);
        }

        protected override void OnDataLoaded()
        {
            // For some reason, the model thinks base.Repository.StandardMenuItems (or somewhere along the line) is null.
            // Shrugs.
            this.MenuItems = new ObservableCollection<MenuItem>(base.Repository.StandardMenuItems);
            this.CurrentlySelectedMenuItems = new ObservableCollection<MenuItem>();
        }
        
        private ObservableCollection<MenuItem> _menuItems;

        private ObservableCollection<MenuItem> _currentlySelectedMenuItems;

        private MenuItem _listViewSelectedMenuItem;

        private string _specialRequests;

        public DelegateCommand AddToOrderCommand { get; private set; }

        public DelegateCommand SubmitOrderCommand { get; private set; }

        public ObservableCollection<MenuItem> MenuItems
        {
            get { return this._menuItems; }
            set
            {
                // Ignore testing for same items, since it's a collection and will take too long.
                this._menuItems = value;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<MenuItem> CurrentlySelectedMenuItems
        {
            get { return this._currentlySelectedMenuItems; }
            set
            {
                // Ignore testing for same items, since it's a collection and will take too long.
                this._currentlySelectedMenuItems = value;
                NotifyPropertyChanged();
            }
        }

        public MenuItem ListViewSelectedMenuItem
        {
            get { return this._listViewSelectedMenuItem; }
            set
            {
                if (this._listViewSelectedMenuItem != value)
                {
                    this._listViewSelectedMenuItem = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string SpecialRequests
        {
            get { return _specialRequests; }
            set
            {
                if (_specialRequests != value)
                {
                    _specialRequests = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private void AddToOrderExecute()
        {
            if (this.ListViewSelectedMenuItem != null)
            {
                this.CurrentlySelectedMenuItems.Add(this.ListViewSelectedMenuItem);
                // Not sure if this line is necessary, but we're not really "set"ting CurrentlySelectedMenuItems,
                // so to be safe, I raise the PropertyChanged event.
                NotifyPropertyChanged("CurrentlySelectedMenuItems");
            }
            else
            {
                new MessageDialog("Oops. Please select a menu item first.").ShowAsync();
            }
        }

        private void SubmitOrderExecute()
        {
            // We ignore "orders" with 0 items.
            if (this.CurrentlySelectedMenuItems != null & this.CurrentlySelectedMenuItems.Count != 0)
            {
                Order newOrder = new Order { Items = new List<MenuItem>(this.CurrentlySelectedMenuItems), SpecialRequests = this.SpecialRequests };
                base.Repository.Orders.Add(newOrder);
                ClearCurrentOrderItems();
                // I doubt I need to call PropertyChanged for the Orders in the other ExpediteViewModel.
            }
            else
            {
                new MessageDialog("Oops. Please add some items to the order first.").ShowAsync();
            }
        }

        // Resets the Special Requests and Order Items controls
        private void ClearCurrentOrderItems()
        {
            this.CurrentlySelectedMenuItems.Clear();
            this.SpecialRequests = string.Empty;
            NotifyPropertyChanged("CurrentlySelectedMenuItems");
            NotifyPropertyChanged("SpecialRequests");
        }
    }
}
