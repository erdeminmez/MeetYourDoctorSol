using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace MeetYourDoctorLibrary
{
    [DataContract]
    public class Patient
    {
        private string _username;
        private string _password;
        private string _fullName;
        private string _email;
        private string _phone;
        private string _postalCode;
        private string _healthCardNumber;
        private DateTime _birthday;

        public Patient(string username, string password, string fullName, string email, string phone, string postalCode, string healthCardNumber, DateTime birthday)
        {
            Username = username;
            Password = password;
            FullName = fullName;
            Email = email;
            Phone = phone;
            PostalCode = postalCode;
            HealthCardNumber = healthCardNumber;
            Birthday = birthday;
        }

        [DataMember(Name = "PatientUsername")]
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

        [DataMember(Name = "PatientPassword")]
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

        [DataMember(Name = "PatientFullName")]
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

        [DataMember(Name = "PatientEmail")]
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

        [DataMember(Name = "PatientPhone")]
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

        [DataMember(Name = "PatientPostalCode")]
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

        [DataMember(Name = "PatientHealthCardNumber")]
        public string HealthCardNumber
        {
            get => _healthCardNumber;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("You must enter a health card number that contains 10 digits!");
                }
                else if (value.Length != 10)
                {
                    throw new Exception("You must enter a health card number that contains 10 digits!");
                }
                else
                {
                    if (value.All(char.IsDigit))
                        _healthCardNumber = value;
                    else
                        throw new Exception("You must enter a health card number that contains 10 digits!");
                }
            }
        }

        [DataMember(Name = "PatientBirthday")]
        public DateTime Birthday
        {
            get => _birthday;
            set
            {
                if (DateTime.Today.Date.Year - value.Date.Date.Year > 18)
                    _birthday = value;
                else
                    throw new Exception($"You must borned before the year {DateTime.Today.Date.Year - 18} to register this app!");
            }
        }

        public override bool Equals(object obj)
        {
            Patient patient = obj as Patient;
            if (patient != null)
            {
                if (patient.Username == Username)
                    return true;
            }
            return false;
        }

        public bool isPatientAccount(string username, string password)
        {
            if (username == Username && password == Password)
                return true;
            return false;
        }
    }
}
