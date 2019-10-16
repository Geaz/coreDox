#addin nuget:?package=Cake.Coverlet

//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

var buildDir = Directory("./src/coreDox/bin") + Directory(configuration);
//var distDir = Directory("./dist");

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
	.Does(() => {
		CleanDirectory(buildDir);
		//CleanDirectory(distDir);
	});

Task("Restore-NuGet-Packages")
	.IsDependentOn("Clean")
	.Does(() => {
		DotNetCoreRestore("./src/coreDox.sln");
	});

Task("Build")
    .IsDependentOn("Restore-NuGet-Packages")
    .Does(() => {
        DotNetCoreBuild("./src/coreDox.sln",
            new DotNetCoreBuildSettings()
            {
                Configuration = configuration,
            });
	});

Task("Run-Unit-Tests")
    .IsDependentOn("Build")
    .Does(() => {
        var coverletSettings = new CoverletSettings {
            CollectCoverage = true,
            CoverletOutputFormat = CoverletOutputFormat.opencover,
            Exclude = new List<string> { "[coreDox]*", "[coreDox.TestDataProject]*" },
        };
        
        DotNetCoreTest(
            "./tests/coreDox.Core.Tests/coreDox.Core.Tests.csproj",
            new DotNetCoreTestSettings()
            {
                Configuration = configuration,
                NoBuild = true,
            }, coverletSettings);
	});

//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default").IsDependentOn("Run-Unit-Tests");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);
