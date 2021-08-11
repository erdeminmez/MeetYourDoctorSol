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
        private int _id;
        private Status _appointmentStatus;
        private DateTime _date;
        private Branch _appointmentBranch;
        private string _doctorName;
        private string _patientName;

        public Appointment(int id, Status appointmentStatus, DateTime date, Branch appointmentBranch, string doctorName, string patientName)
        {
            _id = id;
            AppointmentStatus = appointmentStatus;
            Date = date;
            AppointmentBranch = appointmentBranch;
            DoctorName = doctorName;
            PatientName = patientName;
        }            

        public int Id
        {
            get => _id;
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
        public string DoctorName
        {
            get => _doctorName;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("You must enter a valid doctor name!");
                }
                _doctorName = value;
            }
        }

        public string PatientName
        {
            get => _patientName;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("You must enter a valid patient name!");
                }
                _patientName = value;
            }
        }
    }
}
