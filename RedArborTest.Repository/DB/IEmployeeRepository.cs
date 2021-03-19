using System.Collections.Generic;
using RedArborTest.Common.DTO;

namespace RedArborTest.Repository.DB
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees(int? id);
        bool CreateUpdateEmployee(EmployeePost employeePost);
        bool DeleteEmployee(int id);
    }
}