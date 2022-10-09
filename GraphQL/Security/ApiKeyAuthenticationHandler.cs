using System.Security.Claims;
using System.Text.Encodings.Web;
using KnowCrow.GraphQL.Configuration;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;

namespace KnowCrow.GraphQL.Security;

public static class ApiKeyDefaults
{
    public const string SchemeName = "ApiKey";
}

public class ApiKeyAuthenticationHandler : AuthenticationHandler<ApiKeyAuthenticationSchemeOptions>
{
    private const string APIKEYNAME = "X-ApiKey";

    public ApiKeyAuthenticationHandler(IOptionsMonitor<ApiKeyAuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
    {
    }

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if (Request.Headers.TryGetValue(APIKEYNAME, out var extractedApiKey))
        {
            var keyRole = Options.KeyRoles.Find(k => k.Key?.Equals(extractedApiKey, StringComparison.InvariantCultureIgnoreCase) ?? false);

            if (keyRole == null)
            {
                return Task.FromResult(AuthenticateResult.Fail("Invalid API Key provided."));
            }

            var principal = BuildPrincipal(Scheme.Name, keyRole.Key ?? string.Empty, keyRole.Role ?? string.Empty, Options.ClaimsIssuer ?? ApiKeyDefaults.SchemeName);
            return Task.FromResult(AuthenticateResult.Success(new AuthenticationTicket(principal, Scheme.Name)));
        }

        return Task.FromResult(AuthenticateResult.NoResult());
    }

    static ClaimsPrincipal BuildPrincipal(
    string schemeName,
    string name,
    string role,
    string issuer,
    params Claim[] claims)
    {
        var identity = new ClaimsIdentity(schemeName);

        identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, name, ClaimValueTypes.String, issuer));
        identity.AddClaim(new Claim(ClaimTypes.Name, name, ClaimValueTypes.String, issuer));
        identity.AddClaim(new Claim(ClaimTypes.Role, role, ClaimValueTypes.String, issuer));

        identity.AddClaims(claims);

        return new ClaimsPrincipal(identity);
    }
}