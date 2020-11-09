using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Tasks.Api.Core.Binding;

namespace Tasks.Api.Models
{
    public class AssignmentGroup : ModelBase
    {
        [Required]
        public string Name { get; set; }

        [Guarded]
        public ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();
    }
}
