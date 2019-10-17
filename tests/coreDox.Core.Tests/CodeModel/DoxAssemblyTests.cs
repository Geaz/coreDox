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
        private readonly string _testProjectPath =
            Path.Combine(Path.GetDirectoryName(
                typeof(DoxAssemblyTests).Assembly.Location),
                "..", "..", "..", "..", "..", "doc", "testDoc");
        
        [TestMethod]
        public void ShouldParseAssemblySuccessfully()
        {
            //Arrange
            var project = new DoxProject();
            project.Load(_testProjectPath);

            //Act
            project.ParseAssemblies();

            //Assert
            Assert.IsTrue(project.ParsedAssemblyList.First().DoxNamespaceSet.Count > 0);
        }
    }
}
