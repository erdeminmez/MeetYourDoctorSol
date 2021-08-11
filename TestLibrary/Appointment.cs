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
        private string _doctorUsername;
        private string _patientUsername;

        public Appointment(int id, Status appointmentStatus, DateTime date, Branch appointmentBranch, string doctorUsername, string patientUsername)
        {
            _id = id;
            AppointmentStatus = appointmentStatus;
            Date = date;
            AppointmentBranch = appointmentBranch;
            DoctorUsername = doctorUsername;
            PatientUsername = patientUsername;
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
    }
}
