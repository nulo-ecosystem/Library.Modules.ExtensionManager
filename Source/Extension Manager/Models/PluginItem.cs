namespace Nulo.Modules.ExtensionManager {

    public sealed class PluginItem(string productName, Assembly assembly) {

        #region Properties

        public string ProductName { get; private set; } = productName.Replace(" ®", "®");
        public Assembly Assembly { get; private set; } = assembly;

        #endregion Properties
    }
}