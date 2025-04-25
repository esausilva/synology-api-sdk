using System.Text.Json.Serialization;
using Synology.Api.Sdk.Constants;
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

    /// <summary>
    /// Represents a request to authenticate to Synology NAS.
    /// <br/><br/>
    /// <b>Target API</b>: SYNO.API.Auth
    /// </summary>
    /// <exception cref="ArgumentException">
    /// Thrown if the <paramref name="version"/> parameter is zero or negative.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown if the <paramref name="method"/> parameter is <c>null</c> or white space.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown if the <paramref name="account"/> parameter is <c>null</c> or white space.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown if the <paramref name="password"/> parameter is <c>null</c> or white space.
    /// </exception>
    public LoginRequest(string method, int version, string account, string password, string enableSynoToken = "yes") 
        : base(SynologyApis.Api.Auth, version, method)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(account, nameof(account));
        ArgumentException.ThrowIfNullOrWhiteSpace(password, nameof(password));
        
        Account = account;
        Password = password;
        EnableSynoToken = enableSynoToken;
    }
}