using Nuke.Common;
using Nuke.Common.CI;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.IO.PathConstruction;
using static Nuke.Common.Tools.DotNet.DotNetTasks;

[ShutdownDotNetAfterServerBuild]
class Build : NukeBuild
{
    public static int Main() => Execute<Build>(x => x.Pack);

    private const string CoreProjectName = "DarkMusicConcepts";
    private const string UnitsProjectName = "DarkMusicConcepts.Units";
    private const string TestProjectName = "DarkMusicConcepts.Tests";

    [Solution] readonly Solution Solution;

    AbsolutePath SourceDirectory => RootDirectory / "src";
    AbsolutePath ArtifactsDirectory => RootDirectory / "artifacts";

    readonly Configuration Configuration = Configuration.Release;

    Target Clean => _ => _
        .Before(RestoreCore)
        .Before(RestoreUnits)
        .Executes(() =>
        {
            SourceDirectory.GlobDirectories("**/bin", "**/obj").ForEach(DeleteDirectory);
        });

    Target RestoreCore => _ => _
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
              .EnableNoBuild()
              .EnableNoRestore()
              .SetOutputDirectory(ArtifactsDirectory));
        });

    Target Pack => _ => _
        .DependsOn(PackCore)
        .DependsOn(PackUnits);
}
