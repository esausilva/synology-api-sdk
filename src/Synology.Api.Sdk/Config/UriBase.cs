using System.ComponentModel.DataAnnotations;

namespace Synology.Api.Sdk.Config;
public class UriBase
{
    [Required] 
    public string ServerIpOrHostname { get; init; } = "";
    
    public int? Port { get; init; }
    public bool UseHttps { get; init; } = false;
}