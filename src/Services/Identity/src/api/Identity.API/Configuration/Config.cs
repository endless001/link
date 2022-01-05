using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;

namespace Identity.API.Configuration
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApis()
        {
            return new List<ApiResource>
            {
                 new ApiResource("account", "Account Service"),
                 new ApiResource("contact", "Contact Service"),
                 new ApiResource("download", "Download Service"),
                 new ApiResource("upload", "Upload Service"),
            };
        }

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>
             {
                 new ApiScope(name: "account",   displayName: "Account Service"),
                 new ApiScope(name: "contact",  displayName: "Contact Service"),
                 new ApiScope(name: "download", displayName: "Download Service"),
                 new ApiScope(name: "upload", displayName: "Upload Service")
             };
        }

        public static IEnumerable<IdentityResource> GetResources()
        {
            return new List<IdentityResource>
            {
              new IdentityResources.OpenId(),
              new IdentityResources.Profile(),
            };
        }

        public static IEnumerable<Client> GetClients(Dictionary<string, string> clientsUrl)
        {
            return new List<Client>
            {
                new Client
                 {
                   ClientId = "api",
                   ClientName = "Api Client",
                   ClientSecrets = new List<Secret>
                   {
                     new Secret("secret".Sha256())
                   },
                   AllowedGrantTypes = {GrantType.ResourceOwnerPassword, "sms"},
                   AllowedScopes = new List<string>
                   {
                     IdentityServerConstants.StandardScopes.OpenId,
                     IdentityServerConstants.StandardScopes.Profile,
                     IdentityServerConstants.StandardScopes.OfflineAccess,
                     "account",
                     "contact",
                     "download",
                     "upload",
                   },
                   AllowOfflineAccess = true
                 },
                 new Client
                 {
                   ClientId = "spa",
                   ClientName = "SPA Client",
                   ClientSecrets = new List<Secret>
                   {
                     new Secret("secret".Sha256())
                   },
                   AllowedGrantTypes = GrantTypes.Implicit,
                   AllowAccessTokensViaBrowser = false,
                   RequireConsent = true,
                   AllowOfflineAccess = true,
                   AlwaysIncludeUserClaimsInIdToken = true,
                   RedirectUris = new List<string>
                   {
                     $"{clientsUrl["Spa"]}/"
                   },
                   PostLogoutRedirectUris = new List<string>
                   {
                     $"{clientsUrl["Spa"]}/"
                   },
                   AllowedCorsOrigins = new List<string>
                   {
                        $"{clientsUrl["Spa"]}"
                   },
                   AllowedScopes = new List<string>
                   {
                     IdentityServerConstants.StandardScopes.OpenId,
                     IdentityServerConstants.StandardScopes.Profile,
                     IdentityServerConstants.StandardScopes.OfflineAccess,
                     "account",
                     "contact",
                     "download",
                     "upload",
                   },

                   AccessTokenLifetime = 60 * 60 * 2, // 2 hours
                   IdentityTokenLifetime = 60 * 60 * 2 // 2 hours
                 },
                new Client
                {
                    ClientId = "mvc",
                    ClientName = "MVC Client",
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    },
                    ClientUri = $"{clientsUrl["Mvc"]}",
                    AllowedGrantTypes = GrantTypes.Hybrid,
                    AllowAccessTokensViaBrowser = false,
                    RequireConsent = false,
                    AllowOfflineAccess = true,
                    AlwaysIncludeUserClaimsInIdToken = true,
                    RequirePkce = false,
                    RedirectUris = new List<string>
                    {
                        $"{clientsUrl["Mvc"]}/signin-oidc"
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        $"{clientsUrl["Mvc"]}/signout-callback-oidc"
                    },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                       "account",
                       "contact",
                       "download",
                       "upload",
                    },
                    AccessTokenLifetime = 60*60*2, // 2 hours
                    IdentityTokenLifetime= 60*60*2 // 2 hours
                }
                }; 
    } 
    }
}
