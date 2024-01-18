namespace Nulo.Modules.ExtensionManager {

    internal sealed class MenuItemFull(string route, byte group, byte location, MenuItem menuItem) {

        #region Properties

        public string Route { get; set; } = route;
        public byte Group { get; private set; } = group;
        public byte Location { get; private set; } = location;
        public MenuItem MenuItem { get; private set; } = menuItem;

        #endregion Properties
    }
}