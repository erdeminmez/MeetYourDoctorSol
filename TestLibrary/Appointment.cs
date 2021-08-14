using System;
using System.Collections.Generic;
using System.Text;

namespace MeetYourDoctorLibrary
{
    public enum Status
    {
        Pending,
        Accepted,
        Rejected
    }
    public class Appointment
    {
        private Status _appointmentStatus;
        private DateTime _date;
        private Branch _appointmentBranch;
        private string _doctorUsername;
        private string _patientUsername;
        private string _timeSlot;

        public Appointment(Status appointmentStatus, DateTime date, Branch appointmentBranch, string doctorUsername, string patientUsername, string timeSlot)
        {
            AppointmentStatus = appointmentStatus;
            Date = date;
            AppointmentBranch = appointmentBranch;
            DoctorUsername = doctorUsername;
            PatientUsername = patientUsername;
            TimeSlot = timeSlot;
        }            

        

        public Status AppointmentStatus
        {
            get => _appointmentStatus;
            set
            {
                _appointmentStatus = value;
            }
        }

        public DateTime Date
        {
            get => _date;
            set
            {
                _date = value;
            }
        }

        public Branch AppointmentBranch
        {
            get => _appointmentBranch;
            set
            {
                _appointmentBranch = value;
            }
        }
        public string DoctorUsername
        {
            get => _doctorUsername;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("You must enter a valid doctor username!");
                }
                _doctorUsername = value;
            }
        }

        public string PatientUsername
        {
            get => _patientUsername;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("You must enter a valid patient username!");
                }
                _patientUsername = value;
            }
        }

        public string TimeSlot
        {
            get => _timeSlot;
            set
            {
                if (TimeSlots().Contains(value))
                    _timeSlot = value;
                else
                    throw new Exception("Time slot is invalid!");
            }
        }

        public static List<string> TimeSlots()
        {
            return new List<string>()
            {
                "8:00 AM",
                "8:30 AM",
                "9:00 AM",
                "9:30 AM",
                "10:00 AM",
                "10:30 AM",
                "11:00 AM",
                "11:30 AM",
                "1:00 PM",
                "1:30 PM",
                "2:00 PM",
                "2:30 PM",
                "3:00 PM",
                "3:30 PM",
                "4:00 PM",
                "4:30 PM"
            };
        }
    }
}
