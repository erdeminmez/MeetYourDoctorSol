using System;
using System.Collections.Generic;
using System.Text;

namespace MeetYourDoctorLibrary
{
    /// <summary>
    /// Principal Author: Erdem Inmez
    /// Short Description: This is doctor schedule item class. Create doctor schedule item objects.
    /// </summary>
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
