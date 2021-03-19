using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Microsoft.Extensions.Configuration;
using RedArborTest.Common.DTO;

namespace RedArborTest.Repository.DB
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private string connectionString;
        private readonly IConfiguration configuration;
        public EmployeeRepository(IConfiguration config)
        {
            configuration = config;
            Initialize();
        }

        private void Initialize()
        {
            connectionString = configuration.GetConnectionString("RedArborDb");  
        }

        public IEnumerable<Employee> GetEmployees(int? id)
        {
            try
            {
                var employees = new List<Employee>();
                List<SqlParameter> parameters = new List<SqlParameter>();

                using (var connection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("dbo.uspEmployeeGet", connection))
                    {
                        if (id != null)
                        {
                            SqlParameter localCodeParameter = new SqlParameter("@EmployeeId", SqlDbType.Int)
                            {
                                Value = id
                            };
                            parameters.Add(localCodeParameter);
                        }

                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddRange(parameters.ToArray());
                        connection.Open();

                        using (var dataReader = command.ExecuteReader())
                        {
                            MapEmployeesData(employees, dataReader);
                        }

                        connection.Close();
                    }
                }

                return employees;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool CreateUpdateEmployee(EmployeePost employeePost)
        {
            try
            {
                DataTable EmployeeData = CreateEmployeeStructure();
                FillEmployeeInformation(EmployeeData, employeePost);
                var parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@EmployeeData", SqlDbType.Structured)
                {
                    TypeName = "dbo.EmployeeData",
                    Value = EmployeeData
                });
                const string storedProc = "dbo.uspEmployeeCreateUpdate";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(storedProc, connection))
                    {
                        // Add the parameters to the command - add
                        command.Parameters.AddRange(parameters.ToArray());

                        // Create an adapter and fill our dataset, uncomment when we use a stored procedure
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();
                    }
                }

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool DeleteEmployee(int id)
        {
            try
            {
                var parameters = new List<SqlParameter>();
                SqlParameter localCodeParameter = new SqlParameter("@EmployeeId", SqlDbType.Int)
                {
                    Value = id
                };
                parameters.Add(localCodeParameter);
                const string storedProc = "dbo.uspEmployeeDelete";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(storedProc, connection))
                    {
                        // Add the parameters to the command - add
                        command.Parameters.AddRange(parameters.ToArray());

                        // Create an adapter and fill our dataset, uncomment when we use a stored procedure
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private DataTable CreateEmployeeStructure()
        {
            DataTable EmployeeData = new DataTable();
            EmployeeData.Columns.Add("EmployeeId", typeof(int));
            EmployeeData.Columns.Add("Name", typeof(string));
            EmployeeData.Columns.Add("Fax", typeof(string));
            EmployeeData.Columns.Add("Email", typeof(string));
            EmployeeData.Columns.Add("Password", typeof(string));
            EmployeeData.Columns.Add("UserName", typeof(string));
            EmployeeData.Columns.Add("Telephone", typeof(string));
            EmployeeData.Columns.Add("CompanyId", typeof(int));
            EmployeeData.Columns.Add("PortalId", typeof(Int16));
            EmployeeData.Columns.Add("RoleId", typeof(Int16));
            EmployeeData.Columns.Add("StatusId", typeof(Int16));
            EmployeeData.Columns.Add("LastLogin", typeof(DateTime));
            EmployeeData.Columns.Add("CreatedOn", typeof(DateTime));
            EmployeeData.Columns.Add("UpdateOn", typeof(DateTime));
            EmployeeData.Columns.Add("DeletedOn", typeof(DateTime));
            return EmployeeData;
        }

        private void FillEmployeeInformation(DataTable data, EmployeePost employeePost)
        {
            DataRow newRow = data.NewRow();
            if (employeePost.EmployeeId != null)
                newRow["EmployeeId"] = employeePost.EmployeeId;
            newRow["Name"] = employeePost.Name;
            if (employeePost.Fax != null)
                newRow["Fax"] = employeePost.Fax;
            newRow["Email"] = employeePost.Email;
            newRow["Password"] = employeePost.Password;
            newRow["UserName"] = employeePost.UserName;
            newRow["Telephone"] = employeePost.Telephone;
            newRow["CompanyId"] = employeePost.CompanyId;
            newRow["PortalId"] = employeePost.PortalId;
            newRow["RoleId"] = employeePost.RoleId;
            newRow["StatusId"] = employeePost.StatusId;
            newRow["LastLogin"] = DateTime.Parse(employeePost.LastLogin);
            newRow["CreatedOn"] = DateTime.Parse(employeePost.CreatedOn);
            if (employeePost.UpdatedOn != null)
                newRow["UpdateOn"] = DateTime.Parse(employeePost.UpdatedOn);
            if (employeePost.DeleteOn != null)
                newRow["DeletedOn"] = DateTime.Parse(employeePost.DeleteOn);

            data.Rows.Add(newRow);
        }

        private static void MapEmployeesData(List<Employee> employees, SqlDataReader dataReader)
        {
            int EmployeeIdColumn = dataReader.GetOrdinal("EmployeeId");
            int NameColumn = dataReader.GetOrdinal("Name");
            int FaxColumn = dataReader.GetOrdinal("Fax");
            int EmailColumn = dataReader.GetOrdinal("Email");
            int PasswordColumn = dataReader.GetOrdinal("Password");
            int UserNameColumn = dataReader.GetOrdinal("UserName");
            int TelephoneColumn = dataReader.GetOrdinal("Telephone");
            int CompanyNameColumn = dataReader.GetOrdinal("CompanyName");
            int PortalNameColumn = dataReader.GetOrdinal("PortalName");
            int RoleNameColumn = dataReader.GetOrdinal("RoleName");
            int StatusNameColumn = dataReader.GetOrdinal("StatusName");
            int LastLoginColumn = dataReader.GetOrdinal("LastLogin");
            int CreatedOnColumn = dataReader.GetOrdinal("CreatedOn");
            int UpdateOnColumn = dataReader.GetOrdinal("UpdateOn");
            int DeleteOnColumn = dataReader.GetOrdinal("DeletedOn");

            while (dataReader.Read())
            {
                Employee employee = new Employee
                {
                    EmployeeId = dataReader.GetInt32(EmployeeIdColumn),
                    Name = dataReader.GetString(NameColumn),
                    Email = dataReader.GetString(EmailColumn),
                    Password = dataReader.GetString(PasswordColumn),
                    UserName = dataReader.GetString(UserNameColumn),
                    Telephone = dataReader.GetString(TelephoneColumn),
                    CompanyName = dataReader.GetString(CompanyNameColumn),
                    PortalName = dataReader.GetString(PortalNameColumn),
                    RoleName = dataReader.GetString(RoleNameColumn),
                    StatusName = dataReader.GetString(StatusNameColumn),
                    LastLogin = dataReader.GetDateTime(LastLoginColumn),
                    CreatedOn = dataReader.GetDateTime(CreatedOnColumn),
                };
                if (dataReader[FaxColumn] != DBNull.Value)
                    employee.Fax = dataReader.GetString(FaxColumn);

                if (dataReader[UpdateOnColumn] != DBNull.Value)
                    employee.UpdatedOn = dataReader.GetDateTime(UpdateOnColumn);

                if (dataReader[DeleteOnColumn] != DBNull.Value)
                    employee.DeleteOn = dataReader.GetDateTime(DeleteOnColumn);

                employees.Add(employee);
            }
        }
    }
}
