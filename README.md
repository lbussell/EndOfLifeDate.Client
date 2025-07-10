# EndOfLifeDate.Client

This package contains a .NET client library for the [endoflife.date API](https://endoflife.date/).
endoflife.date aggregates product support lifecycle information for over 300
products and makes it easily accessible via API.

This client library is generated using Kiota based on the [endoflife.date OpenAPI description](https://endoflife.date/docs/api/v1/openapi.yml).
This project is not affiliated with https://endoflife.date/ or https://github.com/endoflife-date.

## Features

- Query product releases and support lifecycles
- [Native AOT](https://learn.microsoft.com/dotnet/core/deploying/native-aot/) compatible
- `async`/`await` support

## Installation

The project is not published to NuGet.org yet. To try it out, use the GitHub packages feed for now:
https://github.com/lbussell/EndOfLifeDate.Client/pkgs/nuget/EndOfLifeDate.Client

## Usage

```csharp
using EndOfLifeDate.Client;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;

// Create client
var authProvider = new AnonymousAuthenticationProvider();
var adapter = new HttpClientRequestAdapter(authProvider);
var client = new EndOfLifeDateClient(adapter);

// Get latest release information
var productName = "dotnet";
var response = await client.Products[productName].Releases.Latest.GetAsync();
var release = response?.Result ?? throw new Exception($"There was a problem getting {productName} release info");

Console.WriteLine($"Latest {productName} version: {release.Latest?.Name}");
Console.WriteLine($"End of life: {release.EolFrom}");
Console.WriteLine($"Is LTS: {release.IsLts}");
```

Also see the [Example project](./src/Example/Program.cs).

## Contributing

Contributions are welcome. See [CONTRIBUTING.md](./CONTRIBUTING.md) for details.

## License

This project is licensed under the MIT license.
See the [LICENSE](./LICENSE) file in the project root for more details.
