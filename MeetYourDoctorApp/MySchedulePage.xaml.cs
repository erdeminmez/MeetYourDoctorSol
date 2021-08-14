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
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MySchedulePage : Page
    {
        private ObservableCollection<DoctorScheduleItem> _schedule = new ObservableCollection<DoctorScheduleItem>();
        private DateTime _selectedDate;
        private string _doctorUsername = "";
        private int _index;
        private string _timeSlot;
        private string _patientName;

        public MySchedulePage()
        {
            foreach (string timeSlot in Appointment.TimeSlots())
            {
                DoctorScheduleItem item = new DoctorScheduleItem(timeSlot, "");
                _schedule.Add(item);
            }
            this.InitializeComponent();
        }

        private void OnDateChanged(DatePicker sender, DatePickerSelectedValueChangedEventArgs args)
        {
            _schedule.Clear();
            foreach (string timeSlot in Appointment.TimeSlots())
            {
                DoctorScheduleItem item = new DoctorScheduleItem(timeSlot, "");
                _schedule.Add(item);
            }
            _selectedDate = DateDP.Date.Date;
            var settingValues = ApplicationData.Current.LocalSettings.Values;
            if (settingValues.ContainsKey("Username"))
                _doctorUsername = settingValues["Username"].ToString();
            foreach (Appointment appointment in MainPage.AppointmentManager.AcceptedAppointmentsOfDoctor(_doctorUsername, _selectedDate))
            {
                for (int i = 0; i < _schedule.Count; i++)
                {
                    if(_schedule[i].TimeSlot == appointment.TimeSlot)
                    {
                        _index = i;
                        _timeSlot = appointment.TimeSlot;
                        _patientName = MainPage.AppointmentManager.GetPatientName(appointment.PatientUsername);
                        _schedule.RemoveAt(_index);
                        _schedule.Insert(_index, new DoctorScheduleItem(_timeSlot, _patientName));
                    }
                }
            }
        }

        private async void OnInfo(object sender, RoutedEventArgs e)
        {
            DoctorScheduleItem item = LstSchedule.SelectedItem as DoctorScheduleItem;
            if (item != null)
            {
                MessageDialog messageDialog = new MessageDialog(MainPage.AppointmentManager.GetPatientInfo(item.PatientName));
                await messageDialog.ShowAsync();
            }
        }

        private async void OnCancel(object sender, RoutedEventArgs e)
        {
            DoctorScheduleItem item = LstSchedule.SelectedItem as DoctorScheduleItem;
            if (item != null)
            {
                int i = LstSchedule.SelectedIndex;
                string str = _schedule[i].TimeSlot;
                _schedule.RemoveAt(i);
                _schedule.Insert(i, new DoctorScheduleItem(str, ""));
                Appointment appointment = MainPage.AppointmentManager.GetAppointment(_doctorUsername, _selectedDate, _schedule[i].TimeSlot);
                MainPage.AppointmentManager.UpdateStatusOfAppointment(appointment, Status.Rejected);
                MainPage.AppointmentManager.SaveAppointmentData(MainPage.AppointmentDataManager);
                GetInfoBtn.IsEnabled = false;
                CancelBtn.IsEnabled = false;
                MessageDialog messageDialog = new MessageDialog($"The appointment is canceled!");
                await messageDialog.ShowAsync();
            }
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DoctorScheduleItem item = LstSchedule.SelectedItem as DoctorScheduleItem;
            if (item != null)
            {
                GetInfoBtn.IsEnabled = true;
                CancelBtn.IsEnabled = true;
            }          
        }
    }
}
