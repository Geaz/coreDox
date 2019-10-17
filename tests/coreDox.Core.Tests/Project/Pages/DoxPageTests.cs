using coreDox.Core.Exceptions;
using coreDox.Core.Project;
using coreDox.Core.Project.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;

namespace coreDox.Core.Tests.Projects.Pages
{
    [TestClass]
    public class DoxPageTests
    {
        private string _tmpFile = Path.GetTempFileName();
        private string _tmpPath = Path.Combine(Path.GetTempPath(), "testProject");
        private readonly string _testProjectPath =
           Path.Combine(Path.GetDirectoryName(
               typeof(DoxPageTests).Assembly.Location),
               "..", "..", "..", "..", "..", "doc", "testDoc");

        [TestCleanup]
        public void TestCleanUp()
        {
            if (File.Exists(_tmpFile)) File.Delete(_tmpFile);
            if (Directory.Exists(_tmpPath)) Directory.Delete(_tmpPath, true);
        }

        [TestMethod]
        public void ShouldParsePagesSuccessfully()
        {
            //Arrange
            var project = new DoxProject();

            //Act
            project.Load(_testProjectPath);

            //Assert
            Assert.AreEqual(1, project.PageRoot.PageList.Count);
            Assert.AreEqual(2, project.PageRoot.FolderList.Count);
            Assert.AreEqual("Test Documentation", project.PageRoot.Title);
            Assert.IsNotNull(project.PageRoot.PageList.First().AssemblyFileInfo);
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
