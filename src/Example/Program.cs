// SPDX-FileCopyrightText: Copyright (c) 2025 Logan Bussell
// SPDX-License-Identifier: MIT

using EndOfLifeDate.Client;
using EndOfLifeDate.Client.Models;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;

var authProvider = new AnonymousAuthenticationProvider();
var adapter = new HttpClientRequestAdapter(authProvider);
var endOfLifeDate = new EndOfLifeDateClient(adapter);

var productName = "dotnet";
var request = endOfLifeDate.Products[productName].Releases.Latest;

var response = await request.GetAsync();
ProductRelease release = response?.Result ??
    throw new Exception($"Latest release for {productName} not found.");

var latestVersion = release.Latest!;

var eolDate = release.EolFrom;
var eolDateString = eolDate.HasValue ? eolDate.Value.ToString() : "Unknown";

Console.WriteLine(
    $"""
    Product: {productName} {release.Name}
    Latest version: {latestVersion.Name} released on {latestVersion.Date}
    Release notes: {latestVersion.Link}
    Is LTS: {release.IsLts}
    Original release date: {release.ReleaseDate}
    End of life date: {eolDateString}
    """
);
