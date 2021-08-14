﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
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
    public sealed partial class DoctorMainPage : Page
    {
        public DoctorMainPage()
        {
            this.InitializeComponent();
        }

        private void OnNavigationRequested(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (sender.SelectedItem == MySchedule)
            {
                DoctorNavigationFrame.Navigate(typeof(MySchedulePage));
            }
            else if (sender.SelectedItem == AppointmentRequests)
            {
                DoctorNavigationFrame.Navigate(typeof(AppointmentRequestsPage));
            }
            else if (sender.SelectedItem == DoctorLogout)
            {
                if (Frame.CanGoBack)
                {
                    Frame.GoBack();
                }
            }
        }

        private void OnPageLoaded(object sender, RoutedEventArgs e)
        {
            var settingValues = ApplicationData.Current.LocalSettings.Values;
            string username = "";
            if (settingValues.ContainsKey("Username"))
            {
                username = settingValues["Username"].ToString();
                TxtDoc.Text = username;
            }

        }
    }
}
