using coreDox.Core.Project;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace coreDox.Core.Tests.CodeModel
{
    [TestClass]
    public class DoxCodeIdTests
    {
        private DoxProject _project;

        private readonly string _testProjectPath =
               Path.Combine(Path.GetDirectoryName(
                   typeof(DoxAssemblyTests).Assembly.Location),
                   "..", "..", "..", "..", "..", "doc", "testDoc");

        [TestInitialize]
        public void TestInit()
        {
            _project = new DoxProject();
            _project.Load(_testProjectPath);
        }

        [TestMethod]
        public void ShouldCreateTypeIdSuccessfully()
        {
            //Arrange - Done during TestInitialize

            //Act
            var testCodeIdType = _project.AssemblyList.GetParsedType("T:coreDox.TestProject.CodeIds");

            //Assert
            Assert.IsNotNull(testCodeIdType);
        }

        [TestMethod]
        public void ShouldCreateTypeIdWithGenericsSuccessfully()
        {
            //Arrange - Done during TestInitialize

            //Act
            var testCodeIdType = _project.AssemblyList.GetParsedType("T:coreDox.TestProject.CodeIds`2");

            //Assert
            Assert.IsNotNull(testCodeIdType);
        }        
    }
}
