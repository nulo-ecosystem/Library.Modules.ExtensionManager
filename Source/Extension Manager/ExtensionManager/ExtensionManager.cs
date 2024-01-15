namespace Nulo.Modules.ExtensionManager {

    public class ExtensionManager<ExtensionData, DefaultMenuItem> where ExtensionData : IExtensionData where DefaultMenuItem : MenuItem {
        private readonly IExtensionData extensionData;

        private List<DataMenuItem> dataMenuItems;
        private string defaultRoute;

        public ExtensionManager() {
            extensionData = Activator.CreateInstance<ExtensionData>();
        }

        #region Public Methods

        public void LoadLocalMenuItem() {
            dataMenuItems = [];

            var menuItem = GetDataMenuItem(typeof(DefaultMenuItem));
            defaultRoute = menuItem.Route;
            InsertMenuItem(dataMenuItems, menuItem);

            LoadMenuItem(extensionData.GetLocalMenuItems());
        }

        public IEnumerable<PluginItem> LoadPluginItems() => extensionData.GetPluginMenuItems();

        public void LoadPluginMenuItem(PluginItem pluginItem) => LoadMenuItem(pluginItem.Assembly.GetTypes());

        #endregion Public Methods

        #region Private Methods

        private void LoadMenuItem(IEnumerable<Type> types) {
            foreach(var type in types) {
                if(type.IsClass && !type.IsAbstract && type.IsSealed && type.IsSubclassOf(typeof(MenuItem))) {
                    InsertMenuItem(dataMenuItems, GetDataMenuItem(type));
                }
            }
        }

        private DataMenuItem GetDataMenuItem(Type type) {
            var menuItem = (MenuItem)Activator.CreateInstance(type);
            string route = null;
            byte group = 0;

            if(type.CustomAttributes.Any()) {
                if(type.GetCustomAttributes(typeof(Route), true) is object[] routes && routes.Length != 0) {
                    route = $"{((Route)routes[0]).Value}";
                }
                if(type.GetCustomAttributes(typeof(Group), true) is object[] groups && groups.Length != 0) {
                    group = ((Group)groups[0]).Value;
                }
            }

            route ??= $"{defaultRoute}/{type.FullName.ToLower()}";

            return new DataMenuItem { Route = route, Group = group, MenuItem = menuItem };
        }

        #endregion Private Methods

        #region Private Static Methods

        private static void InsertMenuItem(List<DataMenuItem> dataMenuItems, DataMenuItem newData) {
            var route = newData.Route.Split("/");
            if(dataMenuItems.FirstOrDefault(a => a.Route.Equals(route[0])) is DataMenuItem dataMenuItem && route.Length > 1) {
                newData.Route = newData.Route.Replace($"{route[0]}/", "");

                //SubMenuItem subMenuItem = null;
                if(newData.SubMenuItems.FirstOrDefault(a => a.Group == newData.Group) is SubMenuItem subMenuItem) {
                    subMenuItem.Items
                } else {

                }

                //InsertMenuItem(dataMenuItems..Items, newData);
            } else if(route.Length == 1) {
                dataMenuItems.Add(newData);
            }
            //if(currentData.Route.Equals(route[0])) {
            //    DataMenuItem dataMenuItem = null;
            //    foreach(var subMenuItem in currentData.SubMenuItems) {
            //        if(subMenuItem.Items.Route.Equals(route[0])) {
            //            dataMenuItem = subMenuItem.Items;
            //            break;
            //        }
            //    }
            //    if(dataMenuItem is null) {
            //        currentData.SubMenuItems.Add(new SubMenuItem { Group = newData.Group, Items = newData });
            //        InsertMenuItem(currentData.SubMenuItems[0].Items, newData);
            //    }
            //}

            //if(currentData.FirstOrDefault(a => a.Route.Equals(route[0])) is DataMenuItem dataMenuItem && route.Length > 1) {
            //    newData.Route = newData.Route.Replace($"{route[0]}/", "");
            //
            //    var subMenuItem = dataMenuItem.SubMenuItems.FirstOrDefault(a => a.Group.Equals(newData.Group));
            //    if(subMenuItem is null) {
            //        subMenuItem = new SubMenuItem { Group = newData.Group };
            //        dataMenuItem.SubMenuItems.Add(subMenuItem);// ---
            //    }
            //
            //    InsertMenuItem(subMenuItem.Items, newData);
            //} else if(route.Length == 1) {
            //    currentData.Add(newData);// ---
            //}
        }

        #endregion Private Static Methods

        public void Render() {
            // ...
            defaultRoute = null;
            dataMenuItems = null;
        }
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