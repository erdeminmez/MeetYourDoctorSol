using System;
using System.Collections.Generic;
using System.Text;

namespace MeetYourDoctorLibrary
{
    public class Patient : User
    {
        private DateTime _birthday;
        private string _healthCardNumber;

        public Patient(string username, string password, string fullName, string email, string phone, string address, DateTime birthday, string healthCardNumber) : base(username, password, fullName, email, phone, address)
        {
            Birthday = birthday;
            HealthCardNumber = healthCardNumber;
        }

        public DateTime Birthday
        {
            get => _birthday;
            set
            {
                if (value.Date.Date.Year - DateTime.Today.Date.Year < 19)
                {
                    throw new Exception($"You must borned before the year {DateTime.Today.Date.Year - 18} to register this app!");
                }
                _birthday = value;
            }
        }

        public string HealthCardNumber
        {
            get => _healthCardNumber;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("You must enter a Health Card number that contains 10 digits!");
                }
                else if (value.Length != 10)
                {
                    throw new Exception("You must enter a Health Card that contains 10 digits!");
                }
                else
                {
                    _healthCardNumber = value;
                }
            }
        }
    }
}
