# Synology API SDK

A C# SDK to access the Synology NAS APIs in DiskStation Manager (DSM).

## Recommendations

I would recommend getting familiarized with the Synology APIs first before implementing this SDK, you will have a much easier time implementing it.

I have included [Bruno API Client](https://www.usebruno.com/) scripts ([Bruno Synology API Scripts](./Bruno%20Synology%20API%20Scripts/)) to make it easier.

The official Synology API documentation can be found at [Dev Center](https://www.synology.com/en-af/support/developer#tool). 

### Some Notes

Included implementations in this SDK are some of the FileStation APIs and some of the Photos APIs.

There is no official Photos API documentation, what I have implemented in this SDK is what I gathered from various sources, including Synology's Community Forums, other repos, etc.

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

This wires up DI for the base address in [SdkConfigurationExtensions.ConfigureSynologyApiSdkDependencies](./src/Synology.Api.Sdk/Config/SdkConfigurationExtensions.cs) class.

- `ServerIpOrHostname`: _Required_ - This is usually your NAS IP address or if you have it configured to be accessible via a hostname. If this is not provided, the SDK will throw and exception.
- `Port`: _Optional_ - The NAS' default port number is `5000`.
- `UseHttps`: _Optional_ - Defaults to `false`. 

The end result will be a base URI similar to `http://127.0.0.1:5000`.

---

> More documentation come...
