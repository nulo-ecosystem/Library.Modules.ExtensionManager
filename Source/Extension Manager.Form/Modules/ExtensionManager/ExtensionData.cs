namespace Nulo.Modules.ExtensionManager {

    internal class ExtensionData : IExtensionData {

        public IEnumerable<Type> GetLocalItems() {
            return Assembly.GetAssembly(typeof(ExtensionData)).GetTypes();
        }

        public IEnumerable<PluginItem> GetPluginItems() {
            var folder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\plugins";
            if(!Directory.Exists(folder)) {
                Directory.CreateDirectory(folder);
            }

            List<PluginItem> pluginItems = [];
            foreach(var path in Directory.GetFiles(folder, "*.dll")) {
                var assembly = Assembly.LoadFile(path);
                var infor = FileVersionInfo.GetVersionInfo(assembly.Location);
                pluginItems.Add(new PluginItem(infor.ProductName, assembly));
            }
            return pluginItems;
        }
    }
}