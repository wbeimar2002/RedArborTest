using System;
using System.Collections.Generic;
using System.Text;

namespace RedArborTest.Common.DTO
{
    public class EmployeePost
    {
        public int? EmployeeId { get; set; }
        public string Name { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Telephone { get; set; }
        public string LastLogin { get; set; }
        public string CreatedOn { get; set; }
        public string UpdatedOn { get; set; }
        public string DeleteOn { get; set; }
        public int CompanyId { get; set; }
        public Int16 PortalId { get; set; }
        public Int16 RoleId { get; set; }
        public Int16 StatusId { get; set; }
    }
}
