using coreDox.Core.Project.Common;
using coreDox.Core.Project.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace coreDox.Core.Tests.Projects.Pages
{
    [TestClass]
    public class DoxPageTests
    {
        private string _tmpFile = Path.GetTempFileName();

        [TestCleanup]
        public void TestCleanUp()
        {
            if(File.Exists(_tmpFile)) File.Delete(_tmpFile);
        }

        [TestMethod]
        public void ShouldCreateDoxPageSuccessfully()
        {
            //Arrange
            var doxPage = new DoxPage(new DoxFileInfo(_tmpFile));

            //Act
            doxPage.WritePage("Test Title", "Test Content", "C:\\TestPath\\test.csproj");

            //Assert
            Assert.IsTrue(File.Exists(_tmpFile));
        }

        [TestMethod]
        public void ShouldParsePageSuccessfully()
        {
            //Arrange
            var doxPage = new DoxPage(new DoxFileInfo(_tmpFile));
            doxPage.WritePage("Test Title", "Test Content", "C:\\TestPath\\test.csproj");

            //Act - Is Done During Assert

            //Assert
            Assert.AreEqual("Test Title", doxPage.Title);
            Assert.AreEqual("Test Content", doxPage.Content);
            Assert.AreEqual("C:\\TestPath\\test.csproj", doxPage.CodeProjectPath);
            Assert.AreEqual(DoxPageType.Code, doxPage.PageType);
        }
    }
}
