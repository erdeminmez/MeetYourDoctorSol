using MeetYourDoctorLibrary;
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
    public sealed partial class CreatePatientPage : Page
    {
        public CreatePatientPage()
        {
            this.InitializeComponent();
        }

        private Patient CapturePatientRecord()
        {
            string username = PatientUsernameTB.Text;
            string password = PatientPasswordTB.Text;
            string fullname = PatientFullNameTB.Text;
            string email = PatientEmailTB.Text;
            string phone = PatientPhoneTB.Text;
            string postalcode = PatientPostalCodeTB.Text;
            string healthCardNumber = HealthCardNumberTB.Text;
            DateTime birthday = BirthdayDP.Date.Date;
            return new Patient(username, password, fullname, email, phone, postalcode, healthCardNumber, birthday);
        }

        private async void OnCreateAccount(object sender, RoutedEventArgs e)
        {
            try
            {
                Patient patient = CapturePatientRecord();
                MainPage.AppointmentManager.EnrollPatient(patient);
                MainPage.AppointmentManager.SavePatientData(MainPage.PatientDataManager);

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

        private void OnSelectedDateChanged(DatePicker sender, DatePickerSelectedValueChangedEventArgs args)
        {
            PatientCreateBtn.IsEnabled = true;
        }
    }
}
