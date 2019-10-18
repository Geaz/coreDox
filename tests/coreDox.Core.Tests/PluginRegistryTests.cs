using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace coreDox.Core.Tests
{
    [TestClass]
    public class PluginRegistryTests
    {
        [TestMethod]
        public void ShouldFindAllTargetPluginsSuccessfully()
        {
            //Arrange
            var pluginRegistry = PluginRegistry.Instance();

            //Act
            var registeredTargets = pluginRegistry.GetAllTargetPlugins();

            //Assert
            Assert.AreEqual(1, registeredTargets.Count);
        }

        [TestMethod]
        public void ShouldFindAllModelProviderPluginsSuccessfully()
        {
            //Arrange
            var pluginRegistry = PluginRegistry.Instance();

            //Act
            var registeredModelProviders = pluginRegistry.GetAllModelProviders();

            //Assert
            Assert.IsTrue(registeredModelProviders.Count > 0);
        }

        [TestMethod]
        public void ShouldFindAllModelsSuccessfully()
        {
            //Arrange
            var pluginRegistry = PluginRegistry.Instance();

            //Act
            var registeredModels = pluginRegistry.GetAllModelTypes();

            //Assert
            Assert.AreEqual(1, registeredModels.Count);
        }

        [TestMethod]
        public void ShouldFindAllConfigSectionsSuccessfully()
        {
            //Arrange
            var pluginRegistry = PluginRegistry.Instance();

            //Act
            var registeredConfigSectionList = pluginRegistry.GetAllConfigSections();

            //Assert
            Assert.AreEqual(2, registeredConfigSectionList.Count);
        }
    }
}
