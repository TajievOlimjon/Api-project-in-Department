using Microsoft.AspNetCore.Mvc;
using Services;
using Domain;

namespace ApiPractic.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private DepartmentService departmentService;
        public DepartmentController(DepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }

        [HttpGet("GetDepartments")]
        public async Task<List<DepartmentD>> GetDepartments()
        {
            return await departmentService.GetDepartments();
        }

        [HttpGet("GetDepartmentById")]
        public async Task<DepartmentD> GetDepartmentById(int Id)
        { 
            return await departmentService.GetDepartmentById(Id);

        }

        [HttpPost("InsertDepartment")]

        public async Task<int> InsertDepartment(Department department)
        {
            return await departmentService.InsertDepartment(department);
        }

        [HttpPut("UpdateDepartment")]
        public async Task<int> UpdateDepartment(Department department, int Id)
        {
            return await departmentService.UpdateDepartment(department,Id);
        }
    }
}
