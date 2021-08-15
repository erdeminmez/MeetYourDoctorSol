using System;
using System.Collections.Generic;
using System.Text;

namespace MeetYourDoctorLibrary
{
    public interface IPatientDataManager
    {
        /// <summary>
        /// Principal Author: Erdem Inmez
        /// Short Description: This is patient data manager interface.
        /// </summary>
        void SavePatientData(List<Patient> patients);
        List<Patient> ReadPatientData();
    }
}
