using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using UAR.Domain.Northwind;
using UAR.UI.Contracts;

namespace UAR.UI.WPF
{
    public class EmployeeListVM : IAmViewModel
    {
        public ObservableCollection<EmployeeDetailsVM> Employees { get; set; }

        internal void Load()
        {
            Employees = new ObservableCollection<EmployeeDetailsVM>
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

        internal void DeleteSelected()
        {
            foreach (var employee in Employees.ToList())
            {
                if (employee.IsSelected)
                    Employees.Remove(employee);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}