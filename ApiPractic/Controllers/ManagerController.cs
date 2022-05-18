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
        public List<Department_ManagerDM> GetManagers()
        {
            return managerService.GetManagers();
        }

        [HttpPost("InsertManager")]
        public int InsertManager(Department_Manager manager)
        {
            return managerService.InsertManager(manager);
        }



    }
}
