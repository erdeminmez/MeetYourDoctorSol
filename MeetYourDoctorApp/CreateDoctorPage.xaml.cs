﻿using MeetYourDoctorLibrary;
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
    /// Principal Author: Erdem Inmez
    /// Short Description: This page is used to create a doctor account.
    /// </summary>
    public sealed partial class CreateDoctorPage : Page
    {
        private List<Branch> _branches = Doctor.Branches();

        public CreateDoctorPage()
        {
            this.InitializeComponent();
        }

        private Doctor CaptureDoctorRecord()
        {
            string username = DoctorUsernameTB.Text;
            string password = DoctorPasswordTB.Text;
            string fullname = DoctorFullNameTB.Text;
            string email = DoctorEmailTB.Text;
            string phone = DoctorPhoneTB.Text;
            string postalcode = DoctorPostalCodeTB.Text;
            string sin = SinTB.Text;
            Branch branch = (Branch)Enum.Parse(typeof(Branch), BranchCB.SelectedItem.ToString());
            return new Doctor(username, password, fullname, email, phone, postalcode, sin, branch);
        }

        private async void OnCreateAccount(object sender, RoutedEventArgs e)
        {
            try
            {
                Doctor doctor = CaptureDoctorRecord();
                MainPage.AppointmentManager.EnrollDoctor(doctor);
                MainPage.AppointmentManager.SaveDoctorData(MainPage.DoctorDataManager);

                MessageDialog messageDialog = new MessageDialog("Your account was created successfully.");
                await messageDialog.ShowAsync();

                if (Frame.CanGoBack)
                {
                    Frame.GoBack();
                }
            }
            catch (Exception ex)
            {
                MessageDialog messageDialog = new MessageDialog($"{ex.Message}");
                await messageDialog.ShowAsync();
            }
        }

        private void OnBack(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DoctorCreateBtn.IsEnabled = true;
        }
    }
}
