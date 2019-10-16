using coreDox.Core.Project;
using coreDox.Core.Project.Config;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace coreDox.Core.Tests.Projects
{
    [TestClass]
    public class ProjectTests
    {
        private string _tmpPath = Path.Combine(Path.GetTempPath(), "testProject");

        [TestCleanup]
        public void TestCleanUp()
        {
            if(Directory.Exists(_tmpPath)) Directory.Delete(_tmpPath, true);
        }

        [TestMethod]
        public void ShouldCreateDefaultProjectSuccessfully()
        {
            //Arrange
            var project = new DoxProject();

            //Act
            project.Create(_tmpPath);

            //Assert
            Assert.IsTrue(Directory.Exists(Path.Combine(_tmpPath, DoxProject.AssetFolderName)));
            Assert.IsTrue(Directory.Exists(Path.Combine(_tmpPath, DoxProject.LayoutFolderName)));
            Assert.IsTrue(Directory.Exists(Path.Combine(_tmpPath, DoxProject.PagesFolderName)));
            Assert.IsTrue(File.Exists(Path.Combine(_tmpPath, DoxProjectConfig.ConfigFileName)));
        }

        [TestMethod]
        public void ShouldLoadProjectSuccessfully()
        {
            //Arrange
            var project = new DoxProject();
            var projectPath = Path.Combine(
                Path.GetDirectoryName(typeof(ProjectTests).Assembly.Location),
                "..", "..", "..", "..", "..", "doc", "testDoc");

            //Act
            project.Load(projectPath);

            //Assert
            Assert.IsTrue(project.RootProjectDirectory.Exists);
        }
    }
}
