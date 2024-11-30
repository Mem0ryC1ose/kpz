using lab3.DBFirstModels;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.DBFirstModels
{
    internal class ClientController
    {
        public static void AddClient(Client newClient)
        {
            using (var context = new DBFirstContext())
            {
                context.Clients.Add(newClient);
                context.SaveChanges();
            }
        }

        public static void DeleteClient(int id)
        {
            using (var context = new DBFirstContext())
            {
                var client = context.Clients.FirstOrDefault(c => c.Id == id);
                if (client != null)
                {
                    context.Clients.Remove(client);
                    context.SaveChanges();
                }
            }
        }

        public static void UpdateClient(Client updatedClient, int id)
        {
            using (var context = new DBFirstContext())
            {
                var client = context.Clients.FirstOrDefault(c => c.Id == id);
                if (client != null)
                {
                    client.Name = updatedClient.Name;
                    client.Address = updatedClient.Address;
                    client.PhoneNumber = updatedClient.PhoneNumber;
                    client.Email = updatedClient.Email;
                    client.RegistrationDate = updatedClient.RegistrationDate;
                    context.SaveChanges();
                }
            }
        }

        public static void ViewClients()
        {
            using (var context = new DBFirstContext())
            {
                var clients = context.Clients.ToList();

                int idLength = "Id".Length;
                int nameLength = "Name".Length;
                int addressLength = "Address".Length;
                int phoneNumberLength = "Phone Number".Length;
                int emailLength = "Email".Length;
                int registrationDateLength = "Registration Date".Length;

                foreach (var client in clients)
                {
                    idLength = Math.Max(idLength, client.Id.ToString().Length);
                    nameLength = Math.Max(nameLength, client.Name.Length);
                    addressLength = Math.Max(addressLength, client.Address?.Length ?? 0);
                    phoneNumberLength = Math.Max(phoneNumberLength, client.PhoneNumber?.Length ?? 0);
                    emailLength = Math.Max(emailLength, client.Email?.Length ?? 0);
                    registrationDateLength = Math.Max(registrationDateLength, client.RegistrationDate.ToString().Length);
                }

                string header = $"|{"Id".PadRight(idLength)}|{"Name".PadRight(nameLength)}|{"Address".PadRight(addressLength)}|{"Phone Number".PadRight(phoneNumberLength)}|{"Email".PadRight(emailLength)}|{"Registration Date".PadRight(registrationDateLength)}|";
                Console.WriteLine(header);
                Console.WriteLine(new string('-', header.Length));

                foreach (var client in clients)
                {
                    Console.WriteLine($"|{client.Id.ToString().PadRight(idLength)}|" +
                                      $"{client.Name.PadRight(nameLength)}|" +
                                      $"{(client.Address ?? "").PadRight(addressLength)}|" +
                                      $"{(client.PhoneNumber ?? "").PadRight(phoneNumberLength)}|" +
                                      $"{(client.Email ?? "").PadRight(emailLength)}|" +
                                      $"{client.RegistrationDate.ToString().PadRight(registrationDateLength)}|");
                    Console.WriteLine(new string('-', header.Length));
                }
            }
        }
        public static Client getInput()
        {
            string name = AnsiConsole.Ask<string>("Enter client name: ");
            string address = AnsiConsole.Ask<string>("Enter client address: ");
            string phoneNumber = AnsiConsole.Ask<string>("Enter client phone number: ");
            string email = AnsiConsole.Ask<string>("Enter client email: ");
            DateTime registrationDate = AnsiConsole.Ask<DateTime>("Enter registration date (yyyy-MM-dd): ");

            return new Client
            {
                Name = name,
                Address = address,
                PhoneNumber = phoneNumber,
                Email = email,
                RegistrationDate = registrationDate
            };
        }

        public static Client getInput(ref int id)
        {
            id = AnsiConsole.Ask<int>("Enter client ID: ");
            string name = AnsiConsole.Ask<string>("Enter client name: ");
            string address = AnsiConsole.Ask<string>("Enter client address: ");
            string phoneNumber = AnsiConsole.Ask<string>("Enter client phone number: ");
            string email = AnsiConsole.Ask<string>("Enter client email: ");
            DateTime registrationDate = AnsiConsole.Ask<DateTime>("Enter registration date (yyyy-MM-dd): ");

            return new Client
            {
                Name = name,
                Address = address,
                PhoneNumber = phoneNumber,
                Email = email,
                RegistrationDate = registrationDate
            };
        }

    }
}