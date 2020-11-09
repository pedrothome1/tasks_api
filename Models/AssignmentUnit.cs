using System;
using Tasks.Api.Core.Binding;

namespace Tasks.Api.Models
{
    public class AssignmentUnit : ModelBase
    {
        [Guarded]
        public Assignment Assignment { get; set; }

        public DateTimeOffset StartedAt { get; set; }

        public DateTimeOffset EndedAt { get; set; }
    }
}
