using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using UAR.Domain.Northwind;
using UAR.UI.Contracts;

namespace UAR.UI.WPF
{
    public class EmployeeListVM : IAmViewModel
    {
        private readonly IViewModelFactory _viewModelFactory;
        public ObservableCollection<EmployeeDetailsVM> Employees { get; set; }

        public EmployeeListVM(IViewModelFactory viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
        }

        internal void Load()
        {
            // fill with dummy data
            Employees = new ObservableCollection<EmployeeDetailsVM>
            {
                _viewModelFactory.Create<EmployeeDetailsVM>(new
                {
                    employee = new Employee
                    {
                        FirstName = "Vorname1",
                        HomePhone = "111",
                        LastName = "Nachname1"
                    }
                }),
                _viewModelFactory.Create<EmployeeDetailsVM>(new
                {
                    employee = new Employee
                    {
                        FirstName = "Vorname2",
                        HomePhone = "222",
                        LastName = "Nachname2"
                    }
                }),
                _viewModelFactory.Create<EmployeeDetailsVM>(new
                {
                    employee = new Employee
                    {
                        FirstName = "Vorname3",
                        HomePhone = "333",
                        LastName = "Nachname3"
                    }
                })
            };
        }

        internal void DeleteSelected()
        {
            foreach (var employee in Employees.ToList())
            {
                if (employee.IsSelected)
                    Employees.Remove(employee);
            }
        }

        public event Action<EmployeeDetailsVM> SelectedEmployeeChanged;

        public event PropertyChangedEventHandler PropertyChanged;

        #region FirstSelected property

        private const string FirstSelectedProperty = "FirstSelected";
        private EmployeeDetailsVM _firstSelected;
        public EmployeeDetailsVM FirstSelected
        {
            get { return _firstSelected; }
            set
            {
                if (_firstSelected != value)
                {
                    _firstSelected = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs(FirstSelectedProperty));

                    // communicate this view related event by event layer also?
                    if (SelectedEmployeeChanged != null)
                        SelectedEmployeeChanged(_firstSelected);
                }
            }
        }

        #endregion
    }
}