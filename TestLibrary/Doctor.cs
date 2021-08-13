using System;
using System.Collections.Generic;
using System.Linq;
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

        public string PostalCode
        {
            get => _postalCode;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("You must enter a contact number that contains 6 characters!");
                }
                else if (value.Length != 6)
                {
                    throw new Exception("You must enter a contact number that contains 6 characters!");
                }
                else
                {
                    _postalCode = value;
                }
            }
        }

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
        
        public Branch Branch
        {
            get => _branch;
            set
            {
                _branch = value;
            }
        }
    }
}
