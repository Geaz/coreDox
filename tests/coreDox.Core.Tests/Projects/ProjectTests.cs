using coreDox.Core.Project;
using coreDox.Core.Project.Config;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;

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
            var pluginRegistry = new PluginRegistry();
            var projectConfig = new DoxProjectConfig(pluginRegistry, Path.Combine(_tmpPath, DoxProject.ConfigFileName));
            var project = new DoxProject(projectConfig);

            //Act
            project.CreateMissingElements();

            //Assert
            Assert.IsTrue(Directory.Exists(Path.Combine(_tmpPath, DoxProject.AssetFolderName)));
            Assert.IsTrue(Directory.Exists(Path.Combine(_tmpPath, DoxProject.LayoutFolderName)));
            Assert.IsTrue(Directory.Exists(Path.Combine(_tmpPath, DoxProject.PagesFolderName)));
            Assert.IsTrue(File.Exists(Path.Combine(_tmpPath, DoxProject.ConfigFileName)));
        }

        [TestMethod]
        public void ShouldReportErrorsOnNotValidProjectSuccessfully()
        {
            //Arrange
            var pluginRegistry = new PluginRegistry();
            var projectConfig = new DoxProjectConfig(pluginRegistry, Path.Combine(_tmpPath, DoxProject.ConfigFileName));
            var project = new DoxProject(projectConfig);

            //Act
            var validationResult = project.IsProjectValid();

            //Assert
            Assert.IsTrue(validationResult.All(v => !v.Valid));
        }
    }
}
