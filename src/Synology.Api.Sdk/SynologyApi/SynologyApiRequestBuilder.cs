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
            var encodedPropertyValue = GetEncodedPropertyValue(propertyValue);

            parameters.Add(jsonPropertyName, encodedPropertyValue);
        }
        
        parameters.Merge(request.AdditionalParameters);
        
        var scheme = _uriBase.UseHttps ? "https" : "http";
        var port = _uriBase.Port.HasValue ? $":{_uriBase.Port.Value}" : "";
        var queryString = BuildQueryString(parameters);
        
        return $"{scheme}://{_uriBase.ServerIpOrHostname}{port}/webapi/{request.Path}?{queryString}";
    }

    private static string GetEncodedPropertyValue(object? propertyValue)
    {
        string encodedPropertyValue;
        
        if (IsEnumerable(propertyValue) && propertyValue is IEnumerable<string> stringValues)
        {
            encodedPropertyValue = ConvertToJsonArray(stringValues);
        }
        else
        {
            encodedPropertyValue = EncodeUrl(propertyValue?.ToString() ?? string.Empty);
        }
        
        return encodedPropertyValue;
    }

    private static bool IsEnumerable(object? value) => value is IEnumerable<object> && value?.GetType() != typeof(string);

    private static string ConvertToJsonArray(IEnumerable<string> values)
    {
        var jsonArray = values
            .Select(EncodeUrl)
            .Aggregate("[", (current, param) => current + $"\"{param}\",");
        
        return jsonArray.TrimEnd(',') + "]";
    }

    private static string EncodeUrl(string url) => Uri.EscapeDataString(url);

    private static string BuildQueryString(IReadOnlyDictionary<string, string> parameters) => 
        string.Join("&", parameters.Select(x => $"{x.Key}={x.Value}"));
}