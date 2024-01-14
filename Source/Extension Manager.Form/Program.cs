using Nulo.Modules.MultiLanguageManager;
using Nulo.Modules.ExtensionManager;
using Nulo.Modules.WorkspaceManager;
using Nulo.Core.Pages;

namespace Nulo {

    internal static class Program {
        public static ExtensionManager<ExtensionData> ExtensionManager;
        public static MultiLanguageManager<LanguageData> MultiLanguageManager;
        public static WorkspaceManager<WorkspaceTheme, WorkspaceData> WorkspaceManager;

        [STAThread]
        private static void Main() {
            ApplicationConfiguration.Initialize();
            Application.SetCompatibleTextRenderingDefault(false);

            #region Loading Modules

            var splash = new SplashScreen();
            splash.Show();
            Application.DoEvents();
            Thread.Sleep(500);

            #region Multi-Language Manager

            // Notify
            splash.SetStatusLabel("...");
            // Settings
            MultiLanguageManager = new MultiLanguageManager<LanguageData>("Nulo.Modules.MultiLanguageManager.Language");
            // Await
            Thread.Sleep(500);

            #endregion Multi-Language Manager

            #region Extension Manager

            // Notify
            splash.SetStatusLabel(MultiLanguageManager.GetText("Pages_SplashScreen_PluginManager_LoadLocalMenuItem"));
            // Settings
            ExtensionManager = new ExtensionManager<ExtensionData>();
            ExtensionManager.LoadLocalMenuItem();
            // Await
            Thread.Sleep(500);

            foreach(var pluginItem in ExtensionManager.PluginFileCount()) {
                // Notify
                splash.SetStatusLabel($"{MultiLanguageManager.GetText("Pages_SplashScreen_PluginManager_LoadPluginMenuItem")} {pluginItem.Title}...");
                // Settings
                ExtensionManager.LoadPluginMenuItem(pluginItem);
                // Await
                Thread.Sleep(500);
            }

            // Notify
            splash.SetStatusLabel(MultiLanguageManager.GetText("Pages_SplashScreen_PluginManager_Settings"));
            // Settings
            ExtensionManager.SetMenuItem();
            // Await
            Thread.Sleep(500);

            #endregion Extension Manager

            #region Workspace Manager

            // Notify
            splash.SetStatusLabel(MultiLanguageManager.GetText("Pages_SplashScreen_WorkspaceManager"));
            // Settings
            WorkspaceManager = new WorkspaceManager<WorkspaceTheme, WorkspaceData>();
            // Await
            Thread.Sleep(500);

            #endregion Workspace Manager

            splash.SetStatusLabel(string.Empty);
            Thread.Sleep(500);
            splash.Dispose();

            #endregion Loading Modules

            Application.Run(new MainPage());
        }
    }
}