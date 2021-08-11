using System;
using System.Collections.Generic;
using System.Text;

namespace MeetYourDoctorLibrary
{
    public class User
    {
        private string _username;
        private string _password;
        private string _fullName;
        private string _email;
        private string _phone;
        private string _address;

        public User(string username, string password, string fullName, string email, string phone, string address)
        {
            Username = username;
            Password = password;
            FullName = fullName;
            Email = email;
            Phone = phone;
            Address = address;
        }

        public string Username 
        {
            get => _username;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("You must enter a username that contains at least 8 characters!");
                }
                else if (value.Length < 8)
                {
                    throw new Exception("You must enter a username that contains at least 8 characters!");
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
                    throw new Exception("You must enter a password that contains at least 8 characters!");
                }
                else if (value.Length < 8)
                {
                    throw new Exception("You must enter a password that contains at least 8 characters!");
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
                    _phone = value;
                }
            }
        }

        public string Address
        {
            get => _address;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("You must enter your address!");
                }
                else
                {
                    _address = value;
                }
            }
        }

    }
}
