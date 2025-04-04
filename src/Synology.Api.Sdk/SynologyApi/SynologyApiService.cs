using System.Text.Json;
using static Synology.Api.Sdk.Constants.SdkConstants;

namespace Synology.Api.Sdk.SynologyApi;

internal sealed class SynologyApiService : ISynologyApiService
{
    private readonly IHttpClientFactory _httpClientFactoryFactory;

    public SynologyApiService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactoryFactory = httpClientFactory;
    }

    public async Task<T> GetAsync<T>(string url) where T : class
    {
        using var client = _httpClientFactoryFactory.CreateClient(SynologyApiHttpClient);
        var response = await client.GetAsync(url);
        
        response.EnsureSuccessStatusCode();

        var responseData = await response.Content.ReadAsStringAsync();
        var deserialize = JsonSerializer.Deserialize<T>(responseData, 
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        
        return deserialize;
    }
}