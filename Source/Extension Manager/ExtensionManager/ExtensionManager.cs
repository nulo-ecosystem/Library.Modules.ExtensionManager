namespace Nulo.Modules.ExtensionManager {

    public sealed class ExtensionManager<ExtensionData, DefaultMenuItem> where ExtensionData : IExtensionData where DefaultMenuItem : MenuItem {
        private readonly IExtensionData extensionData;

        private ToolStripItem[] menuItems;
        private MenuItemCollection menuCollection;
        private string defaultMenuRoute;

        public ExtensionManager() {
            extensionData = Activator.CreateInstance<ExtensionData>();
        }

        #region Public Methods

        public void LoadLocaltems() {
            menuCollection = new(null);

            var menuItem = GetMenuItemFull(typeof(DefaultMenuItem));
            defaultMenuRoute = menuItem.Route;
            InsertMenuItem(menuCollection, menuItem);

            LoadItems(extensionData.GetLocalItems());
        }

        public IEnumerable<PluginItem> LoadPluginItems() {
            return extensionData.GetPluginItems();
        }

        public void LoadPluginItem(PluginItem pluginItem) {
            LoadItems(pluginItem.Assembly.GetTypes());
        }

        public ToolStripItem[] MenuItemRender() {
            var items = MenuItemRender(menuCollection);
            if(MenuItemExists(items, defaultMenuRoute) is ToolStripMenuItem toolStripMenu && toolStripMenu.DropDownItems.Count == 0) { items.Remove(toolStripMenu); }
            menuItems = [.. items];

            defaultMenuRoute = null;
            menuCollection = null;

            return menuItems;
        }

        public ToolStripMenuItem GetMenuItem(string route) {
            return GetMenuItem(menuItems, route);
        }

        public void TextsUpdate() {
            TextsUpdate(menuItems);
        }

        #endregion Public Methods

        #region Private Methods

        private MenuItemFull GetMenuItemFull(Type type) {
            byte group = 0, location = 0;
            string route = null;
            var menuItem = (MenuItem)Activator.CreateInstance(type);
            Keys keys = Keys.None;

            if(type.CustomAttributes.Any()) {
                if(type.GetCustomAttributes(typeof(Group), true) is object[] groups && groups.Length != 0) {
                    group = ((Group)groups[0]).Value;
                }
                if(type.GetCustomAttributes(typeof(Location), true) is object[] locations && locations.Length != 0) {
                    location = ((Location)locations[0]).Value;
                }
                if(type.GetCustomAttributes(typeof(Route), true) is object[] routes && routes.Length != 0) {
                    route = $"{((Route)routes[0]).Value}";
                }
                if(type.GetCustomAttributes(typeof(ShortcutKeys), true) is object[] shortcutKeys && shortcutKeys.Length != 0) {
                    keys = ((ShortcutKeys)shortcutKeys[0]).Value;
                }
            }
            route ??= $"{defaultMenuRoute}/{type.FullName.ToLower()}";

            return new MenuItemFull(route, group, location, keys, menuItem);
        }

        private void LoadItems(IEnumerable<Type> types) {
            foreach(var type in types) {
                if(type.IsClass && !type.IsAbstract && type.IsSealed && type.IsSubclassOf(typeof(MenuItem))) {
                    InsertMenuItem(menuCollection, GetMenuItemFull(type));
                }
            }
        }

        #endregion Private Methods

        #region Static Private Methods

        private static List<ToolStripItem> MenuItemRender(MenuItemCollection items) {
            var toolStripItem = new List<ToolStripItem>();

            while(items.Groups.Next() is BinaryHeap<MenuItemCollection> group) {
                while(group.Next() is MenuItemCollection item) {
                    var menuItem = new ToolStripMenuItem();

                    if(item.MenuItem is not null) {
                        var type = item.MenuItem.GetType();
                        if(type.GetMethod("OnClick") is MethodInfo method && !method.DeclaringType.Equals(typeof(MenuItem))) {
                            menuItem.Click += item.MenuItem.OnClick;
                        }
                        if(type.GetProperty("Text") is not PropertyInfo property || property.DeclaringType.Equals(typeof(MenuItem))) {
                            menuItem.Text = item.Route;
                        }
                        menuItem.Image = item.MenuItem.Icon;
                        try { menuItem.ShortcutKeys = item.ShortcutKeys; } catch { }
                        menuItem.Tag = new Tuple<string, MenuItem>(item.Route, item.MenuItem);
                    } else {
                        menuItem.Text = item.Route;
                        menuItem.Tag = new Tuple<string, MenuItem>(item.Route, null);
                    }

                    menuItem.DropDownItems.AddRange(MenuItemRender(item).ToArray());
                    toolStripItem.Add(menuItem);
                }
                if(items.Groups.GetList().Count != 0) {
                    toolStripItem.Add(new ToolStripSeparator());
                }
            }

            return toolStripItem;
        }

        private static void InsertMenuItem(MenuItemCollection items, MenuItemFull item) {
            var routes = item.Route.Split("/");

            var group = items.FindByRoute(routes[0]);
            group ??= items.Add(routes[0], item.Group, item.Location, item.ShortcutKeys);

            if(routes.Length > 1) {
                item.Route = item.Route.Replace($"{routes[0]}/", "");
                InsertMenuItem(group, item);
            } else {
                group.MenuItem = item.MenuItem;
            }
        }

        private static ToolStripMenuItem GetMenuItem(IEnumerable items, string route) {
            if(!string.IsNullOrEmpty(route)) {
                var routes = route.Split("/");
                if(MenuItemExists(items, routes[0]) is ToolStripMenuItem toolStripMenuItem) {
                    if(routes.Length == 1) {
                        return toolStripMenuItem;
                    } else {
                        route = route.Replace($"{routes[0]}/", "");
                        return GetMenuItem(toolStripMenuItem.DropDownItems, route);
                    }
                }
            }
            return null;
        }

        private static ToolStripMenuItem MenuItemExists(IEnumerable items, string code) {
            foreach(var item in items) {
                if(item is ToolStripMenuItem toolStripMenuItem && toolStripMenuItem.Tag is Tuple<string, MenuItem> menuItem && menuItem.Item1.Equals(code)) {
                    return toolStripMenuItem;
                }
            }
            return null;
        }

        private static void TextsUpdate(IEnumerable items) {
            foreach(var item in items) {
                if(item is ToolStripMenuItem toolStripMenuItem) {
                    if(toolStripMenuItem.Tag is Tuple<string, MenuItem> menuItem && menuItem.Item2 is not null && menuItem.Item2.GetType().GetProperty("Text") is PropertyInfo property && !property.DeclaringType.Equals(typeof(MenuItem))) {
                        toolStripMenuItem.Text = menuItem.Item2.Text;
                    }
                    TextsUpdate(toolStripMenuItem.DropDownItems);
                }
            }
        }

        #endregion Static Private Methods
    }
}