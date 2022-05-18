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
        public List<DepartmentD> GetDepartments()
        {
            return departmentService.GetDepartments();
        }

        [HttpGet("GetDepartmentById")]
        public DepartmentD GetDepartmentById(int Id)
        {
            return departmentService.GetDepartmentById(Id);

        }

        [HttpPost("InsertDepartment")]

        public int InsertDepartment(Department department)
        {
            return departmentService.InsertDepartment(department);
        }

        [HttpPut("UpdateDepartment")]
        public int UpdateDepartment(Department department, int Id)
        {
            return departmentService.UpdateDepartment(department,Id);
        }
    }
}
