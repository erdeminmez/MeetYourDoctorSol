using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MeetYourDoctorLibrary
{
    public class AppointmentManager
    {
        private List<Doctor> _doctors = new List<Doctor>();
        private List<Patient> _patients = new List<Patient>();
        private List<Appointment> _appointments = new List<Appointment>();

        public ReadOnlyCollection<Doctor> Doctors => _doctors.AsReadOnly();
        public ReadOnlyCollection<Patient> Patients => _patients.AsReadOnly();
        public ReadOnlyCollection<Appointment> Appointments => _appointments.AsReadOnly();

        public void EnrollDoctor(Doctor newDoctor)
        {
            if (Doctors.Contains(newDoctor))
                throw new Exception("This username is already taken!");
            else
                _doctors.Add(newDoctor);
        }

        public void SaveDoctorData(IDoctorDataManager doctorDataManager)
        {
            doctorDataManager.SaveDoctorData(_doctors);
        }

        public void ReadDoctorData(IDoctorDataManager doctorDataManager)
        {
            List<Doctor> doctors = doctorDataManager.ReadDoctorData();

            if (doctors != null)
                _doctors = doctors;
        }

        public void EnrollPatient(Patient newPatient)
        {
            if (Patients.Contains(newPatient))
                throw new Exception("This username is already taken!");
            else
                _patients.Add(newPatient);
        }

        public void SavePatientData(IPatientDataManager patientDataManager)
        {
            patientDataManager.SavePatientData(_patients);
        }

        public void ReadPatientData(IPatientDataManager patientDataManager)
        {
            List<Patient> patients = patientDataManager.ReadPatientData();

            if (patients != null)
                _patients = patients;
        }

        public void EnrollAppointment(Appointment newAppointment)
        {
            if (Appointments.Contains(newAppointment))
                throw new Exception("This appointment is already created!");
            else
                _appointments.Add(newAppointment);
        }

        public void SaveAppointmentData(IAppointmentDataManager appointmentDataManager)
        {
            appointmentDataManager.SaveAppointmentData(_appointments);
        }

        public void ReadAppointmentData(IAppointmentDataManager appointmentDataManager)
        {
            List<Appointment> appointments = appointmentDataManager.ReadAppointmentData();

            if (appointments != null)
                _appointments = appointments;
        }

        public bool isDoctorAccount(string username, string password)
        {
            foreach (Doctor doctor in Doctors)
            {
                if (doctor.isDoctorAccount(username, password))
                    return true;
            }
            return false;
        }

        public bool isPatientAccount(string username, string password)
        {
            foreach (Patient patient in Patients)
            {
                if (patient.isPatientAccount(username, password))
                    return true;
            }
            return false;
        }

        public List<Doctor> ShowDoctorsOfBranch(Branch branch)
        {
            List<Doctor> doctorsOfBranch = new List<Doctor>();
            foreach (Doctor doctor in Doctors)
            {
                if (doctor.Branch == branch)
                    doctorsOfBranch.Add(doctor);
            }
            return doctorsOfBranch;
        }

        public List<string> AvailableTimeSlots(string doctorUsername, DateTime date)
        {
            List<string> availableTimeSlots = Appointment.TimeSlots();
            foreach (Appointment appointment in Appointments)
            {
                if(appointment.DoctorUsername == doctorUsername && appointment.Date == date)
                {
                    availableTimeSlots.Remove(appointment.TimeSlot);
                }
            }
            return availableTimeSlots;
        }
    }
}
