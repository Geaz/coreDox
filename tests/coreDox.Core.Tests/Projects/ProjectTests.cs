using coreDox.Core.Configuration;
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
            Directory.Delete(_tmpPath, true);
        }

        [TestMethod]
        public void ShouldCreateNewDefaultProjectOnLoadSuccessfully()
        {
            //Arrange
            var project = new Project(_tmpPath, new ProjectConfig());

            //Act
            var loadResult = project.Load(true);

            //Assert
            Assert.IsTrue(loadResult.AllSucceeded());

            Assert.IsTrue(Directory.Exists(Path.Combine(_tmpPath, Project.AssetFolderName)));
            Assert.IsTrue(Directory.Exists(Path.Combine(_tmpPath, Project.LayoutFolderName)));
            Assert.IsTrue(Directory.Exists(Path.Combine(_tmpPath, Project.PagesFolderName)));
           // Assert.IsTrue(File.Exists(Path.Combine(_tmpPath, Project.ConfigFileName)));
        }
    }
}
