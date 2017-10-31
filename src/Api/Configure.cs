using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api
{
    //public static class Configure
    //{
    //    public static void UseWebApi(this HttpConfiguration config)
    //    {
    //        config.MapHttpAttributeRoutes();

    //        config.Routes.MapHttpRoute(
    //           name: "DefaultApi",
    //           routeTemplate: "api/{controller}/{id}",
    //           defaults: new { id = RouteParameter.Optional }
    //       );
    //    }

    //    public static IAppBuilder UseApiPerOwin(this HttpConfiguration config, IAppBuilder appBuilder)
    //    {
    //        config.UseWebApi();
    //        appBuilder.UseWebApi(config);

    //        return appBuilder;
    //    }

    //    public static IAppBuilder UseContextPerOwin(this IAppBuilder appBuilder)
    //    {
    //        appBuilder.CreatePerOwinContext(ApplicationDbContext.Create);
    //        appBuilder.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
    //        appBuilder.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);

    //        return appBuilder;
    //    }

    //    public static IAppBuilder UseOAuth2Server(this IAppBuilder appBuilder)
    //    {
    //        var option = new OAuthAuthorizationServerOptions()
    //        {
    //            //For Dev enviroment only (on production should be AllowInsecureHttp = false)
    //            AllowInsecureHttp = true,
    //            TokenEndpointPath = new PathString("/oauth/token"),
    //            AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
    //            Provider = new OAuth2ServerProvider()
    //            //AccessTokenFormat = new CustomJwtFormat("http://localhost:59822")
    //        };

    //        // OAuth 2.0 Bearer Access Token Generation
    //        appBuilder.UseOAuthAuthorizationServer(option);

    //        return appBuilder;
    //    }

    //    public static void UseBearerTokens(this IAppBuilder appBuilder)
    //    {

    //        var issuer = "http://localhost:59822";
    //        string audienceId = ConfigurationManager.AppSettings["as:AudienceId"];
    //        byte[] audienceSecret = TextEncodings.Base64Url.Decode(ConfigurationManager.AppSettings["as:AudienceSecret"]);

    //        // Api controllers with an [Authorize] attribute will be validated with JWT
    //        appBuilder.UseJwtBearerAuthentication(
    //            new JwtBearerAuthenticationOptions
    //            {
    //                AuthenticationMode = AuthenticationMode.Active,
    //                AllowedAudiences = new[] { audienceId },
    //                IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[]
    //                {
    //                    new SymmetricKeyIssuerSecurityTokenProvider(issuer, audienceSecret)
    //                }
    //            });
    //    }

    //    public class OAuth2ServerProvider : OAuthAuthorizationServerProvider
    //    {

    //        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
    //        {
    //            context.Validated();
    //            return Task.FromResult<object>(null);
    //        }

    //        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
    //        {
    //            var allowedOrigin = "*";

    //            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowedOrigin });

    //            var userManager = context.OwinContext.GetUserManager<ApplicationUserManager>();

    //            ApplicationUser user = await userManager.FindAsync(context.UserName, context.Password);

    //            if (user == null)
    //            {
    //                context.SetError("invalid_grant", "The user name or password is incorrect.");
    //                return;
    //            }

    //            if (!user.EmailConfirmed)
    //            {
    //                context.SetError("invalid_grant", "User did not confirm email.");
    //                return;
    //            }

    //            var oAuthIdentity = await user.GenerateUserIdentityAsync(userManager, "JWT");

    //            oAuthIdentity.AddClaims(ExtendedClaimsProvider.GetClaims(user));
    //            oAuthIdentity.AddClaims(RolesFromClaims.CreateRolesBasedOnClaims(oAuthIdentity));

    //            var ticket = new AuthenticationTicket(oAuthIdentity, null);

    //            context.Validated(ticket);
    //        }
    //    }
    //}
}
