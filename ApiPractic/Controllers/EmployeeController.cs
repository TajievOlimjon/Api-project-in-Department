using Microsoft.AspNetCore.Mvc;
using Services;
using Domain;

namespace ApiPractic.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private EmployeeService employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            this.employeeService=employeeService;
        }


        [HttpGet("GetEmployees")]
        public List<EmployeeE> GetEmployees()
        {
            return employeeService.GetEmployees();
        }

        [HttpGet("GetEmployeeById")]
        public EmployeeE GetEmployeeById(int Id)
        {
            return employeeService.GetEmployeeById(Id);
        }

        [HttpPost("InsertEmployee")]
        public int InsertEmployee(Employee employee)
        {
            return employeeService.InsertEmployee(employee);
        }


        [HttpPut("UpdateEmployee")]
        public int UpdateEmployee(Employee employee, int Id)
        { 
           return employeeService.UpdateEmployee(employee, Id);
        }


        }
}
