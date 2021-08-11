using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MeetYourDoctorLibrary
{
    public class AppointmentManager
    {
        private List<Doctor> _doctorList;
        private List<Patient> _patientList;
        private List<Appointment> _appointmentList;

        public AppointmentManager()
        {
            _doctorList = new List<Doctor>();
            _patientList = new List<Patient>();
            _appointmentList = new List<Appointment>();
        }

        public void AddDoctor(Doctor doctor)
        {
            _doctorList.Add(doctor);
        }

        public void AddPatient(Patient patient)
        {
            _patientList.Add(patient);
        }

        public void AddAppointment(Appointment appointment)
        {
            _appointmentList.Add(appointment);
        }

        public void DeleteAppointment(int AppointmentId)
        {
            _appointmentList[AppointmentId - 1].AppointmentStatus = Status.Rejected;
        }

        private List<string> DoctorUsernames
        {
            get
            {
                List<string> doctorUsernames = new List<string>();
                foreach (Doctor doctor in _doctorList)
                {
                    doctorUsernames.Add(doctor.Username);
                }
                return doctorUsernames;
            }
        }

        private List<string> PatientUsernames
        {
            get
            {
                List<string> patientUsernames = new List<string>();
                foreach (Doctor doctor in _doctorList)
                {
                    patientUsernames.Add(doctor.Username);
                }
                return patientUsernames;
            }
        }

        public Dictionary<DateTime, Appointment> GetAcceptedAppointmentsForDoctor(string doctorUsername)
        {
            Dictionary<DateTime, Appointment> appointmentByDate = new Dictionary<DateTime, Appointment>();
            foreach (string username in DoctorUsernames)
            {
                if(username == doctorUsername)
                {
                    foreach (Appointment appointment in _appointmentList)
                    {
                        if(appointment.DoctorUsername == doctorUsername)
                        {
                            if (appointment.AppointmentStatus == Status.Accepted)
                            {
                                appointmentByDate.Add(appointment.Date, appointment);
                            }
                        }
                    }
                    return appointmentByDate;
                }
            }
            throw new Exception("Invalid username");
        }

        public Dictionary<int, Appointment> GetPendingAppointmentsForDoctor(string doctorUsername)
        {
            Dictionary<int, Appointment> appointmentById = new Dictionary<int, Appointment>();
            foreach (string username in DoctorUsernames)
            {
                if (username == doctorUsername)
                {
                    foreach (Appointment appointment in _appointmentList)
                    {
                        if (appointment.DoctorUsername == doctorUsername)
                        {
                            if (appointment.AppointmentStatus == Status.Pending)
                            {
                                appointmentById.Add(appointment.Id, appointment);
                            }
                        }
                    }
                    return appointmentById;
                }
            }
            throw new Exception("Invalid username");
        }

        public Dictionary<DateTime, Appointment> GetAppointmentsForPatient(string patientUsername)
        {
            Dictionary<DateTime, Appointment> appointmentByDate = new Dictionary<DateTime, Appointment>();
            foreach (string username in PatientUsernames)
            {
                if (username == patientUsername)
                {
                    foreach (Appointment appointment in _appointmentList)
                    {
                        if (appointment.PatientUsername == patientUsername)
                        {
                            appointmentByDate.Add(appointment.Date, appointment);                           
                        }
                    }
                    return appointmentByDate;
                }
            }
            throw new Exception("Invalid username");
        }
    }
}
