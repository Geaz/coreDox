using coreDox.Core.CodeModel;
using coreDox.Core.CodeModel.Members;
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
            var doxType = _project.AssemblyList.GetById<DoxType>("T:coreDox.TestProject.CodeIds");

            //Assert
            Assert.IsNotNull(doxType);
        }

        [TestMethod]
        public void ShouldCreateTypeIdWithGenericsSuccessfully()
        {
            //Arrange - Done during TestInitialize

            //Act
            var doxType = _project.AssemblyList.GetById<DoxType>("T:coreDox.TestProject.CodeIds`2");

            //Assert
            Assert.IsNotNull(doxType);
        }

        [TestMethod]
        public void ShouldCreateFieldIdSuccessfully()
        {
            //Arrange - Done during TestInitialize

            //Act
            var doxField = _project.AssemblyList.GetById<DoxField>("F:coreDox.TestProject.CodeIds.q");

            //Assert
            Assert.IsNotNull(doxField);
        }

        [TestMethod]
        public void ShouldCreateEventIdSuccessfully()
        {
            //Arrange - Done during TestInitialize

            //Act
            var doxEvent = _project.AssemblyList.GetById<DoxEvent>("E:coreDox.TestProject.CodeIds.d");

            //Assert
            Assert.IsNotNull(doxEvent);
        }

        [TestMethod]
        public void ShouldCreatePropertyIdSuccessfully()
        {
            //Arrange - Done during TestInitialize

            //Act
            var doxProperty = _project.AssemblyList.GetById<DoxProperty>("P:coreDox.TestProject.CodeIds.prop");

            //Assert
            Assert.IsNotNull(doxProperty);
        }

        [TestMethod]
        public void ShouldCreatePropertyIdWithParametersSuccessfully()
        {
            //Arrange - Done during TestInitialize

            //Act
            var doxProperty = _project.AssemblyList.GetById<DoxProperty>("P:coreDox.TestProject.CodeIds.Item(System.String)");

            //Assert
            Assert.IsNotNull(doxProperty);
        }

        [TestMethod]
        public void ShouldCreateConstructorIdSuccessfully()
        {
            //Arrange - Done during TestInitialize

            //Act
            var doxmethod = _project.AssemblyList.GetById<DoxMethod>("M:coreDox.TestProject.CodeIds.#ctor");

            //Assert
            Assert.IsNotNull(doxmethod);
        }

        [TestMethod]
        public void ShouldCreateMethodIdWithRefAndPointerSuccessfully()
        {
            //Arrange - Done during TestInitialize

            //Act
            var doxmethod = _project.AssemblyList.GetById<DoxMethod>("M:coreDox.TestProject.CodeIds.bb(System.String,System.Int32@,System.Void*)");

            //Assert
            Assert.IsNotNull(doxmethod);
        }

        [TestMethod]
        public void ShouldCreateMethodIdArraysSuccessfully()
        {
            //Arrange - Done during TestInitialize

            //Act
            var doxmethod = _project.AssemblyList.GetById<DoxMethod>("M:coreDox.TestProject.CodeIds.gg(System.Int16[],System.Int32[0:,0:])");

            //Assert
            Assert.IsNotNull(doxmethod);
        }
    }
}
