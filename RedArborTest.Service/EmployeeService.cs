using System;
using System.Collections.Generic;
using System.Text;
using RedArborTest.Common.DTO;
using RedArborTest.Repository.DB;

namespace RedArborTest.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public IEnumerable<Employee> GetEmployees(int? id)
        {
            return employeeRepository.GetEmployees(id);
        }

        public bool CreateUpdateEmployee(EmployeePost employeePost)
        {
            return employeeRepository.CreateUpdateEmployee(employeePost);
        }

        public bool DeleteEmployee(int id)
        {
            return employeeRepository.DeleteEmployee(id);
        }
    }
}
