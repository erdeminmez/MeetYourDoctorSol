﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MeetYourDoctorApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoginBtn.IsEnabled = true;
        }

        private void OnLogin(object sender, RoutedEventArgs e)
        {
            if ((UserTypeCB.SelectedItem as ComboBoxItem).Content.ToString() == "Doctor")
            {
                Frame.Navigate(typeof(DoctorMainPage));
            }
            else if ((UserTypeCB.SelectedItem as ComboBoxItem).Content.ToString() == "Patient")
            {
                Frame.Navigate(typeof(PatientMainPage));
            }
        }

        private void OnCreateDoctorAcc(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CreateDoctorPage));
        }

        private void OnCreatePatientAcc(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CreatePatientPage));
        }
    }
}
