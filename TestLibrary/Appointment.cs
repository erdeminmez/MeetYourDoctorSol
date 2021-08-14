using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace MeetYourDoctorLibrary
{
    public enum Status
    {
        Pending,
        Accepted,
        Rejected
    }
    [DataContract]
    public class Appointment : IComparable<Appointment>
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

        [DataMember(Name = "AppointmentStatus")]
        public Status AppointmentStatus
        {
            get => _appointmentStatus;
            set
            {
                _appointmentStatus = value;
            }
        }

        [DataMember(Name = "AppointmentDate")]
        public DateTime Date
        {
            get => _date;
            set
            {
                if (value > DateTime.Today)
                    _date = value;
                else
                    throw new Exception("Appointment date must be later than today!");
            }
        }

        [DataMember(Name = "AppointmentBranch")]
        public Branch AppointmentBranch
        {
            get => _appointmentBranch;
            set
            {
                _appointmentBranch = value;
            }
        }

        [DataMember(Name = "AppointmentDoctorUsername")]
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

        [DataMember(Name = "AppointmentPatientUsername")]
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

        [DataMember(Name = "AppointmentTimeSlot")]
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

        public int CompareTo(Appointment other)
        {
            if (this.Date > other.Date)
                return 1;
            else if (this.Date < other.Date)
                return -1;
            else
            {
                int thisIndex = TimeSlots().FindIndex(a => a.Contains(this.TimeSlot));
                int otherIndex = TimeSlots().FindIndex(a => a.Contains(other.TimeSlot));
                if (thisIndex > otherIndex)
                    return 1;
                else if (thisIndex < otherIndex)
                    return -1;
                else
                    return 0;
            }                
        }

        public string DoctorName { get; set; }
        
    }
}
