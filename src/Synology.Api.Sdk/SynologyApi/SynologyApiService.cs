using System.Text.Json;
using Synology.Api.Sdk.SynologyApi.Shared.Response;
using static Synology.Api.Sdk.Constants.SdkConstants;

namespace Synology.Api.Sdk.SynologyApi;

internal sealed class SynologyApiService : ISynologyApiService
{
    private readonly IHttpClientFactory _httpClientFactoryFactory;

    public SynologyApiService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactoryFactory = httpClientFactory;
    }

    public async Task<T> GetAsync<T>(string url, CancellationToken cancellationToken = default) where T : ResponseBase
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(url);
        
        using var client = _httpClientFactoryFactory.CreateClient(SynologyApiHttpClient);
        var response = await client.GetAsync(url, cancellationToken);
        
        var responseData = await response.Content.ReadAsStringAsync(cancellationToken);
        var deserialize = JsonSerializer.Deserialize<T>(responseData, 
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        
        deserialize.GetType().GetProperty("StatusCode")?.SetValue(deserialize, response.StatusCode);
        
        return deserialize;
    }
}