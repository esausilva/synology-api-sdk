using System.Text.Json.Serialization;
using Synology.Api.Sdk.Extensions;

namespace Synology.Api.Sdk.SynologyApi.Shared.Request;

public class RequestBase
{
    public string Path { get; init; } = "entry.cgi";
    public IReadOnlyDictionary<string, string> AdditionalParameters { get; init; } = new Dictionary<string, string>();
    
    [JsonPropertyName("api")]
    public string Api { get; }

    [JsonPropertyName("version")]
    public int Version { get; }
    
    [JsonPropertyName("method")]
    public string Method { get; }

    /// <summary>
    /// Base class for a Synology API Request
    /// </summary>
    /// <exception cref="ArgumentException">
    /// Thrown if the <paramref name="api"/> parameter is <c>null</c> or white space.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown if the <paramref name="version"/> parameter is zero or negative.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown if the <paramref name="method"/> parameter is <c>null</c> or white space.
    /// </exception>
    protected RequestBase(string api, int version, string method)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(api, nameof(api));
        ArgumentException.ThrowIfNullOrWhiteSpace(method, nameof(method));
        version.ThrowIfZeroOrNegative(nameof(version));
        
        Api = api;
        Version = version;
        Method = method;
    }
}