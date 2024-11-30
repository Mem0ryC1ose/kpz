using Lab2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2WPF.ViewModel
{
    class ServiceViewModel : ViewModelBase
    {
        private Service _service;

        public int Id
        {
            get => _service.Id;
            set
            {
                if (_service.Id != value)
                {
                    _service.Id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }
        public string Name
        {
            get => _service.Name;
            set
            {
                if (_service.Name != value)
                {
                    _service.Name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }
        public string Description
        {
            get => _service.Description;
            set
            {
                if (_service.Description != value)
                {
                    _service.Description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }
        public string Type
        {
            get => _service.Type;
            set
            {
                if (_service.Type != value)
                {
                    _service.Type = value;
                    OnPropertyChanged(nameof(Type));
                }
            }
        }
        public ServiceViewModel(Service service)
        {
            _service = service;
        }
    }
}
