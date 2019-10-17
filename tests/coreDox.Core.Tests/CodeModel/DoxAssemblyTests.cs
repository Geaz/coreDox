using coreDox.Core.Model.Code;
using coreDox.Core.Project;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;

namespace coreDox.Core.Tests.CodeModel
{
    [TestClass]
    public class DoxAssemblyTests
    {
        private readonly string _tmpFile = Path.GetTempFileName();
        private readonly string _testProjectPath =
            Path.Combine(Path.GetDirectoryName(
                typeof(DoxAssemblyTests).Assembly.Location),
                "..", "..", "..", "..", "..", "doc", "testDoc");

        [TestCleanup]
        public void TestCleanUp()
        {
            if (File.Exists(_tmpFile)) File.Delete(_tmpFile);
        }

        [TestMethod]
        public void ShouldOpenAssemblySuccessfully()
        {
            //Arrange
            var project = new DoxProject();
            project.Load(_testProjectPath);

            var assemblyPage = project.PageRoot.GetAllAssemblyPages().First();

            //Act
            var doxAssembly = new DoxAssembly(assemblyPage.AssemblyFileInfo.FullName);

            //Assert
            Assert.IsTrue(doxAssembly.DoxNamespaceSet.Count > 0);
        }
    }
}
