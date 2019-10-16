using coreDox.Core.Model.Code;
using coreDox.Core.Project.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace coreDox.Core.Tests.CodeModel
{
    [TestClass]
    public class DoxAssemblyTests
    {
        private readonly string _tmpFile = Path.GetTempFileName();
        private readonly string _testDllPath =
            Path.Combine(Path.GetDirectoryName(
                typeof(DoxAssemblyTests).Assembly.Location),
                "coreDox.TestDataProject.dll");

        [TestCleanup]
        public void TestCleanUp()
        {
            if (File.Exists(_tmpFile)) File.Delete(_tmpFile);
        }

        [TestMethod]
        public void ShouldOpenAssemblySuccessfully()
        {
            //Arrange
            PageHelper.WritePage(_tmpFile, "API", string.Empty, _testDllPath);
            var assemblyPage = new DoxPage(new FileInfo(_tmpFile));

            //Act
            var doxAssembly = new DoxAssembly(assemblyPage.AssemblyFileInfo.FullName);

            //Assert
            Assert.IsTrue(doxAssembly.DoxNamespaceSet.Count > 0);
        }
    }
}
