using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab2.Model
{
    public class DataModel
    {
        public List<Client> Clients { get; set; } = new List<Client>();
        public List<Service> Services { get; set; } = new List<Service>();
        public List<Tariff> Tariffs { get; set; } = new List<Tariff>();
        public List<Employee> Employees { get; set; } = new List<Employee>();

        public void AddClient(int id, string name, string address, string phoneNumber, string email, DateTime registrationDate)
        {
            Clients.Add(new Client
            {
                Id = id,
                Name = name,
                Address = address,
                PhoneNumber = phoneNumber,
                Email = email,
                RegistrationDate = registrationDate
            });
        }

        public void AddService(int id, string name, string description, string type)
        {
            Services.Add(new Service
            {
                Id = id,
                Name = name,
                Description = description,
                Type = type
            });
        }

        public void AddTariff(int id, int serviceId, string name, double price)
        {
            Tariffs.Add(new Tariff
            {
                Id = id,
                ServiceId = serviceId,
                Name = name,
                Price = price
            });
        }

        public void AddEmploye(int id, string name, string position, string email, string phoneNumber)
        {
            Employees.Add(new Employee
            {
                Id = id,
                Name = name,
                Position = position,
                Email = email,
                PhoneNumber = phoneNumber
            });
        }

        string filePath = "InternetProvidersInfo.xml";
        public void Load()
        {
            if (File.Exists(filePath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(DataModel));
                using (StreamReader reader = new StreamReader(filePath))
                {
                    DataModel loadedData = (DataModel)serializer.Deserialize(reader);
                    this.Clients = loadedData.Clients;
                    this.Services = loadedData.Services;
                    this.Tariffs = loadedData.Tariffs;
                    this.Employees = loadedData.Employees;
                }
            }
        }
        public void Save()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(DataModel));
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, this);
            }
        }
    }
}
