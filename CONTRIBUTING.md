# Contributing

Contributions are welcome. Please feel free to open issues with suggestions,
feature requests, or bug reports.

## Updating the OpenAPI client

If https://endoflife.date updates its OpenAPI spec, then you can regenerate the
client by following these steps:

1. Ensure Kiota is installed: `dotnet tool install --global Microsoft.OpenApi.Kiota`
1. Update `descriptionLocation` and `descriptionHash` in [kiota-lock.json](src/Client/EndOfLifeDate/kiota-lock.json).
1. Run `kiota update --co --output ./src/Client/EndOfLifeDate/`
1. Commit your changes to a new branch and submit a pull request.
