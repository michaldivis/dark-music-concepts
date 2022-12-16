using Nuke.Common;
using Nuke.Common.CI;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Utilities.Collections;
using System.Linq;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.IO.PathConstruction;
using static Nuke.Common.Tools.DotNet.DotNetTasks;

[ShutdownDotNetAfterServerBuild]
class Build : NukeBuild
{
    public static int Main() => Execute<Build>(x => x.PushNuget);

    private const string Version = "0.9.0-pre015";

    private const string CoreProjectName = "DarkMusicConcepts";
    private const string UnitsProjectName = "DarkMusicConcepts.Units";
    private const string TestProjectName = "DarkMusicConcepts.Tests";

    [Solution] readonly Solution Solution;

    AbsolutePath SourceDirectory => RootDirectory / "src";
    AbsolutePath ArtifactsDirectory => RootDirectory / "artifacts";

    readonly Configuration Configuration = Configuration.Release;

    [Parameter] readonly string NugetApiUrl = "https://api.nuget.org/v3/index.json";
    [Parameter] readonly string NugetApiKey;

    Target Clean => _ => _
        .Executes(() =>
        {
            SourceDirectory.GlobDirectories("**/bin", "**/obj").ForEach(DeleteDirectory);
            EnsureCleanDirectory(ArtifactsDirectory);
        });

    Target RestoreCore => _ => _
        .DependsOn(Clean)
        .Executes(() =>
        {
            DotNetRestore(s => s
                .SetProjectFile(Solution.GetProject(CoreProjectName)));
        });

    Target CompileCore => _ => _
        .DependsOn(RestoreCore)
        .Executes(() =>
        {
            DotNetBuild(s => s
                .SetProjectFile(Solution.GetProject(CoreProjectName))
                .SetConfiguration(Configuration)
                .EnableNoRestore());
        });

    Target CompileTests => _ => _
        .DependsOn(CompileCore)
        .DependsOn(CompileUnits)
        .Executes(() =>
        {
            DotNetBuild(s => s
                .SetProjectFile(Solution.GetProject(TestProjectName))
                .SetConfiguration(Configuration)
                .EnableNoRestore());
        });

    Target RunTests => _ => _
        .DependsOn(CompileTests)
        .Executes(() =>
        {
            DotNetTest(s => s
                .SetProjectFile(Solution.GetProject(TestProjectName))
                .SetConfiguration(Configuration)
                .EnableNoRestore()
                .EnableNoBuild());
        });


    Target PackCore => _ => _
        .DependsOn(RunTests)
        .Executes(() =>
        {
            DotNetPack(s => s
              .SetProject(Solution.GetProject(CoreProjectName))
              .SetConfiguration(Configuration)
              .SetVersion(Version)
              .EnableNoBuild()
              .EnableNoRestore()
              .SetOutputDirectory(ArtifactsDirectory));
        });

    Target RestoreUnits => _ => _
        .Executes(() =>
        {
            DotNetRestore(s => s
                .SetProjectFile(Solution.GetProject(UnitsProjectName)));
        });

    Target CompileUnits => _ => _
        .DependsOn(RestoreUnits)
        .Executes(() =>
        {
            DotNetBuild(s => s
                .SetProjectFile(Solution.GetProject(UnitsProjectName))
                .SetConfiguration(Configuration)
                .EnableNoRestore());
        });

    Target PackUnits => _ => _
        .DependsOn(RunTests)
        .Executes(() =>
        {
            DotNetPack(s => s
              .SetProject(Solution.GetProject(UnitsProjectName))
              .SetConfiguration(Configuration)
              .SetVersion(Version)
              .EnableNoBuild()
              .EnableNoRestore()
              .SetOutputDirectory(ArtifactsDirectory));
        });

    Target Pack => _ => _
        .DependsOn(PackCore)
        .DependsOn(PackUnits);

    Target PushNuget => _ => _
        .DependsOn(Pack)
        .Requires(() => NugetApiUrl)
        .Requires(() => NugetApiKey)
        .Executes(() =>
        {
            GlobFiles(ArtifactsDirectory, "*.nupkg")
               .Where(x => !string.IsNullOrEmpty(x) && !x.EndsWith("symbols.nupkg"))
               .ForEach(x =>
               {
                   DotNetNuGetPush(s => s
                       .SetTargetPath(x)
                       .SetSource(NugetApiUrl)
                       .SetApiKey(NugetApiKey)
                   );
               });
        });
}
