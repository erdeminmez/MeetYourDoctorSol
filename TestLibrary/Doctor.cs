using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

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

    [DataContract]
    public class Doctor
    {
        private string _username;
        private string _password;
        private string _fullName;
        private string _email;
        private string _phone;
        private string _postalCode;
        private string _sin;
        private Branch _branch;

        public Doctor(string username, string password, string fullName, string email, string phone, string postalCode, string sin, Branch branch)
        {
            Username = username;
            Password = password;
            FullName = fullName;
            Email = email;
            Phone = phone;
            PostalCode = postalCode;
            Sin = sin;
            Branch = branch;
        }

        [DataMember (Name = "DoctorUsername")]
        public string Username
        {
            get => _username;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("You must enter a username that contains at least 5 characters!");
                }
                else if (value.Length < 5)
                {
                    throw new Exception("You must enter a username that contains at least 5 characters!");
                }
                else
                {
                    _username = value;
                }
            }
        }

        [DataMember (Name = "DoctorPassword")]
        public string Password
        {
            get => _password;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("You must enter a password that contains at least 5 characters!");
                }
                else if (value.Length < 5)
                {
                    throw new Exception("You must enter a password that contains at least 5 characters!");
                }
                else
                {
                    _password = value;
                }
            }
        }

        [DataMember (Name = "DoctorFullName")]
        public string FullName
        {
            get => _fullName;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("You must enter your full name!");
                }
                else
                {
                    _fullName = value;
                }
            }
        }

        [DataMember (Name = "DoctorEmail")]
        public string Email
        {
            get => _email;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("You must enter your email address!");
                }
                else
                {
                    _email = value;
                }
            }
        }

        [DataMember(Name = "DoctorPhone")]
        public string Phone
        {
            get => _phone;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("You must enter a contact number that contains 10 digits!");
                }
                else if (value.Length != 10)
                {
                    throw new Exception("You must enter a contact number that contains 10 digits!");
                }
                else
                {
                    if (value.All(char.IsDigit))
                        _phone = value;
                    else
                        throw new Exception("You must enter a contact number that contains 10 digits!");
                }
            }
        }

        [DataMember(Name = "DoctorPostalCode")]
        public string PostalCode
        {
            get => _postalCode;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("You must enter a postal code that contains 6 characters!");
                }
                else if (value.Length != 6)
                {
                    throw new Exception("You must enter a postal code that contains 6 characters!");
                }
                else
                {
                    _postalCode = value;
                }
            }
        }

        [DataMember(Name = "DoctorSIN")]
        public string Sin
        {
            get => _sin;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("You must enter a SIN that contains 9 digits!");
                }
                else if (value.Length != 9)
                {
                    throw new Exception("You must enter a SIN that contains 9 digits!");
                }
                else
                {
                    if (value.All(char.IsDigit))
                        _sin = value;
                    else
                        throw new Exception("You must enter a SIN that contains 9 digits!");
                }
            }
        }

        [DataMember(Name = "DoctorBranch")]
        public Branch Branch
        {
            get => _branch;
            set
            {
                _branch = value;
            }
        }

        public override bool Equals(object obj)
        {
            Doctor doctor = obj as Doctor;
            if (doctor != null)
            {
                if (doctor.Username == Username)
                    return true;
            }
            return false;
        }

        public static List<Branch> Branches()
        {
            return Enum.GetValues(typeof(Branch)).Cast<Branch>().ToList();
        }

        public bool isDoctorAccount(string username, string password)
        {
            if (username == Username && password == Password)
                return true;
            return false;
        }

        public override string ToString()
        {
            return $"Full Name: {FullName}\nBranch: {Branch}\nContact Number: {Phone}\nEmail Address: {Email}\nPostal Code: {PostalCode}";
        }
    }
}
