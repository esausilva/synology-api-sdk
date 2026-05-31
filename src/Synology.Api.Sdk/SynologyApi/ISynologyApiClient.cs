using Synology.Api.Sdk.SynologyApi.ApiInfo;
using Synology.Api.Sdk.SynologyApi.Auth;
using Synology.Api.Sdk.SynologyApi.FileStation;
using Synology.Api.Sdk.SynologyApi.Foto;
using Synology.Api.Sdk.SynologyApi.FotoTeam;

namespace Synology.Api.Sdk.SynologyApi;

public interface ISynologyApiClient
{
    IApiInfoClient ApiInfoApi { get; }
    IAuthClient AuthApi { get; }
    IFileStationClient FileStationApi { get; }
    IFotoClient FotoApi { get; }
    IFotoTeamClient FotoTeamApi { get; }
}
