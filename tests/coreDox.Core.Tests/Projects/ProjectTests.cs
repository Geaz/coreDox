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
        private string _tmpProjectPath;
        private string _tmpDocPath;

        [TestInitialize]
        public void TestInitialize()
        {
            _tmpProjectPath = Path.Combine(Path.GetDirectoryName(GetType().Assembly.Location), "[TestProject]");
            _tmpDocPath = Path.Combine(_tmpProjectPath, "doc");
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            if(Directory.Exists(_tmpDocPath)) Directory.Delete(_tmpDocPath, true);
        }

        [TestMethod]
        public void ShouldCreateDefaultProjectSuccessfully()
        {
            //Arrange
            var pluginRegistry = new PluginRegistry();
            var projectConfig = new DoxProjectConfig(pluginRegistry, Path.Combine(_tmpDocPath, DoxProject.ConfigFileName));
            var project = new DoxProject(projectConfig);

            //Act
            project.CreateMissingElements();

            //Assert
            Assert.IsTrue(Directory.Exists(Path.Combine(_tmpDocPath, DoxProject.AssetFolderName)));
            Assert.IsTrue(Directory.Exists(Path.Combine(_tmpDocPath, DoxProject.LayoutFolderName)));
            Assert.IsTrue(Directory.Exists(Path.Combine(_tmpDocPath, DoxProject.PagesFolderName)));
            Assert.IsTrue(File.Exists(Path.Combine(_tmpDocPath, DoxProject.ConfigFileName)));
            Assert.IsTrue(File.Exists(Path.Combine(_tmpDocPath, DoxProject.PagesFolderName, "SharpDox.TestProject.md")));
        }

        [TestMethod]
        public void ShouldReportErrorsOnNotValidProjectSuccessfully()
        {
            //Arrange
            var pluginRegistry = new PluginRegistry();
            var projectConfig = new DoxProjectConfig(pluginRegistry, Path.Combine(_tmpDocPath, DoxProject.ConfigFileName));
            var project = new DoxProject(projectConfig);

            //Act
            var validationResult = project.IsProjectValid();

            //Assert
            Assert.IsTrue(validationResult.All(v => !v.Valid));
        }
    }
}
