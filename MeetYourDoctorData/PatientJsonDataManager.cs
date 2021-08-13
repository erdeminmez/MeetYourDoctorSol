using MeetYourDoctorLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace MeetYourDoctorData
{
    public class PatientJsonDataManager : IPatientDataManager
    {
        private string _fileName;

        public PatientJsonDataManager(string fileName)
        {
            _fileName = fileName;
        }

        public void SavePatientData(List<Patient> patients)
        {
            using (FileStream fileStream = new FileStream(_fileName, FileMode.Create))
            {
                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(List<Patient>));
                jsonSerializer.WriteObject(fileStream, patients);
            }
        }

        public List<Patient> ReadPatientData()
        {
            List<Patient> patients = null;
            using (FileStream fileStream = new FileStream(_fileName, FileMode.Open))
            {
                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(List<Patient>));
                patients = jsonSerializer.ReadObject(fileStream) as List<Patient>;
            }
            return patients;
        }
    }
}
