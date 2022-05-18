using Npgsql;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Services
{
    public  class EmployeeService
    {
        private string connectionString = "Server=127.0.0.1;Port=5432;Database=Department;User Id=postgres;Password=0711;";

        public NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(connectionString);
        }

        public List<EmployeeE> GetEmployees()
        {
            using (var con = GetConnection())
            {
                var sql = " select E.Id, concat(E.FirstName,' ',E.LastName) as FullName, D.Id as DepartmentId, D.Name as DepartmentName " +
                    " from Employee E " +
                    " join Department as D on D.Id = E.Id ";
                var list = con.Query<EmployeeE>(sql);
                return list.ToList();
            }
        }

        public EmployeeE GetEmployeeById(int Id)
        {
            using (var con = GetConnection())
            {
                var sql = $" select E.Id, concat(E.FirstName,' ',E.LastName) as FullName, D.Id as DepartmentId, D.Name as DepartmentName " +
                    $" from Employee E  " +
                    $" join Department as D on D.Id = E.Id  " +
                    $"  Where E.Id={Id} ";
               
                var getById = con.QuerySingle<EmployeeE>(sql);
                return getById;

            }
        }

        public int InsertEmployee(Employee employee)
        {
            using (var con=GetConnection())
            {
                var sql = $" Insert into Employee(FirstName,LastName,BirthDate,Gender,HireDate) " +
                    $" values('{employee.FirstName}', " +
                    $" '{employee.LastName}', " +
                    $" '{employee.BirthDate}', " +
                    $" '{employee.Gender}', " +
                    $" '{employee.HireDate}') ";
                var insert = con.Execute(sql);
                return insert;

            }
        }

        public int UpdateEmployee(Employee employee,int Id)
        {
            using (var con=GetConnection())
            {
                var sql = $" Update Employee " +
                    $" Set " +
                    $" FirstName='{employee.FirstName}', " +
                    $" LastName='{employee.LastName}', " +
                    $" BirthDate='{employee.BirthDate}', " +
                    $" Gender='{employee.Gender}', " +
                    $" HireDate='{employee.HireDate}' " +
                    $" Where Id={Id} ";
                var update = con.Execute(sql);
                return update;
            }
        }


       
    }
}
