using coreDox.Core.Exceptions;
using coreDox.Core.Project.Config;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace coreDox.Core.Tests.Projects
{
    [TestClass]
    public class ProjectConfigTests
    {
        private string _tmpPath = Path.Combine(Path.GetTempPath(), "testProject");

        [TestCleanup]
        public void TestCleanUp()
        {
            if(Directory.Exists(_tmpPath)) Directory.Delete(_tmpPath, true);
        }

        [TestMethod]
        public void ShouldCreateDefaultConfigSuccessfully()
        {
            //Arrange
            Directory.CreateDirectory(_tmpPath);
            var projectConfig = new DoxProjectConfig();

            //Act
            projectConfig.Save(_tmpPath);

            //Assert
            Assert.IsTrue(File.Exists(Path.Combine(_tmpPath, DoxProjectConfig.ConfigFileName)));
        }

        [TestMethod]
        public void ShouldGetDoxConfigSuccessfully()
        {
            //Arrange
            Directory.CreateDirectory(_tmpPath);
            var projectConfig = new DoxProjectConfig();

            //Act
            var doxConfig = projectConfig.GetConfigSection<DoxConfigSection>();

            //Assert
            Assert.IsNotNull(doxConfig);
        }

        [TestMethod]
        public void ShouldSetDefaultConfigValuesSuccessfully()
        {
            //Arrange
            Directory.CreateDirectory(_tmpPath);
            var projectConfig = new DoxProjectConfig();

            //Act
            var doxConfig = projectConfig.GetConfigSection<DoxConfigSection>();

            //Assert
            Assert.AreEqual("build", doxConfig.OutputFolder);
            Assert.AreEqual("Doc Project", doxConfig.ProjectName);
        }

        [TestMethod]
        [ExpectedException(typeof(CoreDoxException))]
        public void ShouldThrowIfConfigFileNotPresent()
        {
            //Arrange
            var projectConfig = new DoxProjectConfig();

            //Act
            projectConfig.Load(_tmpPath);

            //Assert - Expects Exception
        }
    }
}
