using Microsoft.VisualStudio.TestTools.UnitTesting;
using coreDox.Core.Services;
using System.IO;
using coreDox.Core.Model.Project;

namespace coreDox.Core.Tests
{
    [TestClass]
    public class ConfigServiceTests
    {
        private string _tmpFile = Path.GetTempFileName();
        private string _testConfig = 
        @"{
            'doxConfig': {
                'projectName':'Test Project'
            },
            'htmlConfig': {
                'showCode':false
            }
        }";

        [TestInitialize]
        public void TestInit()
        {
            File.WriteAllText(_tmpFile, _testConfig);
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            File.Delete(_tmpFile);
        }

        [TestMethod]
        public void ShouldGetDoxConfigSuccessfully()
        {
            //Arrange     
            var configService = ServiceLocator.GetService<ConfigService>();
            configService.LoadConfig(_tmpFile);

            //Act
            var doxConfig = configService.GetConfig<DoxConfig>();

            //Assert
            Assert.IsNotNull(doxConfig);
            Assert.AreEqual("Test Project", doxConfig.ProjectName);
        }
    }
}
