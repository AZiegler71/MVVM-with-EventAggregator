using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using UAR.Domain.Northwind;
using UAR.Persistence.Contracts;
using UAR.UI.Contracts;

namespace UAR.UI.WPF
{
    public class MainVM : IDisposable, IAmViewModel, IAmNotTestable
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDisposable _scope;
        private readonly IViewModelFactory _viewModelFactory;

        public ObservableCollection<EmployeeDetailsVM> HecoEmployees { get; set; }

        public MainVM(IUnitOfWork unitOfWork, IDisposable scope, IViewModelFactory viewModelFactory)
        {
            _unitOfWork = unitOfWork;
            _scope = scope;
            _viewModelFactory = viewModelFactory;

            LoadEmployees();
        }

        /// <summary>
        ///   Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            _scope.Dispose();
        }

        public void DeleteSelected()
        {
            foreach (var employee in HecoEmployees.ToList())
            {
                if (employee.IsSelected)
                    HecoEmployees.Remove(employee);
            }
        }

        private void LoadEmployees()
        {
            //var employees = (
            //    from e in _unitOfWork.Entities<Employee>()
            //    where e.EmployeeID < 10
            //    select e
            //    ).ToList();

            //if (HecoEmployees == null)
            //    HecoEmployees = new ObservableCollection<EmployeeDetailVM>();
            //else
            //    HecoEmployees.Clear();

            //foreach (var employee in employees)
            //    HecoEmployees.Add(_viewModelFactory.Create<EmployeeDetailVM>(new {employee}));

            HecoEmployees = new ObservableCollection<EmployeeDetailsVM>
            {
                new EmployeeDetailsVM(new Employee
                {
                    FirstName = "Vorname1",
                    HomePhone = "111",
                    LastName = "Nachname1"
                }),
                new EmployeeDetailsVM(new Employee
                {
                    FirstName = "Vorname2",
                    HomePhone = "222",
                    LastName = "Nachname2"
                }),
                new EmployeeDetailsVM(new Employee
                {
                    FirstName = "Vorname3",
                    HomePhone = "333",
                    LastName = "Nachname3"
                })
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}