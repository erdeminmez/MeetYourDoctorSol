using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MeetYourDoctorApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AppointmentRequestsPage : Page
    {
        public AppointmentRequestsPage()
        {
            this.InitializeComponent();
        }

        private async void OnAccept(object sender, DoubleTappedRoutedEventArgs e)
        {
            MessageDialog messageDialog = new MessageDialog("Do you confirm to accept this appointment?");
            messageDialog.Commands.Add(new UICommand("Yes") { Id = 0 });
            messageDialog.Commands.Add(new UICommand("No") { Id = 1 });
            messageDialog.DefaultCommandIndex = 0;
            messageDialog.CancelCommandIndex = 1;
            await messageDialog.ShowAsync();
        }

        private async void OnReject(object sender, DoubleTappedRoutedEventArgs e)
        {
            MessageDialog messageDialog = new MessageDialog("Do you confirm to reject this appointment?");
            messageDialog.Commands.Add(new UICommand("Yes") { Id = 0 });
            messageDialog.Commands.Add(new UICommand("No") { Id = 1 });
            messageDialog.DefaultCommandIndex = 0;
            messageDialog.CancelCommandIndex = 1;
            await messageDialog.ShowAsync();
        }
    }
}
