using Application.Security.ActiveDirectory;
using Application.Security.JwtToken;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace Application.Security
{
    public static class AuthorizationExtension
    {
        private const string SecretKey = "iNivDmHLpUA223sqsfhqGbMRdRj1PVkH"; // todo: get this from somewhere secure
        private static readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));

        public static IServiceCollection AddCustomAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            #region Jwt Token Configuration

            services.AddSingleton<IJwtFactory, JwtFactory>();
            var jwtAppSettingOptions = configuration.GetSection(nameof(JwtIssuerOptions));

            services.Configure<JwtIssuerOptions>(options =>
                {
                    options.Issuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                    options.Audience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)];
                    options.SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
                });

            //services.Configure<IISOptions>(options => { options.AutomaticAuthentication = true; });
            var jwtAppSettingOptionsd = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)],
                        ValidateAudience = true,
                        ValidAudience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)],
                        RequireExpirationTime = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = _signingKey,
                        ClockSkew = TimeSpan.Zero
                    };
                });

            // api user claim policy
            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("ApiUser",
            //        policy => policy.RequireClaim(Constants.Strings.JwtClaimIdentifiers.Rol,
            //            Constants.Strings.JwtClaims.ApiAccess));
            //});

            #endregion Jwt Token Configuration

            services.Configure<LdapConfig>(configuration.GetSection("ldap"));

            return services;
        }
    }
}
