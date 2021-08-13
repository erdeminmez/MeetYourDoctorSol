using System;
using System.Collections.Generic;
using System.Text;

namespace MeetYourDoctorLibrary
{
    public interface IPatientDataManager
    {
        void SavePatientData(List<Patient> patients);
        List<Patient> ReadPatientData();
    }
}
