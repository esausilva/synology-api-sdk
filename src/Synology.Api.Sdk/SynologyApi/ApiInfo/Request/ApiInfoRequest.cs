using Synology.Api.Sdk.Constants;
using Synology.Api.Sdk.SynologyApi.Shared.Request;

namespace Synology.Api.Sdk.SynologyApi.ApiInfo.Request;

/// <summary>
/// Represents a request to information about the Synology APIs available for use on the target DiskStation.
/// <br/><br/>
/// <b>Target API</b>: SYNO.API.Info
/// </summary>
/// <exception cref="ArgumentException">
/// Thrown if the <paramref name="version"/> parameter is zero or negative.
/// </exception>
/// <exception cref="ArgumentException">
/// Thrown if the <paramref name="method"/> parameter is <c>null</c> or white space.
/// </exception>
public class ApiInfoRequest(int version, string method) : RequestBase(SynologyApis.Api.Info, version, method)
{
}