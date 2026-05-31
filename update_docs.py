import os
import re

docs_dir = "/Users/esausilva/Development/Projects/synology/synology-api-sdk/Docs"

# Map of request prefix -> client property and method pattern
# E.g. fileStationListRequest -> FileStationApi.ListShareAsync
mappings = {
    "apiInfo": ("ApiInfoApi", "QueryAsync"),
    "login": ("AuthApi", "LoginAsync"),
    "logout": ("AuthApi", "LogoutAsync"),
    "fileStationDownload": ("FileStationApi", "DownloadAsync"),
    "fileStationList": ("FileStationApi", "ListFileAsync"), # Assuming ListFileAsync for simplicity since we can't determine runtime
    "fileStationSearch": ("FileStationApi", "SearchListAsync"), # Assuming SearchListAsync
    "fotoBrowseAlbum": ("FotoApi", "BrowseAlbumAsync"),
    "fotoTeamBrowseFolder": ("FotoTeamApi", "BrowseFolderAsync"),
    "fotoTeamBrowseItem": ("FotoTeamApi", "BrowseItemAsync"),
    "fotoTeamBrowseRecentlyAdded": ("FotoTeamApi", "BrowseRecentlyAddedAsync"),
    "fotoTeamBrowseTimeline": ("FotoTeamApi", "BrowseTimelineAsync"),
    "fotoTeamDownload": ("FotoTeamApi", "DownloadAsync"),
    "fotoTeamSearchSearch": ("FotoTeamApi", "SearchAsync"),
    "fotoTeamThumbnail": ("FotoTeamApi", "ThumbnailAsync"),
}

def update_file(filepath):
    with open(filepath, "r") as f:
        content = f.read()

    if "ISynologyApiRequestBuilder" not in content:
        return

    # Replace the DI lines
    content = re.sub(
        r'var synoApiRequestBuilder = services\.GetRequiredService<ISynologyApiRequestBuilder>\(\);\nvar synoApiService = services\.GetRequiredService<ISynologyApiService>\(\);',
        r'var synologyApiClient = services.GetRequiredService<ISynologyApiClient>();',
        content
    )

    # Match the url build line: var <prefix>Url = synoApiRequestBuilder.BuildUrl(<prefix>Request);
    # And the response line: var <prefix>Response = await synoApiService.GetAsync<Type>(<prefix>Url, cancellationToken);
    # OR: var <prefix>Response = await synoApiService.GetRawResponseAsync(<prefix>Url, cancellationToken);
    
    pattern = re.sub(
        r'var (\w+)Url = synoApiRequestBuilder\.BuildUrl\(\1Request\);\n(var \1Response = await synoApiService\.(?:GetAsync<[^>]+>|GetRawResponseAsync)\(\1Url, cancellationToken\);)',
        r'// MARKER \1\n\2',
        content
    )
    
    # Let's do it with a regex function to look up the mapping
    def replacer(match):
        prefix = match.group(1)
        res_line = match.group(2)
        
        if prefix in mappings:
            client, method = mappings[prefix]
            return f"var {prefix}Response = await synologyApiClient.{client}.{method}({prefix}Request, cancellationToken);"
        else:
            return match.group(0) # fallback
            
    content = re.sub(
        r'var (\w+)Url = synoApiRequestBuilder\.BuildUrl\(\1Request\);\s*\nvar \1Response = await synoApiService\.(?:GetAsync<[^>]+>|GetRawResponseAsync)\(\1Url, cancellationToken\);',
        replacer,
        content
    )
    
    with open(filepath, "w") as f:
        f.write(content)
        
    print(f"Updated {filepath}")

for root, dirs, files in os.walk(docs_dir):
    for file in files:
        if file.endswith(".md"):
            update_file(os.path.join(root, file))

