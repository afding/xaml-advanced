using System.Collections.Generic;

namespace RestaurantManager.Models
{
    public class ExpediteDataManager : DataManager
    {
        protected override void OnDataLoaded()
        {
            // Note to self: I might be changing this too much from the original startup project.
            // However, I do need to set OrderItems for OnPropertyChanged to be triggered, so *shrugs*.
            this.OrderItems = base.Repository.Orders;
        }

        private List<Order> _orderItems;

        public List<Order> OrderItems
        {
            get { return this._orderItems; }
            set
            {
                // Ignore testing for same items, since it's a collection and will take too long.
                this._orderItems = value;
                base.OnPropertyChanged();
            }
        }
    }
}
