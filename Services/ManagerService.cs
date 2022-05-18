using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Domain;
using Npgsql;

namespace Services
{
    public class ManagerService
    {
        private string connectionString = "Server=127.0.0.1;Port=5432;Database=Department;User Id=postgres;Password=0711;";

        public NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(connectionString);
        }

        public List<Department_ManagerDM> GetManagers()
        {
            using (var con =GetConnection())
            {
                var sql = " select E.Id as ManagerId, concat(E.FirstName,' ',E.LastName) as ManagerFullName , " +
                    " D.Id as DepartmentId, D.Name as DepartmentName, DM.FromDate, DM.ToDate " +
                    " from Department_Manager DM " +
                    " join Employee as E on E.Id = DM.EmployeeId " +
                    " join Department as D on D.Id = DM.DepartmentId ";
                var list = con.Query<Department_ManagerDM>(sql);
                return list.ToList();
            }
        }


        public int InsertManager(Department_Manager manager)
        {
            using (var con=GetConnection())
            {
                var sql =$" Insert into Department_Manager(EmployeeId,DepartmentId,FromDate,ToDate) " +
                    $" values({manager.EmployeeId},{manager.DepartmentId},'{manager.FromDate}','{manager.ToDate}') ";
                var insert = con.Execute(sql);
                return insert;

            }
        }

    }
}
