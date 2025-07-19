using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Project.Core.Api.Configurations
{
    public static class AuthorizationConfig
    {
        public static void AddAuthorizationConfiguration(this IServiceCollection services)
        {
            ArgumentNullException.ThrowIfNull(services);

            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                    .RequireAuthenticatedUser().Build());

                auth.AddPolicy("Administrator", policy => policy.RequireRole("Administrator"));
                auth.AddPolicy("Usuario", policy => policy.RequireRole("Usuario"));
            });
        }
    }
}