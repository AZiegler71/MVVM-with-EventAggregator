using System.ComponentModel;
using UAR.Domain.Northwind;
using UAR.UI.Contracts;

namespace UAR.UI.WPF
{
    public class EmployeeDetailsVM : IAmViewModel, IAmNotTestable, IListViewItem
    {
        private bool _isSelected;

        public string Name { get; set; }

        public string Phone { get; set; }

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("IsSelected"));
            }
        }

        public EmployeeDetailsVM(Employee employee)
        {
            Name = string.Format("{0} {1}", employee.FirstName, employee.LastName);
            Phone = employee.HomePhone;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}