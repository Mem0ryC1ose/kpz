using Lab2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2WPF.ViewModel
{
    class EmployeeViewModel : ViewModelBase
    {
        private Employee _employee;
        public int Id
        {
            get => _employee.Id;
            set
            {
                if (_employee.Id != value)
                {
                    _employee.Id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }
        public string Name
        {
            get => _employee.Name;
            set
            {
                if (_employee.Name != value)
                {
                    _employee.Name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public string Position
        {
            get => _employee.Position;
            set
            {
                if (_employee.Position != value)
                {
                    _employee.Position = value;
                    OnPropertyChanged(nameof(Position));
                }
            }
        }
        public string PhoneNumber
        {
            get => _employee.PhoneNumber;
            set
            {
                if (_employee.PhoneNumber != value)
                {
                    _employee.PhoneNumber = value;
                    OnPropertyChanged(nameof(PhoneNumber));
                }
            }
        }

        public string Email
        {
            get => _employee.Email;
            set
            {
                if (_employee.Email != value)
                {
                    _employee.Email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }

        public EmployeeViewModel(Employee employee)
        {
            _employee = employee;
        }
    }
}
