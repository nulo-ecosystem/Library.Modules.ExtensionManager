namespace Nulo.Modules.ExtensionManager {

    public sealed class PluginItem(string productName, Assembly assembly) {
        public string ProductName { get; private set; } = productName.Replace(" ®", "®");
        public Assembly Assembly { get; private set; } = assembly;
    }
}