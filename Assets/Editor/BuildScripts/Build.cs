using UnityEngine;
using UnityEditor;
using UnityEditor.Build.Reporting;

public static class Build
{
    public const string BUILD_NAME = "Test";

    [MenuItem("Build/Build Windows")]
    public static void BuildWindows() {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] { "Assets/Scenes/Main.unity" };
        buildPlayerOptions.locationPathName = "Builds/Windows/" + BUILD_NAME + ".exe";
        buildPlayerOptions.target = BuildTarget.StandaloneWindows;
        buildPlayerOptions.options = BuildOptions.None;

        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        BuildSummary summary = report.summary;


        switch (summary.result) {
            case BuildResult.Succeeded:
                Debug.Log("Build succeeded: " + summary.totalSize + " bytes");
                break;
            case BuildResult.Failed:
                Debug.Log("Build failed");
                break;
        }
    }
}
