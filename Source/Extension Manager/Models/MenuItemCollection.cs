namespace Nulo.Modules.ExtensionManager {

    internal sealed class MenuItemCollection(string route) {

        #region Properties

        public string Route { get; private set; } = route;
        public MenuItem MenuItem { get; set; }
        public BinaryHeap<BinaryHeap<MenuItemCollection>> Groups { get; private set; } = new();

        #endregion Properties

        #region Methods

        public MenuItemCollection FindByRoute(string route) {
            foreach(var group in Groups.GetList()) {
                if(group.Item2.GetList().FirstOrDefault(a => a.Item2.Route.Equals(route)) is Tuple<byte, MenuItemCollection> menuItemCollection) {
                    return menuItemCollection.Item2;
                }
            }
            return null;
        }

        public MenuItemCollection Add(string route, byte group, byte location) {
            var collection = new MenuItemCollection(route);

            if(Groups.Exists(group) is BinaryHeap<MenuItemCollection> collections) {
                collections.Insert(location, collection);
            } else {
                collections = new();
                collections.Insert(location, collection);
                Groups.Insert(group, collections);
            }

            return collection;
        }

        #endregion Methods
    }
}