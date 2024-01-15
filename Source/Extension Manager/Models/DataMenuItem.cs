namespace Nulo.Modules.ExtensionManager {

    internal sealed class DataMenuItem {
        public MenuItem MenuItem { get; set; }

        public string Route { get; set; }
        public byte Group { get; set; }
        public byte Location { get; set; }

        public List<SubMenuItem> SubMenuItems { get; private set; } = [];
    }
}