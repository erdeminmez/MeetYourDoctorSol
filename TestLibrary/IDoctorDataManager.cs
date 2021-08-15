using System;
using System.Collections.Generic;
using System.Text;

namespace MeetYourDoctorLibrary
{
    /// <summary>
    /// Principal Author: Erdem Inmez
    /// Short Description: This is doctor data manager interface.
    /// </summary>
    public interface IDoctorDataManager
    {
        void SaveDoctorData(List<Doctor> doctors);
        List<Doctor> ReadDoctorData();
    }
}
