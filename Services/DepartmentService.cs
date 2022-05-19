using Dapper;
using Domain;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public  class DepartmentService
    {
        private string connectionString = "Server=127.0.0.1" +
            ";Port=5432;Database=Department;User Id=postgres;Password=0711;";

        public NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(connectionString);
        }


        public async  Task<List<DepartmentD>> GetDepartments()
        {
            using (var con =GetConnection())
            {
                var sql = " select D.Id  , D.Name , E.Id as ManagerId , concat(E.FirstName,'  ',E.LastName) as ManagerFullName " +
                          " from Department D " +
                          " join Department_Employee as DE on DE.DepartmentId=D.Id " +
                          " join Employee as E on E.Id = DE.EmployeeId ";

                var list =await con.QueryAsync<DepartmentD>(sql);
                return list.ToList();
            }
        }

        public async Task<DepartmentD> GetDepartmentById(int Id)
        {
            using (var con = GetConnection())
            {
                var sql = $" select D.Id , D.Name , E.Id as ManagerId , concat(E.FirstName,'  ',E.LastName) as ManagerFullName " +
                          $" from Department D " +
                          $" join Department_Employee as DE on DE.DepartmentId=D.Id " +
                          $" join Employee as E on E.Id = DE.EmployeeId " +
                          $" Where D.Id={Id} ";
                var getById= await con.QuerySingleAsync<DepartmentD>(sql);
                return getById;

            }
        }

        public async Task<int> InsertDepartment(Department department)
        {
            using (var con=GetConnection())
            {
                var sql = $" Insert into  Department(Name) values('{department.Name}')  ";
                var insert =await con.ExecuteAsync(sql);

                return insert;
            }
        }
        public async Task<int> UpdateDepartment(Department department,int Id)
        {
            using (var con = GetConnection())
            {
                var sql = $" Update Department Set Name='{department.Name}'" +
                    $" Where Id={Id} ";
                var update =await con.ExecuteAsync(sql);

                return update;
            }
        }



    }
}
