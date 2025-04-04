using System.Text.Json.Serialization;
using Synology.Api.Sdk.SynologyApi.Shared.Request;

namespace Synology.Api.Sdk.SynologyApi.Auth.Request;

public sealed class LoginRequest : RequestBase
{
    [JsonPropertyName("account")]
    public string Account { get; }
    
    [JsonPropertyName("passwd")]
    public string Password { get; }

    [JsonPropertyName("enable_syno_token")]
    public string EnableSynoToken { get; }

    public LoginRequest(string api, string method, int version, string account, 
        string password, string enableSynoToken = "yes") : base(api, version, method)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(account, nameof(account));
        ArgumentException.ThrowIfNullOrWhiteSpace(password, nameof(password));
        
        Account = account;
        Password = password;
        EnableSynoToken = enableSynoToken;
    }
}