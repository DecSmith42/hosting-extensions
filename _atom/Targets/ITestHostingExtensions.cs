namespace Atom.Targets;

[TargetDefinition]
internal partial interface ITestHostingExtensions : IDotnetTestHelper
{
    public const string HostingExtensionsTestsProjectName = "DecSm.Extensions.Hosting.Tests";

    Target TestHostingExtensions =>
        d => d
            .WithDescription("Runs the unit tests for the hosting extensions.")
            .ProducesArtifact(HostingExtensionsTestsProjectName)
            .Executes(async () =>
            {
                var exitCode = 0;

                exitCode += await RunDotnetUnitTests(new(HostingExtensionsTestsProjectName));

                if (exitCode != 0)
                    throw new StepFailedException("One or more unit tests failed");
            });
}
