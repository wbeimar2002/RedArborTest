using System.Collections.Generic;
using RedArborTest.Common.DTO;

namespace RedArborTest.Service
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetEmployees(int? id);

        public bool CreateUpdateEmployee(EmployeePost employeePost);

        public bool DeleteEmployee(int id);

    }
}