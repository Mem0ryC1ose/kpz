using Lab2WPF.ViewModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab2WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DataViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new DataViewModel();
            this.DataContext = _viewModel;
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            _viewModel.SaveData();
            base.OnClosing(e);
        }

    }
}