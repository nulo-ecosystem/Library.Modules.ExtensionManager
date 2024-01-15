namespace Nulo.Modules.ExtensionManager {

    internal sealed class SubMenuItem {
        public byte Group { get; set; }
        public List<DataMenuItem> Items { get; set; } = [];
    }
}