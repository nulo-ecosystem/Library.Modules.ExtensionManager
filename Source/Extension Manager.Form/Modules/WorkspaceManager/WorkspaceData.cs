using Nulo.Modules.WorkspaceManager.Docking;

namespace Nulo.Modules.WorkspaceManager {

    internal class WorkspaceData : IWorkspaceData {

        #region Current Workspace

        public string LoadCurrentWorkspace() {
            return Properties.Settings.Default.Workspace;
        }

        public void SaveCurrentWorkspace(string content) {
            Properties.Settings.Default.Workspace = content;
            Properties.Settings.Default.Save();
        }

        #endregion Current Workspace

        #region Default Workspaces

        public List<DefaultWorkspace> LoadAllDefaultWorkspaces() => [];

        public string LoadDefaultWorkspace(string key = null) {
            switch(key) {
                default: { return DefaultWorkspaces.Empty; }
            }
        }

        #endregion Default Workspaces

        #region User Workspaces

        public List<string> LoadAllUserWorkspaces() {
            var userWorkspaces = Properties.Settings.Default.UserWorkspaces;
            if(userWorkspaces is null) {
                Properties.Settings.Default.UserWorkspaces = userWorkspaces = [];
                Properties.Settings.Default.Save();
            }
            List<string> list = [];
            foreach(var workspace in userWorkspaces) { list.Add(workspace.Key); }
            return list;
        }

        public string LoadUserWorkspace(string key = null) {
            var userWorkspaces = Properties.Settings.Default.UserWorkspaces;
            foreach(var workspace in userWorkspaces) {
                if(workspace.Key.Equals(key)) { return workspace.Content; }
            }
            return null;
        }

        public bool SaveUserWorkspace(UserWorkspace workspace) {
            try {
                var userWorkspaces = Properties.Settings.Default.UserWorkspaces;
                userWorkspaces.Add(workspace);
                Properties.Settings.Default.UserWorkspaces = userWorkspaces;
                Properties.Settings.Default.Save();
                return true;
            } catch {
                return false;
            }
        }

        public bool DeleteUserWorkspace(UserWorkspace workspace) {
            var userWorkspaces = Properties.Settings.Default.UserWorkspaces;
            foreach(var userWorkspace in userWorkspaces) {
                if(userWorkspace.Key.Equals(workspace.Key)) {
                    userWorkspaces.Remove(userWorkspace);
                    Properties.Settings.Default.UserWorkspaces = userWorkspaces;
                    Properties.Settings.Default.Save();
                    return true;
                }
            }
            return false;
        }

        #endregion User Workspaces

        public Texts GetTexts() {
            return new Texts {
                SaveMenuItem = Program.MultiLanguageManager.GetText("MenuWindowWorkspacesSave"),
                DeleteMenuItem = Program.MultiLanguageManager.GetText("MenuWindowWorkspacesDelete"),

                NewWorkspaceTitle = Program.MultiLanguageManager.GetText("Dialog_NewWorkspace_Title"),
                NewWorkspaceName = Program.MultiLanguageManager.GetText("Dialog_NewWorkspace_Name"),
                NewWorkspaceMessageErrorDuplicate = Program.MultiLanguageManager.GetText("Dialog_NewWorkspace_ErrorDuplicate"),
                NewWorkspaceMessageErrorInvalidCharacter = Program.MultiLanguageManager.GetText("Dialog_NewWorkspace_InvalidCharacter"),

                DeleteWorkspaceTitle = Program.MultiLanguageManager.GetText("Dialog_DeleteWorkspace_Title"),
                DeleteWorkspaceSelect = Program.MultiLanguageManager.GetText("Dialog_DeleteWorkspace_Select"),

                CommandSave = Program.MultiLanguageManager.GetText("CommandSave"),
                CommandDelete = Program.MultiLanguageManager.GetText("CommandDelete")
            };
        }

        public IDockContent GetInstanceByPanelType(string fullName) {
            try {
                return Activator.CreateInstance(Type.GetType(fullName)) as IDockContent;
            } catch {
                return null;
            }
        }
    }
}