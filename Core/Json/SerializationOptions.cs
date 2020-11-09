using Newtonsoft.Json;

namespace Tasks.Api.Core.Json
{
    public static class SerializationOptions
    {
        public static JsonSerializerSettings Create()
        {
            var options = new JsonSerializerSettings();
            Set(options);

            return options;
        }

        public static void Set(JsonSerializerSettings options)
        {
            options.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            options.Converters.Add(new StringEnumConverter());
        }
    }
}
