using System.Collections.Generic;

namespace RestaurantManager.Models
{
    public class OrderDataManager : DataManager
    {       
        protected override void OnDataLoaded()
        {
            this.MenuItems = base.Repository.StandardMenuItems;

            this.CurrentlySelectedMenuItems = new List<MenuItem>
            {
                this.MenuItems[3],
                this.MenuItems[5]
            };
        }

        private List<MenuItem> _menuItems;

        private List<MenuItem> _currentlySelectedMenuItems;

        public List<MenuItem> MenuItems
        {
            get { return this._menuItems; }
            set
            {
                // Ignore testing for same items, since it's a collection and will take too long.
                this._menuItems = value;
                base.OnPropertyChanged();
            }
        }

        public List<MenuItem> CurrentlySelectedMenuItems
        {
            get { return this._currentlySelectedMenuItems; }
            set
            {
                // Ignore testing for same items, since it's a collection and will take too long.
                this._currentlySelectedMenuItems = value;
                base.OnPropertyChanged();
            }
        }
    }
}
