using Microsoft.Xaml.Interactivity;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace RestaurantManager.Extensions
{
    public class RightClickMessageDialogBehavior : DependencyObject, IBehavior
    {
        public string Title { get; set; }

        public string Message { get; set; }

        public DependencyObject AssociatedObject { get; private set; }

        public void Attach(DependencyObject associatedObject)
        {
            this.AssociatedObject = associatedObject;
            if (this.AssociatedObject is Page)
            {
                (this.AssociatedObject as Page).RightTapped += RightClickBehavior_RightTapped;
            }
        }

        private void RightClickBehavior_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            new MessageDialog(Message, Title).ShowAsync();
        }

        public void Detach()
        {
            (this.AssociatedObject as Page).RightTapped -= RightClickBehavior_RightTapped;
        }
    }
}
