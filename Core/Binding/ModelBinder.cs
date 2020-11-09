using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Tasks.Api.Core.Json;

namespace Tasks.Api.Core.Binding
{
    public class ModelBinder : IModelBinder
    {
        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
                throw new ArgumentNullException(nameof(bindingContext));

            using var reader = new StreamReader(bindingContext.HttpContext.Request.Body);
            var body = await reader.ReadToEndAsync();

            var jsonOptions = SerializationOptions.Create();
            var model = JsonConvert.DeserializeObject(body, bindingContext.ModelType, jsonOptions);

            bindingContext.Result = ModelBindingResult.Success(GuardModel(model));
        }

        private static object GuardModel(object model)
        {
            model.GetType()
                .GetProperties()
                .ToList()
                .ForEach((property) => GuardModelProperty(model, property));

            return model;
        }

        private static void GuardModelProperty(object model, PropertyInfo property)
        {
            if (property.GetCustomAttribute<GuardedAttribute>() != null)
                property.SetValue(model, GetDefaultValue(property.PropertyType));
        }

        private static object GetDefaultValue(Type type) =>
            type.IsValueType ? Activator.CreateInstance(type) : null;
    }
}
