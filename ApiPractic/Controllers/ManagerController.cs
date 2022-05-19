using Microsoft.AspNetCore.Mvc;
using Services;
using Domain;

namespace ApiPractic.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ManagerController : ControllerBase
    {
        private ManagerService managerService;
       
        public ManagerController(ManagerService managerService)
        {
            this.managerService=managerService;

        }

        [HttpGet("GetManagers")]
        public async Task<List<Department_ManagerDM>> GetManagers()
        {
            return await managerService.GetManagers();
        }

        [HttpPost("InsertManager")]
        public async Task<int> InsertManager(Department_Manager manager)
        {
            return await managerService.InsertManager(manager);
        }



    }
}
