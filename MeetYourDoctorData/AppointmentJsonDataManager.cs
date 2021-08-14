using MeetYourDoctorLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace MeetYourDoctorData
{
    public class AppointmentJsonDataManager : IAppointmentDataManager
    {
        private string _fileName;

        public AppointmentJsonDataManager(string fileName)
        {
            _fileName = fileName;
        }

        public void SaveAppointmentData(List<Appointment> appointments)
        {
            using (FileStream fileStream = new FileStream(_fileName, FileMode.Create))
            {
                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(List<Appointment>));
                jsonSerializer.WriteObject(fileStream, appointments);
            }
        }

        public List<Appointment> ReadAppointmentData()
        {
            List<Appointment> appointments = null;
            using (FileStream fileStream = new FileStream(_fileName, FileMode.Open))
            {
                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(List<Appointment>));
                appointments = jsonSerializer.ReadObject(fileStream) as List<Appointment>;
            }
            return appointments;
        }
    }
}
