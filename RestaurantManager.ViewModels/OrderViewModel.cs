using RestaurantManager.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RestaurantManager.ViewModels
{
    public class OrderViewModel : ViewModel
    {
        protected override void OnDataLoaded()
        {
            this.MenuItems = new ObservableCollection<MenuItem>(base.Repository.StandardMenuItems);

            this.CurrentlySelectedMenuItems = new ObservableCollection<MenuItem>
            {
                this.MenuItems[3],
                this.MenuItems[5]
            };
        }

        private ObservableCollection<MenuItem> _menuItems;

        private ObservableCollection<MenuItem> _currentlySelectedMenuItems;

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
    }
}
