using MeetYourDoctorLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
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
    /// Short Description: This page is an acception or rejection page for coming appointent requests to the doctor who is owner of the account. Doctor can accept or reject appointments here.
    /// </summary>
    public sealed partial class AppointmentRequestsPage : Page
    {
        private ObservableCollection<Appointment> _appointments = new ObservableCollection<Appointment>();

        public AppointmentRequestsPage()
        {
            var settingValues = ApplicationData.Current.LocalSettings.Values;
            string doctorUsername = "";
            if (settingValues.ContainsKey("Username"))
                doctorUsername = settingValues["Username"].ToString();
            _appointments = MainPage.AppointmentManager.PendingAppointmentsOfDoctor(doctorUsername);
            foreach (Appointment appointment in _appointments)
            {
                appointment.PatientName = MainPage.AppointmentManager.GetPatientName(appointment.PatientUsername);
                appointment.PatientBirthday = MainPage.AppointmentManager.GetPatientBirthday(appointment.PatientUsername);
            }
            this.InitializeComponent();
        }

        private async void OnAccept(object sender, RoutedEventArgs e)
        {
            Appointment appointment = LstAppointments.SelectedItem as Appointment;
            if (appointment != null)
            {
                _appointments.RemoveAt(LstAppointments.SelectedIndex);
                MainPage.AppointmentManager.UpdateStatusOfAppointment(appointment, Status.Accepted);
                MainPage.AppointmentManager.SaveAppointmentData(MainPage.AppointmentDataManager);
                AcceptBtn.IsEnabled = false;
                RejectBtn.IsEnabled = false;
                MessageDialog messageDialog = new MessageDialog($"The appointment is accepted!");
                await messageDialog.ShowAsync();               
            }       
        }

        private async void OnReject(object sender, RoutedEventArgs e)
        {
            Appointment appointment = LstAppointments.SelectedItem as Appointment;
            if (appointment != null)
            {
                _appointments.RemoveAt(LstAppointments.SelectedIndex);
                MainPage.AppointmentManager.UpdateStatusOfAppointment(appointment, Status.Rejected);
                MainPage.AppointmentManager.SaveAppointmentData(MainPage.AppointmentDataManager);
                AcceptBtn.IsEnabled = false;
                RejectBtn.IsEnabled = false;
                MessageDialog messageDialog = new MessageDialog($"The appointment is rejected!");
                await messageDialog.ShowAsync();
            }
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LstAppointments.SelectedItem != null)
            {
                AcceptBtn.IsEnabled = true;
                RejectBtn.IsEnabled = true;
            }           
        }
    }
}
