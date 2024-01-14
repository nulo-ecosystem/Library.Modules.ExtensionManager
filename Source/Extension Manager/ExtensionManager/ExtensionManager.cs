using System.Reflection;

namespace Nulo.Modules.ExtensionManager {

    public class ExtensionManager<ExtensionData> where ExtensionData : IExtensionData {
        private readonly IExtensionData extensionData;

        public ExtensionManager() {
            extensionData = Activator.CreateInstance<ExtensionData>();
            menuItems = [];
        }

        #region MenuItems

        private List<MenuItem> menuItems;

        public void LoadLocalMenuItem() {
            foreach(var type in extensionData.GetLocalMenuItems()) {
                if(type.CustomAttributes.Any() && type.GetCustomAttributes(typeof(MenuItem), true) is object[] attributes && attributes.Length != 0 && attributes[0] is MenuItem attribute) {
                    attribute.Instance = (IMenuItem)Activator.CreateInstance(type);
                    menuItems.Add(attribute);
                }
            }
        }

        public List<PluginItem> PluginFileCount() => extensionData.GetPluginItems();

        public void LoadPluginMenuItem(PluginItem pluginItem) {
            var a = Assembly.LoadFile(pluginItem.Title);

            foreach(var type in extensionData.GetPluginsMenuItems(pluginItem)) {
                if(type.CustomAttributes.Any() && type.GetCustomAttributes(typeof(MenuItem), true) is object[] attributes && attributes.Length != 0 && attributes[0] is MenuItem attribute) {
                    attribute.Instance = (IMenuItem)Activator.CreateInstance(type);
                    menuItems.Add(attribute);
                }
            }
        }

        public void SetMenuItem() {
            menuItems = null;
        }

        #endregion MenuItems
    }
}

//        private readonly List<DataMenuItem> dataMenuItems;
//private IMainPage mainPage;

//public void Init<MenuPage>() where MenuPage : IMainPage {
//    mainPage = Activator.CreateInstance<IMainPage>();
//    List<MenuItem> items = [];
//    foreach(var type in extensionData.GetLocalMenuItems()) {
//        if(type.CustomAttributes.Any() && type.GetCustomAttributes(typeof(MenuItem), true) is object[] attributes && attributes.Length != 0 && attributes[0] is MenuItem attribute) {
//            attribute.Instance = (IMenuItem)Activator.CreateInstance(type);
//            items.Add(attribute);
//        }
//    }
//    foreach(var item in items) { SetMenuItem(mainPage.Menu.Items, item); }
//    dataMenuItems = null;
//}

//#region Public Methods

//public Form GetForm() => mainPage as Form;

//public ToolStripMenuItem GetMenuItem(string route) => GetMenuItem(mainPage.Menu.Items, route);

//public void TextsUpdate() => TextsUpdate(mainPage.Menu.Items);

//#endregion Public Methods

//#region Menu Item

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

/*
namespace Nulo.Modules.ExtensionManager {
    internal class DataMenuItem {
        public ToolStripItemCollection Items { get; set; }

        public List<SubMenuItem> SubMenuItems { get; set; } = [];
    }

    internal class SubMenuItem {
        public int SubPosition { get; set; }

        public int Count { get; set; }
    }
}
*/