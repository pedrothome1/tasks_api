using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Tasks.Api.Interfaces;

namespace Tasks.Api.Core.Binding
{
    public class ModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if (context.Metadata.ModelType.GetInterfaces().Contains(typeof(IRequestModel)))
                return new ModelBinder();

            return null;
        }
    }
}
