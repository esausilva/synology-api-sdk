# Synology API SDK

A C# SDK to access the Synology NAS APIs in DiskStation Manager (DSM).

## Implemented APIs

Included implementations in this SDK are some of the FileStation APIs and some of the Photos APIs.

There is no official Photos API documentation; what I have implemented in this SDK is what I gathered from various sources, including Synology's Community Forums, other repos, etc.

## Installation

You will need to have the following in your `appsettings.json` file.

```json
{
  "UriBase": {
    "ServerIpOrHostname": "<<SERVER_IP_OR_HOSTNAME>>",
    "Port": 5000,
    "UseHttps": false 
  }
}
```

| Option               | Required | Description                                                                                                                               |
| -------------------- | :------: | ----------------------------------------------------------------------------------------------------------------------------------------- |
| `ServerIpOrHostname` |    ✅    | Your NAS IP address or hostname. If not provided, the SDK will throw `Microsoft.Extensions.Options.OptionsValidationException` exception. |
| `Port`               |          | The NAS' default port number is `5000`.                                                                                                   |
| `UseHttps`           |          | Defaults to `false`.                                                                                                                      |

The result will be a base URI similar to `http://127.0.0.1:5000`.

--- 

See the project's GitHub repo for a complete guide: [Synology API SDK](https://github.com/esausilva/synology-api-sdk)
