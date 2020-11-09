using Microsoft.EntityFrameworkCore;
using Tasks.Api.Models;

namespace Tasks.Api.Data
{
    public class TasksDatabaseContext : DbContext
    {
        public TasksDatabaseContext(DbContextOptions<TasksDatabaseContext> options) : base(options)
        {
        }

        public DbSet<AssignmentGroup> AssignmentGroups { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<AssignmentUnit> AssignmentUnits { get; set; }
    }
}
