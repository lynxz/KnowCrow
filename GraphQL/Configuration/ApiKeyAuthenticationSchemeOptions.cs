using Microsoft.AspNetCore.Authentication;

namespace KnowCrow.GraphQL.Configuration;

public class ApiKeyAuthenticationSchemeOptions : AuthenticationSchemeOptions
{
    public List<KeyRoleConfiguration> KeyRoles { get; set; } = new List<KeyRoleConfiguration>();
}