using RestaurantManager.Models;
using System.Collections.ObjectModel;

namespace RestaurantManager.ViewModels
{
    public class OrderViewModel : ViewModel
    {
        private ObservableCollection<MenuItem> _menuItems;
        private ObservableCollection<MenuItem> _currentlySelectedMenuItems;

        protected override void OnDataLoaded()
        {
            this.MenuItems = base.Repository.StandardMenuItems;

            this.CurrentlySelectedMenuItems = new ObservableCollection<MenuItem>
            {
                this.MenuItems[3],
                this.MenuItems[5]
            };
        }

        public ObservableCollection<MenuItem> MenuItems
        {
            get { return this._menuItems; }
            set { _menuItems = value; }
        }

        public ObservableCollection<MenuItem> CurrentlySelectedMenuItems
        {
            get { return this._currentlySelectedMenuItems; }
            set { _currentlySelectedMenuItems = value; }
        }
    }
}
