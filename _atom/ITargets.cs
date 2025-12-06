namespace Atom;

[PublicAPI]
internal interface ITargets : IDotnetPackHelper, IDotnetTestHelper, INugetHelper, IGithubReleaseHelper, ISetupBuildInfo
{
    const string HostingExtensionsProjectName = "DecSm.Extensions.Hosting";
    const string HostingExtensionsTestsProjectName = "DecSm.Extensions.Hosting.Tests";

    [ParamDefinition("nuget-push-feed", "The Nuget feed to push to.", "https://api.nuget.org/v3/index.json")]
    string NugetFeed => GetParam(() => NugetFeed, "https://api.nuget.org/v3/index.json");

    [SecretDefinition("nuget-push-api-key", "The API key to use to push to Nuget.")]
    string NugetApiKey => GetParam(() => NugetApiKey)!;

    Target PackHostingExtensions =>
        d => d
            .DescribedAs("Builds the hosting extensions for the Atom framework.")
            .ProducesArtifact(HostingExtensionsProjectName)
            .Executes(cancellationToken => DotnetPackProject(new(HostingExtensionsProjectName), cancellationToken));

    Target TestHostingExtensions =>
        d => d
            .DescribedAs("Runs the unit tests for the hosting extensions.")
            .ProducesArtifact(HostingExtensionsTestsProjectName)
            .Executes(async cancellationToken =>
            {
                var exitCode = 0;

                exitCode += await RunDotnetUnitTests(new(HostingExtensionsTestsProjectName), cancellationToken);

                if (exitCode != 0)
                    throw new StepFailedException("One or more unit tests failed");
            });

    Target PushToNuget =>
        d => d
            .DescribedAs("Pushes the hosting extensions to Nuget")
            .ConsumesArtifact(nameof(PackHostingExtensions), HostingExtensionsProjectName)
            .RequiresParam(nameof(NugetFeed))
            .RequiresParam(nameof(NugetApiKey))
            .Executes(cancellationToken => PushProject(HostingExtensionsProjectName,
                NugetFeed,
                NugetApiKey,
                cancellationToken: cancellationToken));

    Target PushToRelease =>
        d => d
            .DescribedAs("Pushes the package to the release feed.")
            .RequiresParam(nameof(GithubToken))
            .ConsumesVariable(nameof(SetupBuildInfo), nameof(BuildVersion))
            .ConsumesArtifact(nameof(PackHostingExtensions), HostingExtensionsProjectName)
            .Executes(async () =>
            {
                if (BuildVersion.IsPreRelease)
                {
                    Logger.LogInformation("Skipping release push for pre-release version");

                    return;
                }

                await UploadArtifactToRelease(HostingExtensionsProjectName, $"v{BuildVersion}");
            });
}
