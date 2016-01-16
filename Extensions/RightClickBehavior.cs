using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Microsoft.Xaml.Interactivity;
using Windows.UI.Xaml.Controls;
using Windows.UI.Popups;
using Windows.UI.Xaml.Input;

// Note we needed to add a reference to Universal Windows > Extensions > Behaviors.sdk
namespace Extensions
{
    public class RightClickBehavior : DependencyObject, IBehavior
    {
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
            new MessageDialog("Thank you for trying out this demo!", "Thank you!").ShowAsync();
        }

        public void Detach()
        {
            (this.AssociatedObject as Page).RightTapped -= RightClickBehavior_RightTapped;
        }
    }
}
