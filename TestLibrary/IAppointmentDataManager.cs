using System;
using System.Collections.Generic;
using System.Text;

namespace MeetYourDoctorLibrary
{
    public interface IAppointmentDataManager
    {
        void SaveAppointmentData(List<Appointment> appointments);
        List<Appointment> ReadAppointmentData();
    }
}
