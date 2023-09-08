using Core.Interfaces;
using Core.Options;
using Core.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Repository.Implementations;
using Repository.Interfaces;
using Services.Implementations;
using Services.Interfaces;
using System.Text;

namespace MetafarChallenge.DependencyInjection
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddServiceDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

            services.AddTransient<IPinHasher, PinHasher>();
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

            services.Configure<JwtOptions>(configuration.GetSection(JwtOptions.JwtAuthOptions));

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAccountService, AccountService>();

            services.AddScoped<ICurrentCustomerAccesor, CurrentCustomerAccesor>();

            return services;
        }
        public static IServiceCollection AddJwt(this IServiceCollection services, IConfiguration configuration)
        {
            JwtOptions authOptions = new JwtOptions();
            configuration.GetSection(JwtOptions.JwtAuthOptions).Bind(authOptions);
            var key = Encoding.ASCII.GetBytes(authOptions.Secret);
            var signingKey = new SymmetricSecurityKey(key);
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuerSigningKey = true,
                       ValidateLifetime = true,
                       ValidateIssuer = true,
                       ValidIssuer = authOptions.Issuer,
                       ValidateAudience = true,
                       ValidAudience = authOptions.Audience,
                       IssuerSigningKey = signingKey
                   };

                   options.RequireHttpsMetadata = false;
                   options.SaveToken = true;
               });

            return services;
        }

    }
}
