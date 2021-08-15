using System;
using System.Collections.Generic;
using System.Text;

namespace MeetYourDoctorLibrary
{
    /// <summary>
    /// Principal Author: Erdem Inmez
    /// Short Description: This is appointment data manager interface.
    /// </summary>
    public interface IAppointmentDataManager
    {
        void SaveAppointmentData(List<Appointment> appointments);
        List<Appointment> ReadAppointmentData();
    }
}
