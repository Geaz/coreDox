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
    }
}
