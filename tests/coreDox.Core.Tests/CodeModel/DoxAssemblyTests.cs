using coreDox.Core.CodeModel;
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
            project.AssemblyList.AmendModels();

            //Assert
            Assert.IsTrue(project.AssemblyList.First().NamespaceList.Count > 0);
        }

        [TestMethod]
        public void ShouldGetTypeSuccessfully()
        {
            //Arrange
            var project = new DoxProject();
            project.Load(_testProjectPath);
            project.AssemblyList.AmendModels();

            //Act
            var doxType = project.AssemblyList.GetById<DoxType>("T:coreDox.TestProject.SeeAlsoDocType`1");

            //Assert
            Assert.IsNotNull(doxType);
        }
    }
}
