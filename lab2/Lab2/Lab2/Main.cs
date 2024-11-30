using Lab2.Model;
using Lab2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class Program
    {
        public static void Main()
        {
            DataModel dataModel = new DataModel();

            dataModel.AddClient(1, "Krutets Igor", "Adress1", "0116752389", "Igorrrrr@gmail.com", new DateTime(2020, 4, 23));
            dataModel.AddClient(2, "Trohumchuk Illya", "Adress2", "0671530900", "IllyaTr@gmail.com", new DateTime(2010, 3, 18));

            dataModel.AddService(1, "GIG", "Fast and secure home internet", "Internet");
            dataModel.AddService(2, "GIG+", "Faster and more secure home internet", "Internet");

            dataModel.AddTariff(1, 1, "100 Мб/с", 100.0);
            dataModel.AddTariff(2, 2, "300 Мб/с", 300.0);

            dataModel.AddEmploye(1, "Truha Oleksander", "Installer of Internet networks", "OleksanderTruha@gmail.com", "0657832716");
            dataModel.AddEmploye(2, "Lamayko Andriy", "Installer of Internet networks", "Andryuha@gmail.com", "0682461187");

            string filePath = "InternetProvidersInfo.xml";

            SerializationHelper.SerializeToXml(dataModel, filePath);
            Console.WriteLine("Data has been serialized to XML.");

            DataModel deserializedDataModel = SerializationHelper.DeserializeFromXml<DataModel>(filePath);
            Console.WriteLine("Deserialized Student Name: " + deserializedDataModel.Clients[0].Name);

        }
    }


}
