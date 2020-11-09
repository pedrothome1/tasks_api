using System;

namespace Tasks.Api.Core.Binding
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class GuardedAttribute : Attribute
    {
    }
}
