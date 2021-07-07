using DataAccess.Models;
using Infrastructure.UnitsOfWork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OneController : ControllerBase
    {
        private readonly OneUnitOfWork oneUnitOfWork;

        public SessionController(OneUnitOfWork oneUnitOfWork)
        {
            this.oneUnitOfWork = oneUnitOfWork;
        }

        [HttpPost]
        public async Task<ActionResult> Open([FromBody] SomeModel model)
        {            
            oneUnitOfWork.OneRepository.AddAsync(model);
            oneUnitOfWork.Commit();
            return Ok();
        }      
    }
}
