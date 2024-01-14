namespace Nulo.Modules.ExtensionManager {

    public interface IExtensionData {

        IEnumerable<Type> GetLocalMenuItems();

        List<PluginItem> GetPluginItems();

        IEnumerable<Type> GetPluginsMenuItems(PluginItem pluginItem);
    }
}