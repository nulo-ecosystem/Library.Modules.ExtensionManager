namespace Nulo.Modules.ExtensionManager {

    internal class ExtensionData : IExtensionData {

        public IEnumerable<Type> GetLocalMenuItems() {
            return Assembly.GetAssembly(typeof(ExtensionData)).GetTypes();
        }

        public List<PluginItem> GetPluginItems() {
            var folder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\plugins";
            if(!Directory.Exists(folder)) {
                Directory.CreateDirectory(folder);
            }

            List<PluginItem> pluginItems = [];
            foreach(var path in Directory.GetFiles(folder, "*.dll")) {
                //Assembly pluginAssembly = Assembly.LoadFile(path);
                pluginItems.Add(new PluginItem { Title = path });
            }

            return pluginItems;
        }

        public IEnumerable<Type> GetPluginsMenuItems(PluginItem pluginItem) {
            return [];
        }
    }
}