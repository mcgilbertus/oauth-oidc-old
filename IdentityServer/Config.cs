﻿using Duende.IdentityServer.Models;

namespace IdentityServer;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile()
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
            new ApiScope(name: "api1", displayName: "MyAPI"),
        };

    public static IEnumerable<Client> Clients =>
        new Client[]
        {
            new Client
            {
                ClientId = "client",
                // no interactive user, use the clientid/secret for authentication
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                // secret for authentication
                ClientSecrets = { new Secret("secret".Sha256()) },
                // scopes that client has access to
                AllowedScopes = { "api1" },
                Enabled = true
            },
            new Client
            {
                ClientId = "client2",
                AllowedGrantTypes = GrantTypes.Code,
                // secret for authentication
                ClientSecrets = { new Secret("secret2".Sha256()) },
                // scopes that client has access to
                AllowedScopes = { "openid", "api1" },
                RedirectUris = { "https://localhost:5001/identity/tokenfromcode" },
                RequirePkce = false,
                Enabled = true
            }
        };
}