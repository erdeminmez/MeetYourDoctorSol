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
    /// Principal Author: Erdem Inmez
    /// Short Description: This page is appointment creation page for the patient.
    /// </summary>
    public sealed partial class RequestAppointmentPage : Page
    {
        private List<Branch> _branches = Doctor.Branches();
        private List<Doctor> _doctors = new List<Doctor>();
        private Doctor _selectedDoctor;
        private DateTime _selectedDate;
        
        public RequestAppointmentPage()
        {
            this.InitializeComponent();
        }

        private Appointment CaptureAppointmentRecord()
        {
            Branch appointmentBranch = (Branch)Enum.Parse(typeof(Branch), BranchCB.SelectedItem.ToString());
            string doctorUsername = _selectedDoctor.Username;
            DateTime date = _selectedDate;
            string timeSlot = TimeCB.SelectedItem.ToString();
            var settingValues = ApplicationData.Current.LocalSettings.Values;
            string patientUsername = "";
            if (settingValues.ContainsKey("Username"))           
                patientUsername = settingValues["Username"].ToString();
            Status appointmentStatus = Status.Pending;
            return new Appointment(appointmentStatus, date, appointmentBranch, doctorUsername, patientUsername, timeSlot);
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BranchCB.SelectedItem != null)
            {
                _doctors = MainPage.AppointmentManager.ShowDoctorsOfBranch((Branch)Enum.Parse(typeof(Branch), BranchCB.SelectedItem.ToString()));
                DoctorCB.ItemsSource = _doctors;
                DoctorCB.DisplayMemberPath = "FullName";
                DoctorCB.IsEnabled = true;
                AppointmentDateDP.IsEnabled = false;
                TimeCB.IsEnabled = false;
                CreateAppointmateBtn.IsEnabled = false;
            }           
        }

        private void OnDoctorSelection(object sender, SelectionChangedEventArgs e)
        {
            if (DoctorCB.SelectedItem != null)
            {
                _selectedDoctor = DoctorCB.SelectedItem as Doctor;
                if (_selectedDoctor != null)
                    AppointmentDateDP.IsEnabled = true;
                TimeCB.IsEnabled = false;
                CreateAppointmateBtn.IsEnabled = false;
            }           
        }

        private void OnSelectionDateChanged(DatePicker sender, DatePickerSelectedValueChangedEventArgs args)
        {
            if (AppointmentDateDP.SelectedDate != null)
            {
                _selectedDate = AppointmentDateDP.Date.Date;
                TimeCB.ItemsSource = MainPage.AppointmentManager.AvailableTimeSlots(_selectedDoctor.Username, _selectedDate);
                TimeCB.IsEnabled = true;
                CreateAppointmateBtn.IsEnabled = false;
            }
        }

        private void OnTimeSelected(object sender, SelectionChangedEventArgs e)
        {
            if (TimeCB.SelectedItem != null)
                CreateAppointmateBtn.IsEnabled = true;
        }

        private async void OnCreateAppointment(object sender, RoutedEventArgs e)
        {
            try
            {
                Appointment appointment = CaptureAppointmentRecord();
                MainPage.AppointmentManager.EnrollAppointment(appointment);
                MainPage.AppointmentManager.SaveAppointmentData(MainPage.AppointmentDataManager);

                MessageDialog messageDialog = new MessageDialog("Your appointment was created successfully.");
                await messageDialog.ShowAsync();
                
                UpdatePage();
            }
            catch (Exception ex)
            {
                MessageDialog messageDialog = new MessageDialog($"{ex.Message}");
                await messageDialog.ShowAsync();
            }
        }

        private void UpdatePage()
        {
            BranchCB.SelectedItem = null;
            DoctorCB.SelectedItem = null;
            DoctorCB.IsEnabled = false;
            AppointmentDateDP.SelectedDate = null;
            AppointmentDateDP.IsEnabled = false;
            TimeCB.SelectedItem = null;
            TimeCB.IsEnabled = false;
            CreateAppointmateBtn.IsEnabled = false;
        }      
    }
}
