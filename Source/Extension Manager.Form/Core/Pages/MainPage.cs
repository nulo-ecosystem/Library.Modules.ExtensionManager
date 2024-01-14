using Nulo.Modules.ExtensionManager;
using Nulo.Modules.WorkspaceManager.Docking;

namespace Nulo.Core.Pages {

    public partial class MainPage : Form {

        #region MainPage

        public MainPage() {
            InitializeComponent();
            DockPanel.Controls.Add(Program.WorkspaceManager.DockPanel);
            Program.WorkspaceManager.Style = WorkspaceManager_Style;
            Program.WorkspaceManager.SetToolStripWorkspaces(ToolStripWorkspaces);
            //Program.WorkspaceManager.SetMenuStripWorkspaces(Program.ExtensionManager.GetMenuItem("window"), Program.ExtensionManager.GetMenuItem("window/workspaces"));
            Program.WorkspaceManager.Init();

            Program.MultiLanguageManager.SwitchLanguage += MultiLanguageManager_SwitchLanguage;
            Program.MultiLanguageManager.Update();
        }

        private void MainPage_FormClosing(object sender, FormClosingEventArgs e) {
            Program.WorkspaceManager.Dispose();
        }

        #endregion MainPage

        #region WorkspaceManager

        private void WorkspaceManager_Style(ToolStripExtender style) {
            BackColor = Program.WorkspaceManager.Theme.ColorPalette.CommandBarMenuDefault.Background;

            style.SetStyle(MenuStrip);
            style.SetStyle(ToolStrip);
            style.SetStyle(StatusStrip);
        }

        #endregion WorkspaceManager

        #region MultiLanguageManager

        private void MultiLanguageManager_SwitchLanguage() {
            //Program.ExtensionManager.TextsUpdate();
            Program.WorkspaceManager.TextsUpdate();
        }

        #endregion MultiLanguageManager
    }
}