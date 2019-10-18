using coreDox.Core.Project;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;

namespace coreDox.Core.Tests
{
    [TestClass]
    public class DoxTemplateBuilderTests
    {
        private readonly string _testProjectPath =
            Path.Combine(Path.GetDirectoryName(
                typeof(DoxTemplateBuilderTests).Assembly.Location),
                "..", "..", "..", "..", "..", "doc", "testDoc");

        [TestMethod]
        public void ShouldExecuteModelProviderTagSuccessfully()
        {
            //Arrange
            var project = new DoxProject();
            project.Load(_testProjectPath);
            project.ParseAssemblies();

            var templateBuilder = new DoxTemplateBuilder();

            //Act
            var doxType = project.ParsedAssemblyList.First().DoxNamespaceSet.First().DoxTypeSet.First();
            var renderedText = templateBuilder.Render("{{data.Models.SyntaxModel.Syntax }}", doxType);

            //Assert
            Assert.AreEqual("**test**", renderedText);
        }

        [TestMethod]
        public void ShouldBeEmptyIfModelProviderNotFound()
        {
            //Arrange
            var project = new DoxProject();
            project.Load(_testProjectPath);
            project.ParseAssemblies();

            var templateBuilder = new DoxTemplateBuilder();

            //Act
            var renderedText = templateBuilder.Render("{{data.Models.SyntaxModel.Syntax}}", project.ParsedAssemblyList.First());

            //Assert
            Assert.AreEqual(string.Empty, renderedText);
        }
    }
}
