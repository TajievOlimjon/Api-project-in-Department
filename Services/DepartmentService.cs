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


        public List<DepartmentD> GetDepartments()
        {
            using (var con =GetConnection())
            {
                var sql = " select D.Id  , D.Name , E.Id as ManagerId , concat(E.FirstName,'  ',E.LastName) as ManagerFullName " +
                          " from Department D " +
                          " join Employee as E on E.Id = D.Id  ";
                         
                var list = con.Query<DepartmentD>(sql);
                return list.ToList();
            }
        }

        public DepartmentD GetDepartmentById(int Id)
        {
            using (var con = GetConnection())
            {
                var sql = $" select D.Id , D.Name , E.Id as ManagerId , concat(E.FirstName,'  ',E.LastName) as ManagerFullName " +
                             $" from Department D " +
                             $" join Employee as E on E.Id = D.Id  " +
                             $" Where D.Id={Id} ";
                var getById=con.QuerySingle<DepartmentD>(sql);
                return getById;

            }
        }

        public int InsertDepartment(Department department)
        {
            using (var con=GetConnection())
            {
                var sql = $" Insert into  Department(Name) values('{department.Name}')  ";
                var insert = con.Execute(sql);

                return insert;
            }
        }
        public int UpdateDepartment(Department department,int Id)
        {
            using (var con = GetConnection())
            {
                var sql = $" Update Department Set Name='{department.Name}'" +
                    $" Where Id={Id} ";
                var update = con.Execute(sql);

                return update;
            }
        }



    }
}
