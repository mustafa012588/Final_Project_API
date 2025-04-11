using API_Project_BL.Dtos.Bug;
//using API_Project_BL.Managers.Bug;
using BugProject.BL;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API_Project_PL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BugController : ControllerBase
    {
        private readonly IBugManger _bugManager;

        public BugController(IBugManger bugManager)
        {
            _bugManager = bugManager;
        }
        [HttpGet]
        public async Task<Ok<List<BugReadDTO>>> GetAll()
        {
            return TypedResults.Ok(await _bugManager.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<Results<Ok<BugReadDTO>, NotFound>>
        GetByIdAsync(Guid id)
        {
            var bug = await _bugManager.GetByIdAsync(id);
            if (bug == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(bug);
        }
    }
}
