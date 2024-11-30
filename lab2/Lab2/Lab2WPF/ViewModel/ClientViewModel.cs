using System;
using System.Collections.Generic;
using System.Linq;
using Lab2.Model;
using Lab2;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Lab2WPF.ViewModel
{
    class ClientViewModel : ViewModelBase
    {
        private Client _client;

        public int Id
        {
            get => _client.Id;
            set
            {
                if (_client.Id != value)
                {
                    _client.Id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }
        public string Name
        {
            get => _client.Name;
            set
            {
                if (_client.Name != value)
                {
                    _client.Name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public string Address
        {
            get => _client.Address;
            set
            {
                if (_client.Address != value)
                {
                    _client.Address = value;
                    OnPropertyChanged(nameof(Address));
                }
            }
        }
        public string PhoneNumber
        {
            get => _client.PhoneNumber;
            set
            {
                if (_client.PhoneNumber != value)
                {
                    _client.PhoneNumber = value;
                    OnPropertyChanged(nameof(PhoneNumber));
                }
            }
        }

        public string Email
        {
            get => _client.Email;
            set
            {
                if (_client.Email != value)
                {
                    _client.Email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }
        public string RegistrationDateString
        {
            get => _client.RegistrationDateString;
            set
            {
                if (_client.RegistrationDateString != value)
                {
                    _client.RegistrationDateString = value;
                    OnPropertyChanged(nameof(RegistrationDateString));
                }
            }
        }


        public ClientViewModel(Client client)
        {
            _client = client;
        }
    }
}
