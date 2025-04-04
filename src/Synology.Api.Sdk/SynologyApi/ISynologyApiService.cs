namespace Synology.Api.Sdk.SynologyApi;

public interface ISynologyApiService
{
    Task<T> GetAsync<T>(string url) where T : class;
}