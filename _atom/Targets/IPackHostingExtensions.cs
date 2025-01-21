namespace Atom.Targets;

[TargetDefinition]
internal partial interface IPackHostingExtensions : IDotnetPackHelper
{
    public const string HostingExtensionsProjectName = "DecSm.Extensions.Hosting";

    Target PackHostingExtensions =>
        d => d
            .WithDescription("Builds the hosting extensions for the Atom framework.")
            .ProducesArtifact(HostingExtensionsProjectName)
            .Executes(() => DotnetPackProject(new(HostingExtensionsProjectName)));
}
