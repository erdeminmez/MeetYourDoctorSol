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
using Windows.UI.Popups;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MeetYourDoctorApp
{
    /// <summary>
    /// Principal Author: Erdem Inmez
    /// Short Description: This page is welcome page for the user. The user can login its account or if it has not an account, it can create an account for itself. This can be doctor or patient account. 
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private static AppointmentManager _appointmentManager = new AppointmentManager();
        private static IDoctorDataManager _doctorDataManager = new DoctorJsonDataManager(ApplicationData.Current.LocalFolder.Path + @"\doctors.json");
        private static IPatientDataManager _patientDataManager = new PatientJsonDataManager(ApplicationData.Current.LocalFolder.Path + @"\patients.json");
        private static IAppointmentDataManager _appointmentDataManager = new AppointmentJsonDataManager(ApplicationData.Current.LocalFolder.Path + @"\appointments.json");

        public static AppointmentManager AppointmentManager => _appointmentManager;
        public static IDoctorDataManager DoctorDataManager => _doctorDataManager;
        public static IPatientDataManager PatientDataManager => _patientDataManager;
        public static IAppointmentDataManager AppointmentDataManager => _appointmentDataManager;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoginBtn.IsEnabled = true;
        }

        private async void OnLogin(object sender, RoutedEventArgs e)
        {
            if ((UserTypeCB.SelectedItem as ComboBoxItem).Content.ToString() == "Doctor")
            {
                if (AppointmentManager.isDoctorAccount(UsernameTB.Text, PasswordTB.Text))
                {
                    ApplicationData.Current.LocalSettings.Values["Username"] = UsernameTB.Text;
                    Frame.Navigate(typeof(DoctorMainPage));
                }
                else
                {
                    MessageDialog messageDialog = new MessageDialog("Invalid entries!");
                    await messageDialog.ShowAsync();
                }

            }
            else if ((UserTypeCB.SelectedItem as ComboBoxItem).Content.ToString() == "Patient")
            {
                if (AppointmentManager.isPatientAccount(UsernameTB.Text, PasswordTB.Text))
                {
                    ApplicationData.Current.LocalSettings.Values["Username"] = UsernameTB.Text;
                    Frame.Navigate(typeof(PatientMainPage));
                }
                else
                {
                    MessageDialog messageDialog = new MessageDialog("Invalid entries!");
                    await messageDialog.ShowAsync();
                }
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

        private void OnPageLoaded(object sender, RoutedEventArgs e)
        {
            try
            {               
                AppointmentManager.ReadDoctorData(_doctorDataManager);
                AppointmentManager.ReadPatientData(_patientDataManager);
                AppointmentManager.ReadAppointmentData(_appointmentDataManager);
            }
            catch (Exception ex)
            {
                TxtError.Text = "The application can be slow at the beginning because it needs to create some files for storage in your pc!";
            }
        }
    }
}
