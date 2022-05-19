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
        public async Task<List<EmployeeE>> GetEmployees()
        {
            return await employeeService.GetEmployees();
        }

        [HttpGet("GetEmployeeById")]
        public async Task<EmployeeE> GetEmployeeById(int Id)
        {
            return await employeeService.GetEmployeeById(Id);
        }

        [HttpPost("InsertEmployee")]
        public async Task<int> InsertEmployee(Employee employee)
        {
            return await employeeService.InsertEmployee(employee);
        }


        [HttpPut("UpdateEmployee")]
        public async Task<int> UpdateEmployee(Employee employee, int Id)
        { 
           return await employeeService.UpdateEmployee(employee, Id);
        }


        }
}
