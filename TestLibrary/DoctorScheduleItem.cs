using System;
using System.Collections.Generic;
using System.Text;

namespace MeetYourDoctorLibrary
{
    public class DoctorScheduleItem
    {
        public string TimeSlot { get; set; }
        public string PatientName { get; set; }

        public DoctorScheduleItem(string timeSlot, string patientName)
        {
            TimeSlot = timeSlot;
            PatientName = patientName;
        }
    }
}
