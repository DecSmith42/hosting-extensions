namespace Atom;

[BuildDefinition]
[GenerateEntryPoint]
internal sealed partial class Build : DefaultBuildDefinition,
    IGitVersion,
    IGithubWorkflows,
    IPackHostingExtensions,
    ITestHostingExtensions,
    IPushToNuget
{
    public override IReadOnlyList<IWorkflowOption>
        DefaultWorkflowOptions => [UseGitVersionForBuildId.Enabled, new SetupDotnetStep("9.0.x")];

    public override IReadOnlyList<WorkflowDefinition> Workflows =>
    [
        new("Validate")
        {
            Triggers = [GitPullRequestTrigger.IntoMain, ManualTrigger.Empty],
            StepDefinitions =
            [
                Commands.SetupBuildInfo,
                Commands.PackHostingExtensions.WithSuppressedArtifactPublishing,
                Commands.TestHostingExtensions,
            ],
            WorkflowTypes = [Github.WorkflowType],
        },
        new("Build")
        {
            Triggers = [GitPushTrigger.ToMain, GithubReleaseTrigger.OnReleased, ManualTrigger.Empty],
            StepDefinitions =
            [
                Commands.SetupBuildInfo,
                Commands.PackHostingExtensions,
                Commands.TestHostingExtensions,
                Commands.PushToNuget.WithAddedOptions(WorkflowSecretInjection.Create(Params.NugetApiKey)),
            ],
            WorkflowTypes = [Github.WorkflowType],
        },
        Github.DependabotDefaultWorkflow(),
    ];
}
