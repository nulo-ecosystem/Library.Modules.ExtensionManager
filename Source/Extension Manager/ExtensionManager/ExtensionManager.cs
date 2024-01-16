namespace Nulo.Modules.ExtensionManager {

    public sealed class ExtensionManager<ExtensionData, DefaultMenuItem> where ExtensionData : IExtensionData where DefaultMenuItem : MenuItem {
        private readonly IExtensionData extensionData;

        private string defaultRoute;

        public ExtensionManager() {
            extensionData = Activator.CreateInstance<ExtensionData>();
        }

        #region Public Methods

        public void LoadLocalMenuItem() {
            var menuItem = GetDataMenuItem(typeof(DefaultMenuItem));
            defaultRoute = menuItem.Route;
            InsertMenuItem(menuItem);

            LoadMenuItem(extensionData.GetLocalMenuItems());
        }

        public IEnumerable<PluginItem> LoadPluginItems() {
            return extensionData.GetPluginMenuItems();
        }

        public void LoadPluginMenuItem(PluginItem pluginItem) {
            LoadMenuItem(pluginItem.Assembly.GetTypes());
        }

        #endregion Public Methods

        #region Private Methods

        private InstanceMenuItem GetDataMenuItem(Type type) {
            byte group = 0, location = 0;
            string route = null;
            var menuItem = (MenuItem)Activator.CreateInstance(type);

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
            }
            route ??= $"{defaultRoute}/{type.FullName.ToLower()}";

            return new InstanceMenuItem { Group = group, Location = location, Route = route, MenuItem = menuItem };
        }

        private void LoadMenuItem(IEnumerable<Type> types) {
            foreach(var type in types) {
                if(type.IsClass && !type.IsAbstract && type.IsSealed && type.IsSubclassOf(typeof(MenuItem))) {
                    InsertMenuItem(GetDataMenuItem(type));
                }
            }
        }

        private void InsertMenuItem(InstanceMenuItem item) {
            //dataMenuItems.Add(item.Group, item.Route);
        }

        #endregion Private Methods

        public void Render() {
        }

        /*
        .
        .
        .
        .
        .
        .
        .
        .
        .
        .
        .
        .
        .
        .
        .
        .
        .
        .
        .
        .
        .
        .
        .
        .
        .
        .
        .
        .
        .
        .
        .
        .
        .
        .
        .
        .
        .
        .
        .
        .
        .
        .
        .
        .
        .
        .
        .
        .
        .
        .
        .
        .
        .
        .
        .
        .
        .
        .
         */
        ////private List<DataMenuItem> dataMenuItems;
        ////

        //#region Public Methods

        ////public void LoadLocalMenuItem() {
        ////    dataMenuItems = [];

        ////    var menuItem = GetDataMenuItem(typeof(DefaultMenuItem));
        ////    defaultRoute = menuItem.Route;
        ////    InsertMenuItem(dataMenuItems, menuItem);

        ////    LoadMenuItem(extensionData.GetLocalMenuItems());
        ////}

        //#endregion Public Methods

        //#region Private Methods
        //#endregion Private Methods

        //#region Private Static Methods

        //private static void InsertMenuItem(List<DataMenuItem> items, DataMenuItem item) {
        //    var routes = item.Route.Split("/");
        //    if(items.FirstOrDefault(a => a.Route.Equals(routes[0])) is DataMenuItem dataMenuItem && routes.Length > 1) {
        //        item.Route = item.Route.Replace($"{routes[0]}/", "");

        //        var subMenuItem = dataMenuItem.SubMenuItems.FirstOrDefault(a => a.Group == item.Group);
        //        if(subMenuItem is null) {
        //            subMenuItem = new SubMenuItem { Group = item.Group };

        //            int index = 0;
        //            for(int i = 0; i < dataMenuItem.SubMenuItems.Count; i++) {
        //                if(subMenuItem.Group < dataMenuItem.SubMenuItems[i].Group) { break; }
        //                index = i + 1;
        //            }

        //            dataMenuItem.SubMenuItems.Insert(index, subMenuItem);
        //        }

        //        InsertMenuItem(subMenuItem.Items, item);
        //    } else if(routes.Length == 1) {
        //        int index = 0;
        //        for(int i = 0; i < items.Count; i++) {
        //            if(item.Group < items[i].Group) { break; }
        //            index = i + 1;
        //        }

        //        items.Insert(index, item);
        //    }
        //}

        //#endregion Private Static Methods

        //public void Render() {
        //    // ...
        //    defaultRoute = null;
        //    dataMenuItems = null;
        //}
    }
}

