using System;
using System.ComponentModel.DataAnnotations.Schema;
using Tasks.Api.Core.Binding;
using Tasks.Api.Interfaces;

namespace Tasks.Api.Models
{
    public abstract class ModelBase : IRequestModel
    {
        [Guarded]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
    }
}
