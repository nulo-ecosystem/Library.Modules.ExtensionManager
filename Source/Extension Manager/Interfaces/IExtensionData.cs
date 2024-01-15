namespace Nulo.Modules.ExtensionManager {

    public interface IExtensionData {

        IEnumerable<Type> GetLocalMenuItems();

        IEnumerable<PluginItem> GetPluginMenuItems();
    }
}