//private static void SetMenuItem(ToolStripItemCollection items, MenuItem menuItem) {
//    if(!string.IsNullOrEmpty(menuItem.Route)) {
//        var route = menuItem.Route.Split("/");
//        if(ItemExists(items, route[0]) is ToolStripMenuItem toolStripMenuItem) {
//            if(route.Length > 1) {
//                menuItem.Route = menuItem.Route.Replace($"{route[0]}/", "");
//                SetMenuItem(toolStripMenuItem.DropDownItems, menuItem);
//            }
//        } else if(route.Length == 1) {
//            var item = new ToolStripMenuItem {
//                Image = menuItem.Instance.Icon,
//                Text = menuItem.Instance.Text,
//                Tag = menuItem
//            };
//            if(menuItem.IsOnClick) { item.Click += menuItem.Instance.OnClick; }
//            Insert(items, item);
//        }
//    }
//}

//private static ToolStripMenuItem GetMenuItem(ToolStripItemCollection items, string route) {
//    if(!string.IsNullOrEmpty(route)) {
//        var routes = route.Split("/");
//        if(ItemExists(items, routes[0]) is ToolStripMenuItem toolStripMenuItem) {
//            if(routes.Length == 1) {
//                return toolStripMenuItem;
//            } else {
//                route = route.Replace($"{routes[0]}/", "");
//                return GetMenuItem(toolStripMenuItem.DropDownItems, route);
//            }
//        }
//    }
//    return null;
//}

//private static ToolStripMenuItem ItemExists(ToolStripItemCollection items, string code) {
//    for(int i = 0; i < items.Count; i++) {
//        if(items[i].Tag is not null && items[i].Tag is MenuItem menuItem) {
//            if(menuItem.Route.Equals(code)) {
//                return items[i] as ToolStripMenuItem;
//            }
//        }
//    }
//    return null;
//}

//private static void TextsUpdate(ToolStripItemCollection items) {
//    foreach(ToolStripMenuItem item in items) {
//        if(item.Tag is MenuItem menuItem) { item.Text = menuItem.Instance.Text; }
//        TextsUpdate(item.DropDownItems);
//    }
//}

//private static void Insert(ToolStripItemCollection items, ToolStripMenuItem item) {
//    var dataMenuItem = dataMenuItems.FirstOrDefault(a => a.Items.Equals(items));
//    if(dataMenuItem is null) {
//        dataMenuItem = new DataMenuItem { Items = items };
//        dataMenuItems.Add(dataMenuItem);
//    }

//    var menuItem = (MenuItem)item.Tag;
//    if(dataMenuItem.SubMenuItems.FirstOrDefault(a => a.SubPosition == menuItem.SubPosition) is not SubMenuItem subMenuItem) {
//        subMenuItem = new SubMenuItem { SubPosition = menuItem.SubPosition };
//        if(dataMenuItem.SubMenuItems.Count == 0) {
//            dataMenuItem.SubMenuItems.Add(subMenuItem);
//        } else {
//            for(int i = 0; i < dataMenuItem.SubMenuItems.Count; i++) {
//                if(subMenuItem.SubPosition < dataMenuItem.SubMenuItems[i].SubPosition) {
//                    dataMenuItem.SubMenuItems.Insert(i, subMenuItem);
//                    break;
//                } else if(i + 1 >= dataMenuItem.SubMenuItems.Count) {
//                    dataMenuItem.SubMenuItems.Add(subMenuItem);
//                    break;
//                }
//            }
//        }
//    }

//    subMenuItem.Count++;
//    items.Add(item);
//    //int low, subLow, high, subHigh, subMid = 0;
//    ////, mid = 0;

//    //while(low <= high) {
//    //    mid = (low + high) / 2;
//    //    try {
//    //        if(((MenuItem)items[mid].Tag).Position < ((MenuItem)item.Tag).Position) {
//    //            low = mid + 1;
//    //        } else {
//    //            high = mid - 1;
//    //        }
//    //    } catch {
//    //        break;
//    //    }
//    //}
//}

//#endregion Menu Item