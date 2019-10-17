using coreDox.Core.Exceptions;
using coreDox.Core.Project.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace coreDox.Core.Tests.Projects.Pages
{
    [TestClass]
    public class DoxPageTests
    {
        private string _tmpFile = Path.GetTempFileName();
        private string _tmpPath = Path.Combine(Path.GetTempPath(), "testProject");
        private string _testDllPath = 
            Path.Combine(Path.GetDirectoryName(
                typeof(DoxPageTests).Assembly.Location), 
                "coreDox.TestDataProject.dll");

        [TestCleanup]
        public void TestCleanUp()
        {
            if (File.Exists(_tmpFile)) File.Delete(_tmpFile);
            if (Directory.Exists(_tmpPath)) Directory.Delete(_tmpPath, true);
        }

        [TestMethod]
        public void ShouldParsePageSuccessfully()
        {
            //Arrange
            PageHelper.WritePage(_tmpFile, "API", string.Empty, _testDllPath);
            var assemblyPage = new DoxPage(new FileInfo(_tmpFile));

            //Act - Is Done During Assert

            //Assert
            Assert.AreEqual("API", assemblyPage.Title);
            Assert.AreEqual(_testDllPath, assemblyPage.AssemblyFileInfo.FullName);
            Assert.AreEqual(string.Empty, assemblyPage.Content);
        }

        [TestMethod]
        [ExpectedException(typeof(CoreDoxException))]
        public void ShouldThrowIfAssemblyFileNotPresent()
        {
            //Arrange
            PageHelper.WritePage(_tmpFile, "API", string.Empty, "notpresent.dll");

            //Act
            var assemblyPage = new DoxPage(new FileInfo(_tmpFile));

            //Assert - Expects Exception
        }
    }
}
