using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tasks.Api.Data;
using Tasks.Api.Models;

namespace Tasks.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssignmentGroupController : ControllerBase
    {
        private readonly TasksDatabaseContext _context;

        public AssignmentGroupController(TasksDatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var groups = await _context.AssignmentGroups
                .Include(x => x.Assignments)
                .AsNoTracking()
                .ToArrayAsync();

            return Ok(groups);
        }

        [HttpPost]
        public async Task<IActionResult> Store([FromBody] AssignmentGroup assignmentGroup)
        {
            _context.Add(assignmentGroup);
            await _context.SaveChangesAsync();

            return Created(HttpContext.Request.Path.ToUriComponent(), assignmentGroup);
        }
    }
}
