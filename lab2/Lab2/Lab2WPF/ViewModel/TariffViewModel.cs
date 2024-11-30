using Lab2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2WPF.ViewModel
{
    class TariffViewModel : ViewModelBase
    {
        private Tariff _tariff;

        public int Id
        {
            get => _tariff.Id;
            set
            {
                if (_tariff.Id != value)
                {
                    _tariff.Id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }
        public int ServiceId
        {
            get => _tariff.ServiceId;
            set
            {
                if (_tariff.ServiceId != value)
                {
                    _tariff.ServiceId = value;
                    OnPropertyChanged(nameof(ServiceId));
                }
            }
        }
        public string Name
        {
            get => _tariff.Name;
            set
            {
                if (_tariff.Name != value)
                {
                    _tariff.Name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }
        public double Price
        {
            get => _tariff.Price;
            set
            {
                if (_tariff.Price != value)
                {
                    _tariff.Price = value;
                    OnPropertyChanged(nameof(Price));
                }
            }
        }
        public TariffViewModel(Tariff tariff)
        {
            _tariff = tariff;
        }
    }
}
