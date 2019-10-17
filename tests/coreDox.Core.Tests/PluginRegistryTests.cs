using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace coreDox.Core.Tests.Projects
{
    [TestClass]
    public class PluginRegistryTests
    {
        [TestMethod]
        public void ShouldFindAllTargetPluginsSuccessfully()
        {
            //Arrange
            var pluginRegistry = new PluginRegistry();

            //Act
            var registeredTargets = pluginRegistry.GetAllTargetPlugins();

            //Assert
            Assert.AreEqual(1, registeredTargets.Count);
        }

        [TestMethod]
        public void ShouldFindAllModelProviderPluginsSuccessfully()
        {
            //Arrange
            var pluginRegistry = new PluginRegistry();

            //Act
            var registeredModelProviders = pluginRegistry.GetAllModelProviders();

            //Assert
            Assert.IsTrue(registeredModelProviders.Count > 0);
        }

        [TestMethod]
        public void ShouldFindAllConfigSectionsSuccessfully()
        {
            //Arrange
            var pluginRegistry = new PluginRegistry();

            //Act
            var registeredConfigSectionList = pluginRegistry.GetAllConfigSections();

            //Assert
            Assert.AreEqual(2, registeredConfigSectionList.Count);
        }
    }
}
