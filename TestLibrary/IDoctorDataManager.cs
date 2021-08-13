using System;
using System.Collections.Generic;
using System.Text;

namespace MeetYourDoctorLibrary
{
    public interface IDoctorDataManager
    {
        void SaveDoctorData(List<Doctor> doctors);
        List<Doctor> ReadDoctorData();
    }
}
