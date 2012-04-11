using System.ComponentModel;
using System.Linq;
using UAR.UI.Contracts;

namespace UAR.UI.WPF
{
    public class MainVM : IAmViewModel
    {
        private readonly IViewModelFactory _viewModelFactory;

        public DelegateCommandModel OpenListCommand { get; set; }

        public DelegateCommandModel DeleteItemsCommand { get; set; }

        #region EmployeeList property

        private const string EmployeeListProperty = "EmployeeList";
        private EmployeeListVM _employeeList;
        public EmployeeListVM EmployeeList
        {
            get { return _employeeList; }
            private set
            {
                if (_employeeList != value)
                {
                    _employeeList = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs(EmployeeListProperty));
                }
            }
        }

        #endregion

        #region SelectedEmployee property

        private const string SelectedEmployeeProperty = "SelectedEmployee";
        private EmployeeDetailsVM _selectedEmployee;
        public EmployeeDetailsVM SelectedEmployee
        {
            get { return _selectedEmployee; }
            private set
            {
                if (_selectedEmployee != value)
                {
                    _selectedEmployee = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs(SelectedEmployeeProperty));
                }
            }
        }

        #endregion

        public MainVM(IViewModelFactory viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;

            OpenListCommand = new DelegateCommandModel(
                x => true,
                x =>
                {
                    EmployeeList = viewModelFactory.Create<EmployeeListVM>();
                    EmployeeList.Load();
                    EmployeeList.SelectedEmployeeChanged += SelectedEmployeeChanged; // unsubscribe in real solution...
                });

            DeleteItemsCommand = new DelegateCommandModel(
                x => EmployeeList != null,
                x => EmployeeList.DeleteSelected());
        }

        private void SelectedEmployeeChanged(EmployeeDetailsVM details)
        {
            SelectedEmployee = details;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}