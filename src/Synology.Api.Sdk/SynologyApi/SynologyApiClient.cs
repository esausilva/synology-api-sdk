using Synology.Api.Sdk.SynologyApi.ApiInfo;
using Synology.Api.Sdk.SynologyApi.Auth;
using Synology.Api.Sdk.SynologyApi.FileStation;
using Synology.Api.Sdk.SynologyApi.Foto;
using Synology.Api.Sdk.SynologyApi.FotoTeam;

namespace Synology.Api.Sdk.SynologyApi;

internal sealed class SynologyApiClient(
    IApiInfoClient apiInfoApi,
    IAuthClient authApi,
    IFileStationClient fileStationApi,
    IFotoClient fotoApi,
    IFotoTeamClient fotoTeamApi) : ISynologyApiClient
{
    public IApiInfoClient ApiInfoApi { get; } = apiInfoApi;
    public IAuthClient AuthApi { get; } = authApi;
    public IFileStationClient FileStationApi { get; } = fileStationApi;
    public IFotoClient FotoApi { get; } = fotoApi;
    public IFotoTeamClient FotoTeamApi { get; } = fotoTeamApi;
}
