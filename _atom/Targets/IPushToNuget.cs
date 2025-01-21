namespace Atom.Targets;

[TargetDefinition]
internal partial interface IPushToNuget : INugetHelper
{
    [ParamDefinition("nuget-push-feed", "The Nuget feed to push to.", "https://api.nuget.org/v3/index.json")]
    string NugetFeed => GetParam(() => NugetFeed, "https://api.nuget.org/v3/index.json");

    [SecretDefinition("nuget-push-api-key", "The API key to use to push to Nuget.")]
    string NugetApiKey => GetParam(() => NugetApiKey)!;

    Target PushToNuget =>
        d => d
            .WithDescription("Pushes the hosting extensions to Nuget")
            .ConsumesArtifact(Commands.PackHostingExtensions, IPackHostingExtensions.HostingExtensionsProjectName)
            .RequiresParam(Params.NugetFeed)
            .RequiresParam(Params.NugetApiKey)
            .Executes(() => PushProject(IPackHostingExtensions.HostingExtensionsProjectName, NugetFeed, NugetApiKey));
}
