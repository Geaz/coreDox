using coreDox.Core.Project;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;

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
            var doxType = _project.AssemblyList.GetParsedType("T:coreDox.TestProject.CodeIds");

            //Assert
            Assert.IsNotNull(doxType);
        }

        [TestMethod]
        public void ShouldCreateTypeIdWithGenericsSuccessfully()
        {
            //Arrange - Done during TestInitialize

            //Act
            var doxType = _project.AssemblyList.GetParsedType("T:coreDox.TestProject.CodeIds`2");

            //Assert
            Assert.IsNotNull(doxType);
        }

        [TestMethod]
        public void ShouldCreateFieldIdSuccessfully()
        {
            //Arrange
            var doxType = _project.AssemblyList.GetParsedType("T:coreDox.TestProject.CodeIds");

            //Act
            var doxField = doxType.FieldList.First();

            //Assert
            Assert.AreEqual("F:coreDox.TestProject.CodeIds.q", doxField.Id);
        }

        [TestMethod]
        public void ShouldCreateEventIdSuccessfully()
        {
            //Arrange
            var doxType = _project.AssemblyList.GetParsedType("T:coreDox.TestProject.CodeIds");

            //Act
            var doxEvent = doxType.EventList.First();

            //Assert
            Assert.AreEqual("E:coreDox.TestProject.CodeIds.d", doxEvent.Id);
        }

        [TestMethod]
        public void ShouldCreatePropertyIdSuccessfully()
        {
            //Arrange
            var doxType = _project.AssemblyList.GetParsedType("T:coreDox.TestProject.CodeIds");

            //Act
            var doxProperty = doxType.PropertyList.First();

            //Assert
            Assert.AreEqual("P:coreDox.TestProject.CodeIds.prop", doxProperty.Id);
        }

        [TestMethod]
        public void ShouldCreatePropertyIdWithParametersSuccessfully()
        {
            //Arrange
            var doxType = _project.AssemblyList.GetParsedType("T:coreDox.TestProject.CodeIds");

            //Act
            var doxProperty = doxType.PropertyList.Skip(1).First();

            //Assert
            Assert.AreEqual("P:coreDox.TestProject.CodeIds.Item(System.String)", doxProperty.Id);
        }

        [TestMethod]
        public void ShouldCreateConstructorIdSuccessfully()
        {
            //Arrange
            var doxType = _project.AssemblyList.GetParsedType("T:coreDox.TestProject.CodeIds");

            //Act
            var doxmethod = doxType.MethodList
                .SingleOrDefault(m => m.Id == "M:coreDox.TestProject.CodeIds.#ctor");

            //Assert
            Assert.IsNotNull(doxmethod);
        }

        [TestMethod]
        public void ShouldCreateMethodIdWithRefAndPointerSuccessfully()
        {
            //Arrange
            var doxType = _project.AssemblyList.GetParsedType("T:coreDox.TestProject.CodeIds");

            //Act
            var doxmethod = doxType.MethodList
                .SingleOrDefault(m => m.Id == "M:coreDox.TestProject.CodeIds.bb(System.String,System.Int32@,System.Void*)");

            //Assert
            Assert.IsNotNull(doxmethod);
        }

        [TestMethod]
        public void ShouldCreateMethodIdArraysSuccessfully()
        {
            //Arrange
            var doxType = _project.AssemblyList.GetParsedType("T:coreDox.TestProject.CodeIds");

            //Act
            var doxmethod = doxType.MethodList
                .SingleOrDefault(m => m.Id == "M:coreDox.TestProject.CodeIds.gg(System.Int16[],System.Int32[0:,0:])");

            //Assert
            Assert.IsNotNull(doxmethod);
        }
    }
}
