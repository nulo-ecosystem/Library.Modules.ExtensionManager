namespace Nulo.Modules.ExtensionManager {

    internal sealed class InstanceMenuItem {
        public byte Group { get; set; }
        public byte Location { get; set; }
        public string Route { get; set; }

        public MenuItem MenuItem { get; set; }
    }
}