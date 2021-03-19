using System;
using System.Collections.Generic;
using System.Text;

namespace RedArborTest.Common.DTO
{
    public class Employee
    {
        public int? EmployeeId { get; set; }
        public string Name { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Telephone { get; set; }
        public string CompanyName { get; set; }
        public string PortalName { get; set; }
        public string RoleName { get; set; }
        public string StatusName { get; set; }
        public DateTime LastLogin { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public DateTime? DeleteOn { get; set; }
    }
}
