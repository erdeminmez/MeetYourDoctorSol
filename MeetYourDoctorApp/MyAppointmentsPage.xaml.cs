using MeetYourDoctorLibrary;
using System;
using System.Collections.Generic;
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
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MyAppointmentsPage : Page
    {
        private List<Appointment> _appointments = new List<Appointment>();
        public MyAppointmentsPage()
        {
            var settingValues = ApplicationData.Current.LocalSettings.Values;
            string patientUsername = "";
            if (settingValues.ContainsKey("Username"))
                patientUsername = settingValues["Username"].ToString();
            _appointments = MainPage.AppointmentManager.AppointmentsOfPatient(patientUsername);
            foreach (Appointment appointment in _appointments)
            {
                appointment.DoctorName = MainPage.AppointmentManager.GetDoctorName(appointment.DoctorUsername);
            }
            this.InitializeComponent();
        }

        private async void OnDoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            Appointment appointment = LstAppointments.SelectedItem as Appointment;
            if (appointment != null)
            {
                MessageDialog messageDialog = new MessageDialog(MainPage.AppointmentManager.GetDoctorInfo(appointment.DoctorUsername));
                await messageDialog.ShowAsync();
            }
        }
    }
}
