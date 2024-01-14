using Nulo.Modules.WorkspaceManager.Docking;

namespace Nulo.Modules.WorkspaceManager {

    internal class WorkspaceTheme : IWorkspaceTheme {

        public ThemeBase GetTheme(string key = null) {
            if(Properties.Settings.Default.Theme.Equals(key)) { return null; }
            key ??= Properties.Settings.Default.Theme;

            switch(key) {
                case "dark": {
                    Properties.Settings.Default.Theme = "dark";
                    Properties.Settings.Default.Save();
                    return new DarkTheme();
                }
                default: {
                    Properties.Settings.Default.Theme = "light";
                    Properties.Settings.Default.Save();
                    return new LightTheme();
                }
            }
        }
    }
}