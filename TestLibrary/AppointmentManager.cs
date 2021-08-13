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
    }
}
