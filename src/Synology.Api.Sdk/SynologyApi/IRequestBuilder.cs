using Synology.Api.Sdk.SynologyApi.Shared.Request;

namespace Synology.Api.Sdk.SynologyApi;

public interface IRequestBuilder
{
    string BuildUrl<T>(T request) where T : RequestBase;
}