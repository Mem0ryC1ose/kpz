using Lab2.Model;
using Lab2;
using Lab2WPF.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Media3D;

namespace Lab2WPF.ViewModel
{
    class DataViewModel : ViewModelBase
    {
        private DataModel _dataModel;
        public ObservableCollection<ClientViewModel> Clients { get; set; }
        public ObservableCollection<ServiceViewModel> Services { get; set; }
        public ObservableCollection<TariffViewModel> Tariffs { get; set; }
        public ObservableCollection<EmployeeViewModel> Employees { get; set; }

        public DataViewModel()
        {
            _dataModel = new DataModel();
            LoadData();
            InitializeCommands();
            SetInitialView();
        }

        public ICommand AddClientCommand { get; private set; }
        public ICommand AddServiceCommand { get; private set; }
        public ICommand AddTariffCommmand { get; private set; }
        public ICommand AddEmployeeCommand { get; private set; }

        public ICommand ShowClientCommand { get; private set; }
        public ICommand ShowServiceCommand { get; private set; }
        public ICommand ShowTariffCommmand { get; private set; }
        public ICommand ShowEmployeeCommand { get; private set; }

        private void InitializeCommands()
        {
            ShowClientCommand = new RelayCommand(ShowClientView);
            ShowServiceCommand = new RelayCommand(ShowServiceView);
            ShowTariffCommmand = new RelayCommand(ShowTariffView);
            ShowEmployeeCommand = new RelayCommand(ShowEmployeeView);

            AddClientCommand = new RelayCommand(AddClient);
            AddServiceCommand = new RelayCommand(AddService);
            AddTariffCommmand = new RelayCommand(AddTariff);
            AddEmployeeCommand = new RelayCommand(AddEmployee);
        }

        private void SetInitialView()
        {
            CurrentView = new ClientUserControl();
            SelectedView = "Client";
        }


        private void AddClient()
        {
            var client = new Client();
            var clientViewModel = new ClientViewModel(client);
            Clients.Add(clientViewModel);
            _dataModel.Clients.Add(client);
        }
        private void AddService()
        {
            var newService = new Service();
            var newServiceViewModel = new ServiceViewModel(newService);
            Services.Add(newServiceViewModel);
            _dataModel.Services.Add(newService);
        }

        private void AddTariff()
        {
            var tariff = new Tariff();
            var tariffViewModel = new TariffViewModel(tariff);
            Tariffs.Add(tariffViewModel);
            _dataModel.Tariffs.Add(tariff);
        }

        private void AddEmployee()
        {
            var employee = new Employee();
            var employeeViewModel = new EmployeeViewModel(employee);
            Employees.Add(employeeViewModel);
            _dataModel.Employees.Add(employee);
        }

        private void LoadData()
        {
            _dataModel.Load();
            Clients = new ObservableCollection<ClientViewModel>(_dataModel.Clients.Select(c => new ClientViewModel(c)));
            Services = new ObservableCollection<ServiceViewModel>(_dataModel.Services.Select(s => new ServiceViewModel(s)));
            Tariffs = new ObservableCollection<TariffViewModel>(_dataModel.Tariffs.Select(t => new TariffViewModel(t)));
            Employees = new ObservableCollection<EmployeeViewModel>(_dataModel.Employees.Select(e => new EmployeeViewModel(e)));
        }

        public void SaveData()
        {
            _dataModel.Save();
        }

        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }

        private string _selectedView;
        public string SelectedView
        {
            get { return _selectedView; }
            set
            {
                _selectedView = value;
                OnPropertyChanged(nameof(SelectedView));
            }
        }

        private void ShowClientView()
        {
            CurrentView = new ClientUserControl();
            SelectedView = "Client";
        }
        private void ShowServiceView()
        {
            CurrentView = new ServiceUserControl();
            SelectedView = "Service";
        }

        private void ShowTariffView()
        {
            CurrentView = new TariffUserControl();
            SelectedView = "Tariff";
        }

        private void ShowEmployeeView()
        {
            CurrentView = new EmployeeUserControl();
            SelectedView = "Employee";
        }
    }
}
