using System;
using System.Collections.Generic;
using System.Text;

namespace MeetYourDoctorLibrary
{
    public enum Branch
    {
        Audiologist,
        Allergist,
        Anesthesiologist,
        Cardiologist,
        Dentist,
        Dermatologist,
        Endocrinologist,
        Epidemiologist,
        Gynecologist,
        Immunologist
    }

    public class Doctor : User
    {
        private Branch _doctorBranch;

        public Doctor(string username, string password, string fullName, string email, string phone, string address, Branch doctorBranch) : base(username, password, fullName, email, phone, address)
        {
            DoctorBranch = doctorBranch;
        }

        public Branch DoctorBranch
        {
            get => _doctorBranch;
            set
            {
                _doctorBranch = value;
            }
        }
    }
}
