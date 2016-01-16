using RestaurantManager.Models;
using System.Collections.ObjectModel;

namespace RestaurantManager.ViewModels
{
    public class ExpediteViewModel : ViewModel
    {
        protected override void OnDataLoaded()
        {
            NotifyPropertyChanged("OrderItems");
        }

        public ObservableCollection<Order> OrderItems
        {
            get { return base.Repository.Orders; }
        }
    }
}
