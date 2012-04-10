using System.ComponentModel;
using System.Linq;
using System.Windows;
using UAR.UI.Contracts;

namespace UAR.UI.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : IAmViewModel
    {
        readonly IViewModelFactory _viewModelFactory;

        MainVM _mainViewModel;
        public MainVM MainViewModel
        {
            get
            {
                return _mainViewModel;
            }
            set
            {
                _mainViewModel = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("MainViewModel"));
            }
        }

        public MainWindow(IViewModelFactory viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Button_Click_Northwind(object sender, RoutedEventArgs e)
        {
            if (MainViewModel == null)
                MainViewModel = _viewModelFactory.CreateScoped<MainVM>();
        }

        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            MainViewModel.DeleteSelected();
        }

    }
}
