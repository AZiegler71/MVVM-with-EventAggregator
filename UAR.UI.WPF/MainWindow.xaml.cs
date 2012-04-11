using System.ComponentModel;
using System.Linq;
using System.Windows;
using UAR.UI.Contracts;

namespace UAR.UI.WPF
{
    /// <summary>
    ///   Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow(IViewModelFactory viewModelFactory)
        {
            InitializeComponent();
            Content = viewModelFactory.Create<MainVM>();
        }
    }
}