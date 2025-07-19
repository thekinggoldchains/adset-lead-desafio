using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Text.Json;
using System.Text;
using System.Globalization;

namespace Common.Api
{
    public static class HealthConfig
    {
        public static void AddHealthCheck(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
        {
            services.AddHealthChecks()
                .AddSqlServer(configuration.GetConnectionString($"DefaultConnection"))
                .AddCheck("enviroment", () => HealthCheckResult.Healthy(env.EnvironmentName))
                .AddCheck("dateVersion", () => HealthCheckResult.Healthy(GetAssemblyBuildDateTime()?.ToString("yyyy-MM-dd HH:mm")))
                .AddCheck("buildVersion", () => HealthCheckResult.Healthy(configuration.GetValue<string>("BuildVersion")));
        }

        public static void UseHealthCheck(this WebApplication app)
        {
            app.MapHealthChecks("/health", new HealthCheckOptions
            {
                ResponseWriter = WriteResponse
            });
        }

        private static Task WriteResponse(HttpContext context, HealthReport healthReport)
        {
            context.Response.ContentType = "application/json; charset=utf-8";

            var options = new JsonWriterOptions { Indented = true };

            using var memoryStream = new MemoryStream();
            using (var jsonWriter = new Utf8JsonWriter(memoryStream, options))
            {
                jsonWriter.WriteStartObject();
                jsonWriter.WriteString("status", healthReport.Status.ToString());
                jsonWriter.WriteStartObject("results");

                foreach (var healthReportEntry in healthReport.Entries)
                {
                    jsonWriter.WriteStartObject(healthReportEntry.Key);
                    jsonWriter.WriteString("status", healthReportEntry.Value.Status.ToString());
                    jsonWriter.WriteString("description", healthReportEntry.Value.Description);
                    jsonWriter.WriteStartObject("data");

                    foreach (var item in healthReportEntry.Value.Data)
                    {
                        jsonWriter.WritePropertyName(item.Key);

                        JsonSerializer.Serialize(jsonWriter, item.Value,
                            item.Value?.GetType() ?? typeof(object));
                    }

                    jsonWriter.WriteEndObject();
                    jsonWriter.WriteEndObject();
                }

                jsonWriter.WriteEndObject();
                jsonWriter.WriteEndObject();
            }

            return context.Response.WriteAsync(
                Encoding.UTF8.GetString(memoryStream.ToArray()));
        }

        private static DateTime? GetAssemblyBuildDateTime()
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            var attr = Attribute.GetCustomAttribute(assembly, typeof(BuildDateTimeAttribute)) as BuildDateTimeAttribute;
            if (DateTime.TryParse(attr?.Date, new CultureInfo("pt-BR"), out DateTime dt))
                return dt;
            else
                return null;
        }

    }

    [AttributeUsage(AttributeTargets.Assembly)]
    public class BuildDateTimeAttribute : Attribute
    {
        public string Date { get; set; }
        public BuildDateTimeAttribute(string date)
        {
            Date = date;
        }
    }

}
