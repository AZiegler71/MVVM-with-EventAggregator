using UAR.Domain.Northwind;
using UAR.UI.Contracts;

namespace UAR.UI.WPF
{
    public class EmployeeDetailVM : IAmViewModel, IAmNotTestable
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }

        public EmployeeDetailVM(Employee employee)
        {
            Name = string.Format("{0} {1}", employee.FirstName, employee.LastName);
            Phone = employee.HomePhone;
            Country = employee.Country;
        }
    }
}