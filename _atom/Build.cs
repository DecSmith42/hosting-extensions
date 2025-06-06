﻿namespace Atom;

[BuildDefinition]
[GenerateEntryPoint]
internal sealed partial class Build : DefaultBuildDefinition, IGitVersion, IGithubWorkflows, ITargets
{
    public override IReadOnlyList<IWorkflowOption> GlobalWorkflowOptions =>
    [
        UseGitVersionForBuildId.Enabled, new SetupDotnetStep("9.0.x"),
    ];

    public override IReadOnlyList<WorkflowDefinition> Workflows =>
    [
        new("Validate")
        {
            Triggers = [GitPullRequestTrigger.IntoMain, ManualTrigger.Empty],
            Targets =
            [
                Targets.SetupBuildInfo, Targets.PackHostingExtensions.WithSuppressedArtifactPublishing, Targets.TestHostingExtensions,
            ],
            WorkflowTypes = [Github.WorkflowType],
        },
        new("Build")
        {
            Triggers = [GitPushTrigger.ToMain, GithubReleaseTrigger.OnReleased, ManualTrigger.Empty],
            Targets =
            [
                Targets.SetupBuildInfo,
                Targets.PackHostingExtensions,
                Targets.TestHostingExtensions,
                Targets.PushToNuget.WithOptions(WorkflowSecretInjection.Create(Params.NugetApiKey)),
                Targets
                    .PushToRelease
                    .WithGithubTokenInjection()
                    .WithOptions(GithubIf.Create(new ConsumedVariableExpression(nameof(Targets.SetupBuildInfo),
                            ParamDefinitions[nameof(ISetupBuildInfo.BuildVersion)].ArgName)
                        .Contains(new StringExpression("-"))
                        .EqualTo("false"))),
            ],
            WorkflowTypes = [Github.WorkflowType],
        },
        Github.DependabotDefaultWorkflow(),
    ];
}
