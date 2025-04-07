using System.Text.Json.Serialization;
using Microsoft.Extensions.Options;
using Synology.Api.Sdk.Config;
using Synology.Api.Sdk.Extensions;
using Synology.Api.Sdk.SynologyApi.Shared.Request;

namespace Synology.Api.Sdk.SynologyApi;

internal sealed class SynologyApiRequestBuilder(IOptions<UriBase> uriBase) : ISynologyApiRequestBuilder
{
    private readonly UriBase _uriBase = uriBase.Value;

    public string BuildUrl<T>(T request) where T : RequestBase
    {
        var parameters = new Dictionary<string, string>();
        var properties = request.GetType().GetProperties();
        
        foreach (var property in properties)
        {
            if (property.GetCustomAttributes(typeof(JsonPropertyNameAttribute), true).FirstOrDefault() is not
                JsonPropertyNameAttribute jsonPropertyNameAttribute)
            {
                continue;
            }
            
            var jsonPropertyName = jsonPropertyNameAttribute.Name;
            var propertyValue = property.GetValue(request);
            var encodedPropertyValue = EncodeUrl(propertyValue?.ToString() ?? string.Empty);
            
            parameters.Add(jsonPropertyName, encodedPropertyValue);
        }
        
        parameters.Merge(request.AdditionalParameters);
        
        var scheme = _uriBase.UseHttps ? "https" : "http";
        var port = _uriBase.Port.HasValue ? $":{_uriBase.Port.Value}" : "";
        var queryString = BuildQueryString(parameters);
        
        return $"{scheme}://{_uriBase.ServerIpOrHostname}{port}/webapi/{request.Path}?{queryString}";
    }
    
    private static string BuildQueryString(IReadOnlyDictionary<string, string> parameters) => 
        string.Join("&", parameters.Select(x => $"{x.Key}={x.Value}"));
    
    private static string EncodeUrl(string url) => Uri.EscapeDataString(url);
}