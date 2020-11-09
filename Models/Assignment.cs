using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Tasks.Api.Core.Binding;
using Tasks.Api.Models.Enums;

namespace Tasks.Api.Models
{
    public class Assignment : ModelBase
    {
        [Required]
        public string Project { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public Status Status { get; set; }

        public Estimate Estimate { get; set; }

        [Guarded]
        public AssignmentGroup Group { get; set; }

        [Guarded]
        public ICollection<AssignmentUnit> Units { get; set; } = new List<AssignmentUnit>();
    }
}
