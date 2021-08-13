using System;
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
using MeetYourDoctorLibrary;
using MeetYourDoctorData;
using Windows.Storage;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MeetYourDoctorApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private static AppointmentManager _appointmentManager = new AppointmentManager();
        private static IDoctorDataManager _doctorDataManager = new DoctorJsonDataManager(ApplicationData.Current.LocalFolder.Path + @"\doctors.json");
        private static IPatientDataManager _patientDataManager = new PatientJsonDataManager(ApplicationData.Current.LocalFolder.Path + @"\patients.json");

        public static AppointmentManager AppointmentManager => _appointmentManager;
        public static IDoctorDataManager DoctorDataManager => _doctorDataManager;
        public static IPatientDataManager PatientDataManager => _patientDataManager;

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
