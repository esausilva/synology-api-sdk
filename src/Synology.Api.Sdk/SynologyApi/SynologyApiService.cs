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

    public async Task<T> GetAsync<T>(string requestUrl, CancellationToken cancellationToken = default) where T : ResponseBase
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(requestUrl);
        
        using var httpClient = _httpClientFactoryFactory.CreateClient(SynologyApiHttpClient);

        var response = await httpClient.GetAsync(requestUrl, cancellationToken);
        var responseData = await response.Content.ReadAsStringAsync(cancellationToken);
        var result = JsonSerializer.Deserialize<T>(responseData, 
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        
        result
            .GetType()
            .GetProperty("StatusCode")?
            .SetValue(result, response.StatusCode);
        
        return result;
    }
    
    public async Task<RawResponse> GetRawResponseAsync(string requestUrl, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(requestUrl);
        
        using var httpClient = _httpClientFactoryFactory.CreateClient(SynologyApiHttpClient);

        var response = await httpClient.GetAsync(requestUrl, cancellationToken);
        var isError = await IsErrorResponse();
        
        var result = isError ?? new RawResponse
        {
            HttpResponse = response, 
            Success = true, 
            StatusCode = response.StatusCode
        };
        
        if (isError is not null)
        {
            result
                .GetType()
                .GetProperty("StatusCode")?
                .SetValue(result, response.StatusCode);
        }
        
        return result;
        
        async Task<RawResponse?> IsErrorResponse() =>
            response.Content.Headers.ContentType?.MediaType == "application/json"
                ? await JsonSerializer.DeserializeAsync<RawResponse>(await response.Content.ReadAsStreamAsync(cancellationToken),
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }, cancellationToken)
                : null;
    }
}