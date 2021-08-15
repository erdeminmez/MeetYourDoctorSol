using MeetYourDoctorLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace MeetYourDoctorData
{
    /// <summary>
    /// Principal Author: Erdem Inmez
    /// Short Description: This is doctor data manager class which uses json file. Reads and saves data related to doctors.
    /// </summary>
    public class DoctorJsonDataManager : IDoctorDataManager
    {
        private string _fileName;

        public DoctorJsonDataManager(string fileName)
        {
            _fileName = fileName;
        }

        public void SaveDoctorData(List<Doctor> doctors)
        {
            using (FileStream fileStream = new FileStream(_fileName, FileMode.Create))
            {
                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(List<Doctor>));
                jsonSerializer.WriteObject(fileStream, doctors);
            }
        }

        public List<Doctor> ReadDoctorData()
        {
            List<Doctor> doctors = null;
            using (FileStream fileStream = new FileStream(_fileName, FileMode.Open))
            {
                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(List<Doctor>));
                doctors = jsonSerializer.ReadObject(fileStream) as List<Doctor>;
            }
            return doctors;
        }
    }
}
