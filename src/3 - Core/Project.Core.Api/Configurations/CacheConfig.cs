//using Common.Cache;
//using Common.Cache.Redis;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace Project.Core.Api.Configurations
{
    public static partial class CacheConfig
    {
        public static void AddCacheConfiguration(this IServiceCollection services)
        {
            ArgumentNullException.ThrowIfNull(services);

            //services.AddScoped<ICache, RedisCache>();
        }

        public static DateTimeOffset CacheExpirationTime { get { return DateTimeOffset.Now.Date.AddDays(1).AddHours(8).AddMinutes(30); } }

        public static string MakeCacheKeyFromController(ControllerContext controllerContext, object properties = null)
        {
            var controllerName = controllerContext.RouteData.Values["controller"].ToString();
            var actionName = controllerContext.RouteData.Values["action"].ToString();
            var key = $"{controllerName}_{actionName}";

            if (properties is not null)
            {
                var step1 = JsonConvert.SerializeObject(properties, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    DefaultValueHandling = DefaultValueHandling.Ignore,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                });

                var step2 = JsonConvert.DeserializeObject<IDictionary<string, object>>(step1);

                var propertiesKeys = step2.Select(x => x.Key + "=" + ClearCharsRegex().Replace(x.Value.ToString(), "$1").Replace("\"", string.Empty));

                key += $"_{string.Join('&', propertiesKeys.ToArray())}";
            }

            return key;
        }

        [GeneratedRegex("(\"(?:[^\"\\\\]|\\\\.)*\")|\\s+")]
        private static partial Regex ClearCharsRegex();
    }
}