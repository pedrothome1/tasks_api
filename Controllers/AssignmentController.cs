using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tasks.Api.Data;
using Tasks.Api.Models;

namespace Tasks.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public class AssignmentController : ControllerBase
    {
        private readonly TasksDatabaseContext _context;

        public AssignmentController(TasksDatabaseContext context)
        {
            _context = context;
        }

        [HttpGet("AssignmentGroup/{groupId}/Assignments")]
        public async Task<IActionResult> Index()
        {
            return Ok(await _context.Assignments.Include(x => x.Group).AsNoTracking().ToListAsync());
        }

        [HttpPost("AssignmentGroup/{groupId}/Assignments")]
        public async Task<IActionResult> Store([FromRoute] Guid groupId, [FromBody] Assignment assignment)
        {
            var group = await _context.AssignmentGroups.FindAsync(groupId);

            if (group == null)
                return NotFound();

            group.Assignments.Add(assignment);
            await _context.SaveChangesAsync();

            return Created(HttpContext.Request.Path.ToUriComponent(), assignment);
        }
    }
}
