namespace Nulo.Modules.ExtensionManager {

    public interface IExtensionData {

        IEnumerable<Type> GetLocalItems();

        IEnumerable<PluginItem> GetPluginItems();
    }
}