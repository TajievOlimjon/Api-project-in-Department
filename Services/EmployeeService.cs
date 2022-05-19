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

        public async Task<List<EmployeeE>> GetEmployees()
        {
            using (var con = GetConnection())
            {
                var sql = " select E.Id, concat(E.FirstName,' ',E.LastName) as FullName, D.Id as DepartmentId, D.Name as DepartmentName " +
                    " from Employee E " +
                    " join Department_Employee as DE on DE.EmployeeId=E.Id " +
                    " join Department as D on D.Id = DE.DepartmentId ";
                var list = await con.QueryAsync<EmployeeE>(sql);
                return list.ToList();
            }
        }

        public async Task<EmployeeE> GetEmployeeById(int Id)
        {
            using (var con = GetConnection())
            {
                var sql = $" select E.Id, concat(E.FirstName,' ',E.LastName) as FullName, D.Id as DepartmentId, D.Name as DepartmentName " +
                    $" from Employee E  " +
                    $" join Department_Employee as DE on DE.EmployeeId=E.Id " +
                    $" join Department as D on D.Id = DE.DepartmentId "+
                    $"  Where E.Id={Id} ";
               
                var getById =await  con.QuerySingleAsync<EmployeeE>(sql);
                return getById;

            }
        }

        public async Task<int> InsertEmployee(Employee employee)
        {
            using (var con=GetConnection())
            {
                var sql = $" Insert into Employee(FirstName,LastName,BirthDate,Gender,HireDate) " +
                    $" values('{employee.FirstName}', " +
                    $" '{employee.LastName}', " +
                    $" '{employee.BirthDate}', " +
                    $" '{employee.Gender}', " +
                    $" '{employee.HireDate}') ";
                var insert =await con.ExecuteAsync(sql);
                return insert;

            }
        }

        public async Task<int> UpdateEmployee(Employee employee,int Id)
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
                var update =await con.ExecuteAsync(sql);
                return update;
            }
        }


       
    }
}
